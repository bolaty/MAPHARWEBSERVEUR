using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsPhamouvementstockreglementnatureoperationWSDAL: ITableDAL<clsPhamouvementstockreglementnatureoperation>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT COUNT(NO_CODENATUREOPERATION) AS NO_CODENATUREOPERATION  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT MIN(NO_CODENATUREOPERATION) AS NO_CODENATUREOPERATION  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
            this.vapRequete = "SELECT MAX(NO_CODENATUREOPERATION) AS NO_CODENATUREOPERATION  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION "; //+ this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementnatureoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementnatureoperation pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NO_LIBELLE  , NO_ABREVIATION  , FO_CODEFAMILLEOPERATION  , PL_CODENUMCOMPTE  , NO_SENS  , NO_PREFIXECOMPTE  , NO_REFPIECE  , NO_MONTANT  , NO_AFFICHER  , PL_CODENUMCOMPTESURPLUS  , NO_OPERATIONSYSTEME  , NO_ECRAN  , NO_NUMEROORDRE  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new clsPhamouvementstockreglementnatureoperation();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = clsDonnee.vogDataReader["NO_LIBELLE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = clsDonnee.vogDataReader["NO_ABREVIATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_SENS = clsDonnee.vogDataReader["NO_SENS"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE = clsDonnee.vogDataReader["NO_PREFIXECOMPTE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_REFPIECE = clsDonnee.vogDataReader["NO_REFPIECE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_MONTANT = double.Parse(clsDonnee.vogDataReader["NO_MONTANT"].ToString());
					clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = clsDonnee.vogDataReader["NO_AFFICHER"].ToString();
					clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS = clsDonnee.vogDataReader["PL_CODENUMCOMPTESURPLUS"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = clsDonnee.vogDataReader["NO_OPERATIONSYSTEME"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_ECRAN = clsDonnee.vogDataReader["NO_ECRAN"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NO_NUMEROORDRE"].ToString());
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsPhamouvementstockreglementnatureoperation;
		}






        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglementnatureoperation comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglementnatureoperation pvgTableLabel_RO_CODENATUREOPERATIONTYPE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            this.vapCritere = "WHERE RO_CODENATUREOPERATIONTYPE=@RO_CODENATUREOPERATIONTYPE";
            vapNomParametre = new string[] {  "@RO_CODENATUREOPERATIONTYPE" };
            vapValeurParametre = new object[] {  vppCritere[0] };

            this.vapRequete = "SELECT NO_LIBELLE  ,NO_CODENATUREOPERATION  , NO_ABREVIATION  , FO_CODEFAMILLEOPERATION  , PL_CODENUMCOMPTE  , NO_SENS  , NO_PREFIXECOMPTE  , NO_REFPIECE  , NO_MONTANT  , NO_AFFICHER  , PL_CODENUMCOMPTESURPLUS  , NO_OPERATIONSYSTEME  , NO_ECRAN  , NO_NUMEROORDRE  FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new clsPhamouvementstockreglementnatureoperation();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = clsDonnee.vogDataReader["NO_LIBELLE"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = clsDonnee.vogDataReader["NO_ABREVIATION"].ToString();
                    clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_SENS = clsDonnee.vogDataReader["NO_SENS"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE = clsDonnee.vogDataReader["NO_PREFIXECOMPTE"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_REFPIECE = clsDonnee.vogDataReader["NO_REFPIECE"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_MONTANT = double.Parse(clsDonnee.vogDataReader["NO_MONTANT"].ToString());
                    clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = clsDonnee.vogDataReader["NO_AFFICHER"].ToString();
                    clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS = clsDonnee.vogDataReader["PL_CODENUMCOMPTESURPLUS"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = clsDonnee.vogDataReader["NO_OPERATIONSYSTEME"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_ECRAN = clsDonnee.vogDataReader["NO_ECRAN"].ToString();
                    clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NO_NUMEROORDRE"].ToString());
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsPhamouvementstockreglementnatureoperation;
        }






        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsPhamouvementstockreglementnatureoperation>clsPhamouvementstockreglementnatureoperation</param>
        ///<author>Home Technology</author>
        public void pvgInsert(clsDonnee clsDonnee, clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation)
		{
			//Préparation des paramètres
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION ;
			SqlParameter vppParamNO_LIBELLE = new SqlParameter("@NO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNO_LIBELLE.Value  = clsPhamouvementstockreglementnatureoperation.NO_LIBELLE ;
			SqlParameter vppParamNO_ABREVIATION = new SqlParameter("@NO_ABREVIATION", SqlDbType.VarChar, 5);
			vppParamNO_ABREVIATION.Value  = clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION ;
			if(clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION== ""  ) vppParamNO_ABREVIATION.Value  = DBNull.Value;

			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION ;
			if(clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION== ""  ) vppParamFO_CODEFAMILLEOPERATION.Value  = DBNull.Value;

            SqlParameter vppParamRO_CODENATUREOPERATIONTYPE = new SqlParameter("@RO_CODENATUREOPERATIONTYPE", SqlDbType.VarChar, 5);
            vppParamRO_CODENATUREOPERATIONTYPE.Value  = clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE;
            if(clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE == ""  ) vppParamRO_CODENATUREOPERATIONTYPE.Value  = DBNull.Value;


			SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE ;
			if(clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE== ""  ) vppParamPL_CODENUMCOMPTE.Value  = DBNull.Value;
			SqlParameter vppParamNO_SENS = new SqlParameter("@NO_SENS", SqlDbType.VarChar, 1);
			vppParamNO_SENS.Value  = clsPhamouvementstockreglementnatureoperation.NO_SENS ;
			if(clsPhamouvementstockreglementnatureoperation.NO_SENS== ""  ) vppParamNO_SENS.Value  = DBNull.Value;
			SqlParameter vppParamNO_PREFIXECOMPTE = new SqlParameter("@NO_PREFIXECOMPTE", SqlDbType.VarChar, 4);
			vppParamNO_PREFIXECOMPTE.Value  = clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE ;
			if(clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE== ""  ) vppParamNO_PREFIXECOMPTE.Value  = DBNull.Value;
			SqlParameter vppParamNO_REFPIECE = new SqlParameter("@NO_REFPIECE", SqlDbType.VarChar, 1);
			vppParamNO_REFPIECE.Value  = clsPhamouvementstockreglementnatureoperation.NO_REFPIECE ;
			if(clsPhamouvementstockreglementnatureoperation.NO_REFPIECE== ""  ) vppParamNO_REFPIECE.Value  = DBNull.Value;
			SqlParameter vppParamNO_MONTANT = new SqlParameter("@NO_MONTANT", SqlDbType.Money);
			vppParamNO_MONTANT.Value  = clsPhamouvementstockreglementnatureoperation.NO_MONTANT ;
			SqlParameter vppParamNO_AFFICHER = new SqlParameter("@NO_AFFICHER", SqlDbType.VarChar, 1);
			vppParamNO_AFFICHER.Value  = clsPhamouvementstockreglementnatureoperation.NO_AFFICHER ;
			SqlParameter vppParamPL_CODENUMCOMPTESURPLUS = new SqlParameter("@PL_CODENUMCOMPTESURPLUS", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTESURPLUS.Value  = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS ;
			if(clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS== ""  ) vppParamPL_CODENUMCOMPTESURPLUS.Value  = DBNull.Value;
			SqlParameter vppParamNO_OPERATIONSYSTEME = new SqlParameter("@NO_OPERATIONSYSTEME", SqlDbType.VarChar, 1);
			vppParamNO_OPERATIONSYSTEME.Value  = clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME ;
			SqlParameter vppParamNO_ECRAN = new SqlParameter("@NO_ECRAN", SqlDbType.VarChar, 2);
			vppParamNO_ECRAN.Value  = clsPhamouvementstockreglementnatureoperation.NO_ECRAN ;
			SqlParameter vppParamNO_NUMEROORDRE = new SqlParameter("@NO_NUMEROORDRE", SqlDbType.Int);
			vppParamNO_NUMEROORDRE.Value  = clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE ;
            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE;
            if (clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE == "") vppParamPL_NUMCOMPTE.Value = DBNull.Value;

            SqlParameter vppParamPL_CODENUMCOMPTECONTREPARTIE = new SqlParameter("@PL_CODENUMCOMPTECONTREPARTIE", SqlDbType.VarChar, 50);
            vppParamPL_CODENUMCOMPTECONTREPARTIE.Value = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE;
            if (clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE == "") vppParamPL_CODENUMCOMPTECONTREPARTIE.Value = DBNull.Value;

            SqlParameter vppParamPL_NUMCOMPTECONTREPARTIE = new SqlParameter("@PL_NUMCOMPTECONTREPARTIE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTECONTREPARTIE.Value = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE;
            if (clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE == "") vppParamPL_NUMCOMPTECONTREPARTIE.Value = DBNull.Value;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 50);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value = clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION;
            if (clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION == "") vppParamNF_CODENATUREFAMILLEOPERATION.Value = DBNull.Value;


            SqlParameter vppParamPL_NUMCOMPTESURPLUS = new SqlParameter("@PL_NUMCOMPTESURPLUS", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTESURPLUS.Value = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTESURPLUS;
            if (clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTESURPLUS == "") vppParamPL_NUMCOMPTESURPLUS.Value = DBNull.Value;

            SqlParameter vppParamNO_MODIFIERMONTANT = new SqlParameter("@NO_MODIFIERMONTANT", SqlDbType.VarChar, 1);
            vppParamNO_MODIFIERMONTANT.Value = clsPhamouvementstockreglementnatureoperation.NO_MODIFIERMONTANT;


            SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 25);
            vppParamNC_CODENATURECOMPTE.Value = clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE;
            if (clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE == "") vppParamNC_CODENATURECOMPTE.Value = DBNull.Value;

            SqlParameter vppParamNC_CODENATURECOMPTECONTREPARTIE = new SqlParameter("@NC_CODENATURECOMPTECONTREPARTIE", SqlDbType.VarChar, 25);
            vppParamNC_CODENATURECOMPTECONTREPARTIE.Value = clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE;
            if (clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE == "") vppParamNC_CODENATURECOMPTECONTREPARTIE.Value = DBNull.Value;

            SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.VarChar, 25);
            vppParamJO_CODEJOURNAL.Value = clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL;
            if (clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL == "") vppParamJO_CODEJOURNAL.Value = DBNull.Value;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE1", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;

			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  @NO_CODENATUREOPERATION, @NO_LIBELLE, @NO_ABREVIATION, @FO_CODEFAMILLEOPERATION,@RO_CODENATUREOPERATIONTYPE, @PL_CODENUMCOMPTE,@PL_CODENUMCOMPTECONTREPARTIE, @NO_SENS, @NO_PREFIXECOMPTE, @NO_REFPIECE, @NO_MONTANT, @NO_AFFICHER, @PL_CODENUMCOMPTESURPLUS, @NO_OPERATIONSYSTEME, @NO_ECRAN, @NO_NUMEROORDRE,@PL_NUMCOMPTE,@PL_NUMCOMPTECONTREPARTIE,@PL_NUMCOMPTESURPLUS,@NF_CODENATUREFAMILLEOPERATION, @NO_MODIFIERMONTANT, @NC_CODENATURECOMPTE,@NC_CODENATURECOMPTECONTREPARTIE,@JO_CODEJOURNAL, @CODECRYPTAGE1, 0 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamNO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamNO_ABREVIATION);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamRO_CODENATUREOPERATIONTYPE);

			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECONTREPARTIE);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTECONTREPARTIE);
			vppSqlCmd.Parameters.Add(vppParamNO_SENS);
			vppSqlCmd.Parameters.Add(vppParamNO_PREFIXECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamNO_REFPIECE);
			vppSqlCmd.Parameters.Add(vppParamNO_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamNO_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTESURPLUS);
			vppSqlCmd.Parameters.Add(vppParamNO_OPERATIONSYSTEME);
			vppSqlCmd.Parameters.Add(vppParamNO_ECRAN);
			vppSqlCmd.Parameters.Add(vppParamNO_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTESURPLUS);
            vppSqlCmd.Parameters.Add(vppParamNO_MODIFIERMONTANT);

            vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTECONTREPARTIE);
            vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);

            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsPhamouvementstockreglementnatureoperation>clsPhamouvementstockreglementnatureoperation</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation,params string[] vppCritere)
		{
			//Préparation des paramètres
			SqlParameter vppParamNO_CODENATUREOPERATION = new SqlParameter("@NO_CODENATUREOPERATION", SqlDbType.VarChar, 5);
			vppParamNO_CODENATUREOPERATION.Value  = clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION ;
			SqlParameter vppParamNO_LIBELLE = new SqlParameter("@NO_LIBELLE", SqlDbType.VarChar, 150);
			vppParamNO_LIBELLE.Value  = clsPhamouvementstockreglementnatureoperation.NO_LIBELLE ;
			SqlParameter vppParamNO_ABREVIATION = new SqlParameter("@NO_ABREVIATION", SqlDbType.VarChar, 5);
			vppParamNO_ABREVIATION.Value  = clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION ;
			if(clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION== ""  ) vppParamNO_ABREVIATION.Value  = DBNull.Value;
			SqlParameter vppParamFO_CODEFAMILLEOPERATION = new SqlParameter("@FO_CODEFAMILLEOPERATION", SqlDbType.VarChar, 2);
			vppParamFO_CODEFAMILLEOPERATION.Value  = clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION ;
			if(clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION== ""  ) vppParamFO_CODEFAMILLEOPERATION.Value  = DBNull.Value;


            SqlParameter vppParamRO_CODENATUREOPERATIONTYPE = new SqlParameter("@RO_CODENATUREOPERATIONTYPE", SqlDbType.VarChar, 5);
            vppParamRO_CODENATUREOPERATIONTYPE.Value = clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE;
            if (clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE == "") vppParamRO_CODENATUREOPERATIONTYPE.Value = DBNull.Value;


            SqlParameter vppParamPL_CODENUMCOMPTE = new SqlParameter("@PL_CODENUMCOMPTE", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTE.Value  = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE ;
			if(clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE== ""  ) vppParamPL_CODENUMCOMPTE.Value  = DBNull.Value;
			SqlParameter vppParamNO_SENS = new SqlParameter("@NO_SENS", SqlDbType.VarChar, 1);
			vppParamNO_SENS.Value  = clsPhamouvementstockreglementnatureoperation.NO_SENS ;
			if(clsPhamouvementstockreglementnatureoperation.NO_SENS== ""  ) vppParamNO_SENS.Value  = DBNull.Value;
			SqlParameter vppParamNO_PREFIXECOMPTE = new SqlParameter("@NO_PREFIXECOMPTE", SqlDbType.VarChar, 4);
			vppParamNO_PREFIXECOMPTE.Value  = clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE ;
			if(clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE== ""  ) vppParamNO_PREFIXECOMPTE.Value  = DBNull.Value;
			SqlParameter vppParamNO_REFPIECE = new SqlParameter("@NO_REFPIECE", SqlDbType.VarChar, 1);
			vppParamNO_REFPIECE.Value  = clsPhamouvementstockreglementnatureoperation.NO_REFPIECE ;
			if(clsPhamouvementstockreglementnatureoperation.NO_REFPIECE== ""  ) vppParamNO_REFPIECE.Value  = DBNull.Value;
			SqlParameter vppParamNO_MONTANT = new SqlParameter("@NO_MONTANT", SqlDbType.Money);
			vppParamNO_MONTANT.Value  = clsPhamouvementstockreglementnatureoperation.NO_MONTANT ;
			SqlParameter vppParamNO_AFFICHER = new SqlParameter("@NO_AFFICHER", SqlDbType.VarChar, 1);
			vppParamNO_AFFICHER.Value  = clsPhamouvementstockreglementnatureoperation.NO_AFFICHER ;
			SqlParameter vppParamPL_CODENUMCOMPTESURPLUS = new SqlParameter("@PL_CODENUMCOMPTESURPLUS", SqlDbType.VarChar, 25);
			vppParamPL_CODENUMCOMPTESURPLUS.Value  = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS ;
			if(clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS== ""  ) vppParamPL_CODENUMCOMPTESURPLUS.Value  = DBNull.Value;
			SqlParameter vppParamNO_OPERATIONSYSTEME = new SqlParameter("@NO_OPERATIONSYSTEME", SqlDbType.VarChar, 1);
			vppParamNO_OPERATIONSYSTEME.Value  = clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME ;
			SqlParameter vppParamNO_ECRAN = new SqlParameter("@NO_ECRAN", SqlDbType.VarChar, 2);
			vppParamNO_ECRAN.Value  = clsPhamouvementstockreglementnatureoperation.NO_ECRAN ;
			SqlParameter vppParamNO_NUMEROORDRE = new SqlParameter("@NO_NUMEROORDRE", SqlDbType.Int);
			vppParamNO_NUMEROORDRE.Value  = clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE ;

            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTE.Value = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE;
            if (clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE == "") vppParamPL_NUMCOMPTE.Value = DBNull.Value;


            SqlParameter vppParamPL_CODENUMCOMPTECONTREPARTIE = new SqlParameter("@PL_CODENUMCOMPTECONTREPARTIE", SqlDbType.VarChar, 50);
            vppParamPL_CODENUMCOMPTECONTREPARTIE.Value = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE;
            if (clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE == "") vppParamPL_CODENUMCOMPTECONTREPARTIE.Value = DBNull.Value;

            SqlParameter vppParamPL_NUMCOMPTECONTREPARTIE = new SqlParameter("@PL_NUMCOMPTECONTREPARTIE", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTECONTREPARTIE.Value = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE;
            if (clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE == "") vppParamPL_NUMCOMPTECONTREPARTIE.Value = DBNull.Value;

            SqlParameter vppParamNF_CODENATUREFAMILLEOPERATION = new SqlParameter("@NF_CODENATUREFAMILLEOPERATION", SqlDbType.VarChar, 50);
            vppParamNF_CODENATUREFAMILLEOPERATION.Value = clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION;
            if (clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION == "") vppParamNF_CODENATUREFAMILLEOPERATION.Value = DBNull.Value;


            SqlParameter vppParamPL_NUMCOMPTESURPLUS = new SqlParameter("@PL_NUMCOMPTESURPLUS", SqlDbType.VarChar, 50);
            vppParamPL_NUMCOMPTESURPLUS.Value = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTESURPLUS;
            if (clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTESURPLUS == "") vppParamPL_NUMCOMPTESURPLUS.Value = DBNull.Value;

            SqlParameter vppParamNO_MODIFIERMONTANT = new SqlParameter("@NO_MODIFIERMONTANT", SqlDbType.VarChar, 1);
            vppParamNO_MODIFIERMONTANT.Value = clsPhamouvementstockreglementnatureoperation.NO_MODIFIERMONTANT;


            SqlParameter vppParamNC_CODENATURECOMPTE = new SqlParameter("@NC_CODENATURECOMPTE", SqlDbType.VarChar, 25);
            vppParamNC_CODENATURECOMPTE.Value = clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE;
            if (clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE == "") vppParamNC_CODENATURECOMPTE.Value = DBNull.Value;

            SqlParameter vppParamNC_CODENATURECOMPTECONTREPARTIE = new SqlParameter("@NC_CODENATURECOMPTECONTREPARTIE", SqlDbType.VarChar, 25);
            vppParamNC_CODENATURECOMPTECONTREPARTIE.Value = clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE;
            if (clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE == "") vppParamNC_CODENATURECOMPTECONTREPARTIE.Value = DBNull.Value;

            SqlParameter vppParamJO_CODEJOURNAL = new SqlParameter("@JO_CODEJOURNAL", SqlDbType.VarChar, 25);
            vppParamJO_CODEJOURNAL.Value = clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL;
            if (clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL == "") vppParamJO_CODEJOURNAL.Value = DBNull.Value;



            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
			vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION ", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsPhamouvementstockreglementnatureoperation.TYPEOPERATION;
			//Préparation de la commande
            this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  @NO_CODENATUREOPERATION, @NO_LIBELLE, @NO_ABREVIATION, @FO_CODEFAMILLEOPERATION,@RO_CODENATUREOPERATIONTYPE, @PL_CODENUMCOMPTE,@PL_CODENUMCOMPTECONTREPARTIE, @NO_SENS, @NO_PREFIXECOMPTE, @NO_REFPIECE, @NO_MONTANT, @NO_AFFICHER, @PL_CODENUMCOMPTESURPLUS, @NO_OPERATIONSYSTEME, @NO_ECRAN, @NO_NUMEROORDRE,@PL_NUMCOMPTE,@PL_NUMCOMPTECONTREPARTIE,@PL_NUMCOMPTESURPLUS,@NF_CODENATUREFAMILLEOPERATION,@NO_MODIFIERMONTANT,@NC_CODENATURECOMPTE,@NC_CODENATURECOMPTECONTREPARTIE, @JO_CODEJOURNAL, @CODECRYPTAGE, @TYPEOPERATION  ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamNO_CODENATUREOPERATION);
			vppSqlCmd.Parameters.Add(vppParamNO_LIBELLE);
			vppSqlCmd.Parameters.Add(vppParamNO_ABREVIATION);
			vppSqlCmd.Parameters.Add(vppParamFO_CODEFAMILLEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamRO_CODENATUREOPERATIONTYPE);

			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTECONTREPARTIE);
            vppSqlCmd.Parameters.Add(vppParamNF_CODENATUREFAMILLEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTECONTREPARTIE);
            vppSqlCmd.Parameters.Add(vppParamNO_SENS);
			vppSqlCmd.Parameters.Add(vppParamNO_PREFIXECOMPTE);
			vppSqlCmd.Parameters.Add(vppParamNO_REFPIECE);
			vppSqlCmd.Parameters.Add(vppParamNO_MONTANT);
			vppSqlCmd.Parameters.Add(vppParamNO_AFFICHER);
			vppSqlCmd.Parameters.Add(vppParamPL_CODENUMCOMPTESURPLUS);
			vppSqlCmd.Parameters.Add(vppParamNO_OPERATIONSYSTEME);
			vppSqlCmd.Parameters.Add(vppParamNO_ECRAN);
			vppSqlCmd.Parameters.Add(vppParamNO_NUMEROORDRE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTESURPLUS);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTE);
            vppSqlCmd.Parameters.Add(vppParamNC_CODENATURECOMPTECONTREPARTIE);
            vppSqlCmd.Parameters.Add(vppParamJO_CODEJOURNAL);

            vppSqlCmd.Parameters.Add(vppParamNO_MODIFIERMONTANT);
			vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			//Préparation de la commande
			 this.vapRequete = "EXECUTE PC_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION  @NO_CODENATUREOPERATION, '' , '' , '' , '', '' , '' , '' ,'' , '' , '' , '' , '' , '' , '' ,'' , '' ,'' , '' ,'' ,'' ,'' ,'' ,'' , @CODECRYPTAGE, 2 ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementnatureoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementnatureoperation> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NO_CODENATUREOPERATION, NO_LIBELLE, NO_ABREVIATION, FO_CODEFAMILLEOPERATION, PL_CODENUMCOMPTE, NO_SENS, NO_PREFIXECOMPTE, NO_REFPIECE, NO_MONTANT, NO_AFFICHER, PL_CODENUMCOMPTESURPLUS, NO_OPERATIONSYSTEME, NO_ECRAN, NO_NUMEROORDRE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<clsPhamouvementstockreglementnatureoperation>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new clsPhamouvementstockreglementnatureoperation();
					clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = clsDonnee.vogDataReader["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = clsDonnee.vogDataReader["NO_LIBELLE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = clsDonnee.vogDataReader["NO_ABREVIATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = clsDonnee.vogDataReader["FO_CODEFAMILLEOPERATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = clsDonnee.vogDataReader["PL_CODENUMCOMPTE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_SENS = clsDonnee.vogDataReader["NO_SENS"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE = clsDonnee.vogDataReader["NO_PREFIXECOMPTE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_REFPIECE = clsDonnee.vogDataReader["NO_REFPIECE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_MONTANT = double.Parse(clsDonnee.vogDataReader["NO_MONTANT"].ToString());
					clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = clsDonnee.vogDataReader["NO_AFFICHER"].ToString();
					clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS = clsDonnee.vogDataReader["PL_CODENUMCOMPTESURPLUS"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = clsDonnee.vogDataReader["NO_OPERATIONSYSTEME"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_ECRAN = clsDonnee.vogDataReader["NO_ECRAN"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE = int.Parse(clsDonnee.vogDataReader["NO_NUMEROORDRE"].ToString());
					clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsPhamouvementstockreglementnatureoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglementnatureoperation </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglementnatureoperation> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<clsPhamouvementstockreglementnatureoperation>();
			DataSet Dataset = new DataSet();

			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT  NO_CODENATUREOPERATION, NO_LIBELLE, NO_ABREVIATION, FO_CODEFAMILLEOPERATION, PL_CODENUMCOMPTE, NO_SENS, NO_PREFIXECOMPTE, NO_REFPIECE, NO_MONTANT, NO_AFFICHER, PL_CODENUMCOMPTESURPLUS, NO_OPERATIONSYSTEME, NO_ECRAN, NO_NUMEROORDRE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new clsPhamouvementstockreglementnatureoperation();
					clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_CODENATUREOPERATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_LIBELLE = Dataset.Tables["TABLE"].Rows[Idx]["NO_LIBELLE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION = Dataset.Tables["TABLE"].Rows[Idx]["NO_ABREVIATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION = Dataset.Tables["TABLE"].Rows[Idx]["FO_CODEFAMILLEOPERATION"].ToString();
					clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_SENS = Dataset.Tables["TABLE"].Rows[Idx]["NO_SENS"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["NO_PREFIXECOMPTE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_REFPIECE = Dataset.Tables["TABLE"].Rows[Idx]["NO_REFPIECE"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_MONTANT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["NO_MONTANT"].ToString());
					clsPhamouvementstockreglementnatureoperation.NO_AFFICHER = Dataset.Tables["TABLE"].Rows[Idx]["NO_AFFICHER"].ToString();
					clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS = Dataset.Tables["TABLE"].Rows[Idx]["PL_CODENUMCOMPTESURPLUS"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME = Dataset.Tables["TABLE"].Rows[Idx]["NO_OPERATIONSYSTEME"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_ECRAN = Dataset.Tables["TABLE"].Rows[Idx]["NO_ECRAN"].ToString();
					clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["NO_NUMEROORDRE"].ToString());
					clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
				}
				Dataset.Dispose();
			}
		return clsPhamouvementstockreglementnatureoperations;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT *  FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetEcranParametrage(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@NF_CODENATUREFAMILLEOPERATION", "@FO_CODEFAMILLEOPERATION", "@TYPEETAT" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };

            this.vapRequete = "EXEC  [dbo].[PS_EC_RUBRIQUESCOLARITE] @NF_CODENATUREFAMILLEOPERATION,@FO_CODEFAMILLEOPERATION,@TYPEETAT,@CODECRYPTAGE ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
			pvpChoixCritere(clsDonnee ,vppCritere);
			this.vapRequete = "SELECT NO_CODENATUREOPERATION , NO_LIBELLE FROM dbo.FT_PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION(@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : NO_CODENATUREOPERATION, PL_CODENUMCOMPTE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboEdition(clsDonnee clsDonnee, params string[] vppCritere)
        {
	        this.vapRequete = "SELECT NO_CODENATUREOPERATION , NO_LIBELLE FROM dbo.PHAMOUVEMENTSTOCKREGLEMENTNATUREOPERATION WHERE ( FO_CODEFAMILLEOPERATION IN(SELECT FO_CODEFAMILLEOPERATION FROM PHAFAMILLEOPERATION WHERE NF_CODENATUREFAMILLEOPERATION IN('02','04') ) OR RO_CODENATUREOPERATIONTYPE IS NOT NULL) ORDER BY NO_NUMEROORDRE ";
	        this.vapCritere = "";
	        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
	        return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
        }

		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :NO_CODENATUREOPERATION, PL_CODENUMCOMPTE)</summary>
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
				this.vapCritere ="WHERE NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NO_CODENATUREOPERATION"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0]};
				break;
				case 2 :
				this.vapCritere ="WHERE NO_CODENATUREOPERATION=@NO_CODENATUREOPERATION AND PL_CODENUMCOMPTE=@PL_CODENUMCOMPTE";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@NO_CODENATUREOPERATION","@PL_CODENUMCOMPTE"};
				vapValeurParametre = new object[]{clsDonnee.vogCleCryptage,vppCritere[0],vppCritere[1]};
				break;
			}
		}
	}
}
