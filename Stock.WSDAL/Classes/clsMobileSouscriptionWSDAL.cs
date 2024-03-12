using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsMobileSouscriptionWSDAL: ITableDAL<clsMobileSouscription>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(TI_NUMTIERS) AS TI_NUMTIERS  FROM dbo.MobileSouscription " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.MobileSouscription " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(TI_IDTIERS) AS TI_IDTIERS  FROM dbo.MobileSouscription " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		public string pvgValueScalarRequeteMax1(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(TI_NUMTIERS) AS TI_NUMTIERS  FROM dbo.MobileSouscription " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsMobileSouscription pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritereRecherche(clsDonnee, vppCritere);
            pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TI_IDTIERS,TI_NUMTIERS, AC_CODEACTIVITE,TP_CODETYPETIERS,TI_DATENAISSANCE,TI_DENOMINATION,TI_DESCRIPTIONTIERS,TI_ADRESSEPOSTALE,TI_ADRESSEGEOGRAPHIQUE,TI_TELEPHONE,TI_FAX,TI_SITEWEB,TI_EMAIL,TI_GERANT,TI_STATUT,TI_DATESAISIE,TI_ASDI,TI_TVA,TI_STATUTDOUTEUX,TI_PLAFONDCREDIT,TI_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,TI_SIEGE,PL_NUMCOMPTE FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    //clsMobileSouscription.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
     //               clsMobileSouscription.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
     //               clsMobileSouscription.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
     //               clsMobileSouscription.TI_SIEGE = clsDonnee.vogDataReader["TI_SIEGE"].ToString();
     //               //clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
     //               //clsMobileSouscription.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
					//clsMobileSouscription.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					//clsMobileSouscription.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					//clsMobileSouscription.TI_NUMTIERS = clsDonnee.vogDataReader["TI_NUMTIERS"].ToString();
					//clsMobileSouscription.TI_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATENAISSANCE"].ToString());
					//clsMobileSouscription.TI_DENOMINATION = clsDonnee.vogDataReader["TI_DENOMINATION"].ToString();
					//clsMobileSouscription.TI_DESCRIPTIONTIERS = clsDonnee.vogDataReader["TI_DESCRIPTIONTIERS"].ToString();
					//clsMobileSouscription.TI_ADRESSEPOSTALE = clsDonnee.vogDataReader["TI_ADRESSEPOSTALE"].ToString();
					//clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TI_ADRESSEGEOGRAPHIQUE"].ToString();
					//clsMobileSouscription.TI_TELEPHONE = clsDonnee.vogDataReader["TI_TELEPHONE"].ToString();
					//clsMobileSouscription.TI_FAX = clsDonnee.vogDataReader["TI_FAX"].ToString();
					//clsMobileSouscription.TI_SITEWEB = clsDonnee.vogDataReader["TI_SITEWEB"].ToString();
					//clsMobileSouscription.TI_EMAIL = clsDonnee.vogDataReader["TI_EMAIL"].ToString();
					//clsMobileSouscription.TI_GERANT = clsDonnee.vogDataReader["TI_GERANT"].ToString();
					//clsMobileSouscription.TI_STATUT = clsDonnee.vogDataReader["TI_STATUT"].ToString();
					//clsMobileSouscription.TI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATESAISIE"].ToString());
					//clsMobileSouscription.TI_ASDI = clsDonnee.vogDataReader["TI_ASDI"].ToString();
					//clsMobileSouscription.TI_TVA = clsDonnee.vogDataReader["TI_TVA"].ToString();
     //               //clsMobileSouscription.TI_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["TI_STATUTDOUTEUX"].ToString());
					//clsMobileSouscription.TI_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["TI_PLAFONDCREDIT"].ToString());
					//clsMobileSouscription.TI_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["TI_NUMCPTECONTIBUABLE"].ToString();
					//clsMobileSouscription.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
     //               clsMobileSouscription.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsMobileSouscription;
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMobileSouscription pvgTableLabelVENTE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            //pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TI_IDTIERS,TI_NUMTIERS, AC_CODEACTIVITE,TP_CODETYPETIERS,TI_DATENAISSANCE,TI_DENOMINATION,TI_DESCRIPTIONTIERS,TI_ADRESSEPOSTALE,TI_ADRESSEGEOGRAPHIQUE,TI_TELEPHONE,TI_FAX,TI_SITEWEB,TI_EMAIL,TI_GERANT,TI_STATUT,TI_DATESAISIE,TI_ASDI,TI_TVA,TI_STATUTDOUTEUX,TI_PLAFONDCREDIT,TI_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,TI_SIEGE,PL_NUMCOMPTE,PY_CODEPAYS FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    ////clsMobileSouscription.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    //clsMobileSouscription.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
                    //clsMobileSouscription.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
                    //clsMobileSouscription.TI_SIEGE = clsDonnee.vogDataReader["TI_SIEGE"].ToString();
                    ////clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    ////clsMobileSouscription.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
                    //clsMobileSouscription.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
                    //clsMobileSouscription.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
                    //clsMobileSouscription.TI_NUMTIERS = clsDonnee.vogDataReader["TI_NUMTIERS"].ToString();
                    //clsMobileSouscription.TI_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATENAISSANCE"].ToString());
                    //clsMobileSouscription.TI_DENOMINATION = clsDonnee.vogDataReader["TI_DENOMINATION"].ToString();
                    //clsMobileSouscription.TI_DESCRIPTIONTIERS = clsDonnee.vogDataReader["TI_DESCRIPTIONTIERS"].ToString();
                    //clsMobileSouscription.TI_ADRESSEPOSTALE = clsDonnee.vogDataReader["TI_ADRESSEPOSTALE"].ToString();
                    //clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                    //clsMobileSouscription.TI_TELEPHONE = clsDonnee.vogDataReader["TI_TELEPHONE"].ToString();
                    //clsMobileSouscription.TI_FAX = clsDonnee.vogDataReader["TI_FAX"].ToString();
                    //clsMobileSouscription.TI_SITEWEB = clsDonnee.vogDataReader["TI_SITEWEB"].ToString();
                    //clsMobileSouscription.TI_EMAIL = clsDonnee.vogDataReader["TI_EMAIL"].ToString();
                    //clsMobileSouscription.TI_GERANT = clsDonnee.vogDataReader["TI_GERANT"].ToString();
                    //clsMobileSouscription.TI_STATUT = clsDonnee.vogDataReader["TI_STATUT"].ToString();
                    //clsMobileSouscription.TI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATESAISIE"].ToString());
                    //clsMobileSouscription.TI_ASDI = clsDonnee.vogDataReader["TI_ASDI"].ToString();
                    //clsMobileSouscription.TI_TVA = clsDonnee.vogDataReader["TI_TVA"].ToString();
                    ////clsMobileSouscription.TI_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["TI_STATUTDOUTEUX"].ToString());
                    //clsMobileSouscription.TI_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["TI_PLAFONDCREDIT"].ToString());
                    //clsMobileSouscription.TI_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["TI_NUMCPTECONTIBUABLE"].ToString();
                    //clsMobileSouscription.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    //clsMobileSouscription.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    //clsMobileSouscription.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMobileSouscription;
        }




        //public clsMobileSouscription pvgTableLabelVENTE(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    pvpChoixCritereRecherche(clsDonnee, vppCritere);
        //    //pvpChoixCritere3(clsDonnee, vppCritere);
        //    this.vapRequete = "SELECT TI_IDTIERS,[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,TI_NUMTIERS,'" + clsDonnee.vogCleCryptage + "'), AC_CODEACTIVITE,TP_CODETYPETIERS,TI_DATENAISSANCE,DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',TI_DENOMINATION) AS varchar(150)) AS  TI_DENOMINATION,TI_DESCRIPTIONTIERS,TI_ADRESSEPOSTALE,TI_ADRESSEGEOGRAPHIQUE,TI_TELEPHONE,TI_FAX,TI_SITEWEB,TI_EMAIL,TI_GERANT,TI_STATUT,TI_DATESAISIE,TI_ASDI,TI_TVA,TI_STATUTDOUTEUX,TI_PLAFONDCREDIT,TI_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,TI_SIEGE,PL_NUMCOMPTE,PY_CODEPAYS FROM dbo.VUE_MobileSouscription  " + this.vapCritere;
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
        //    if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
        //    {
        //        while (clsDonnee.vogDataReader.Read())
        //        {
        //            //clsMobileSouscription.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
        //            clsMobileSouscription.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
        //            clsMobileSouscription.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
        //            clsMobileSouscription.TI_SIEGE = clsDonnee.vogDataReader["TI_SIEGE"].ToString();
        //            //clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
        //            //clsMobileSouscription.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
        //            clsMobileSouscription.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
        //            clsMobileSouscription.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
        //            clsMobileSouscription.TI_NUMTIERS = clsDonnee.vogDataReader["TI_NUMTIERS"].ToString();
        //            clsMobileSouscription.TI_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATENAISSANCE"].ToString());
        //            clsMobileSouscription.TI_DENOMINATION = clsDonnee.vogDataReader["TI_DENOMINATION"].ToString();
        //            clsMobileSouscription.TI_DESCRIPTIONTIERS = clsDonnee.vogDataReader["TI_DESCRIPTIONTIERS"].ToString();
        //            clsMobileSouscription.TI_ADRESSEPOSTALE = clsDonnee.vogDataReader["TI_ADRESSEPOSTALE"].ToString();
        //            clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TI_ADRESSEGEOGRAPHIQUE"].ToString();
        //            clsMobileSouscription.TI_TELEPHONE = clsDonnee.vogDataReader["TI_TELEPHONE"].ToString();
        //            clsMobileSouscription.TI_FAX = clsDonnee.vogDataReader["TI_FAX"].ToString();
        //            clsMobileSouscription.TI_SITEWEB = clsDonnee.vogDataReader["TI_SITEWEB"].ToString();
        //            clsMobileSouscription.TI_EMAIL = clsDonnee.vogDataReader["TI_EMAIL"].ToString();
        //            clsMobileSouscription.TI_GERANT = clsDonnee.vogDataReader["TI_GERANT"].ToString();
        //            clsMobileSouscription.TI_STATUT = clsDonnee.vogDataReader["TI_STATUT"].ToString();
        //            clsMobileSouscription.TI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATESAISIE"].ToString());
        //            clsMobileSouscription.TI_ASDI = clsDonnee.vogDataReader["TI_ASDI"].ToString();
        //            clsMobileSouscription.TI_TVA = clsDonnee.vogDataReader["TI_TVA"].ToString();
        //            //clsMobileSouscription.TI_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["TI_STATUTDOUTEUX"].ToString());
        //            clsMobileSouscription.TI_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["TI_PLAFONDCREDIT"].ToString());
        //            clsMobileSouscription.TI_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["TI_NUMCPTECONTIBUABLE"].ToString();
        //            clsMobileSouscription.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
        //            clsMobileSouscription.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
        //            clsMobileSouscription.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
        //        }
        //        clsDonnee.vogDataReader.Dispose();
        //    }
        //    return clsMobileSouscription;
        //}







        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsMobileSouscription comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsMobileSouscription pvgTableLabelVENTECaisse(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            //pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TOP 1 TI_IDTIERS,TI_NUMTIERS, AC_CODEACTIVITE,TP_CODETYPETIERS,TI_DATENAISSANCE,TI_DENOMINATION,TI_DESCRIPTIONTIERS,TI_ADRESSEPOSTALE,TI_ADRESSEGEOGRAPHIQUE,TI_TELEPHONE,TI_FAX,TI_SITEWEB,TI_EMAIL,TI_GERANT,TI_STATUT,TI_DATESAISIE,TI_ASDI,TI_TVA,TI_STATUTDOUTEUX,TI_PLAFONDCREDIT,TI_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,TI_SIEGE,PL_NUMCOMPTE,PY_CODEPAYS FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    ////clsMobileSouscription.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    //clsMobileSouscription.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
                    //clsMobileSouscription.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
                    //clsMobileSouscription.TI_SIEGE = clsDonnee.vogDataReader["TI_SIEGE"].ToString();
                    ////clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    ////clsMobileSouscription.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
                    //clsMobileSouscription.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
                    //clsMobileSouscription.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
                    //clsMobileSouscription.TI_NUMTIERS = clsDonnee.vogDataReader["TI_NUMTIERS"].ToString();
                    //clsMobileSouscription.TI_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATENAISSANCE"].ToString());
                    //clsMobileSouscription.TI_DENOMINATION = clsDonnee.vogDataReader["TI_DENOMINATION"].ToString();
                    //clsMobileSouscription.TI_DESCRIPTIONTIERS = clsDonnee.vogDataReader["TI_DESCRIPTIONTIERS"].ToString();
                    //clsMobileSouscription.TI_ADRESSEPOSTALE = clsDonnee.vogDataReader["TI_ADRESSEPOSTALE"].ToString();
                    //clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TI_ADRESSEGEOGRAPHIQUE"].ToString();
                    //clsMobileSouscription.TI_TELEPHONE = clsDonnee.vogDataReader["TI_TELEPHONE"].ToString();
                    //clsMobileSouscription.TI_FAX = clsDonnee.vogDataReader["TI_FAX"].ToString();
                    //clsMobileSouscription.TI_SITEWEB = clsDonnee.vogDataReader["TI_SITEWEB"].ToString();
                    //clsMobileSouscription.TI_EMAIL = clsDonnee.vogDataReader["TI_EMAIL"].ToString();
                    //clsMobileSouscription.TI_GERANT = clsDonnee.vogDataReader["TI_GERANT"].ToString();
                    //clsMobileSouscription.TI_STATUT = clsDonnee.vogDataReader["TI_STATUT"].ToString();
                    //clsMobileSouscription.TI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATESAISIE"].ToString());
                    //clsMobileSouscription.TI_ASDI = clsDonnee.vogDataReader["TI_ASDI"].ToString();
                    //clsMobileSouscription.TI_TVA = clsDonnee.vogDataReader["TI_TVA"].ToString();
                    ////clsMobileSouscription.TI_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["TI_STATUTDOUTEUX"].ToString());
                    //clsMobileSouscription.TI_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["TI_PLAFONDCREDIT"].ToString());
                    //clsMobileSouscription.TI_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["TI_NUMCPTECONTIBUABLE"].ToString();
                    //clsMobileSouscription.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    //clsMobileSouscription.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    //clsMobileSouscription.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsMobileSouscription;
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMobileSouscription>clsMobileSouscription</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription)
		{
			////Préparation des paramètres
   //         SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
   //         vppParamAG_CODEAGENCE.Value = clsMobileSouscription.AG_CODEAGENCE;

   //         SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.BigInt);
   //         vppParamTI_IDTIERS.Value = clsMobileSouscription.TI_IDTIERS;

   //         SqlParameter vppParamTI_IDTIERSPRINCIPAL = new SqlParameter("@TI_IDTIERSPRINCIPAL", SqlDbType.BigInt);
   //         vppParamTI_IDTIERSPRINCIPAL.Value = clsMobileSouscription.TI_IDTIERSPRINCIPAL;
   //         if(clsMobileSouscription.TI_IDTIERSPRINCIPAL=="") vppParamTI_IDTIERSPRINCIPAL.Value = DBNull.Value;

   //         SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 5);
   //         vppParamNT_CODENATURETIERS.Value = clsMobileSouscription.NT_CODENATURETIERS;

   //         SqlParameter vppParamTI_SIEGE = new SqlParameter("@TI_SIEGE", SqlDbType.VarChar,150);
   //         vppParamTI_SIEGE.Value = clsMobileSouscription.TI_SIEGE;
   //         if (clsMobileSouscription.TI_SIEGE == "")
   //             vppParamTI_SIEGE.Value = DBNull.Value;

   //         SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
   //         vppParamSX_CODESEXE.Value = clsMobileSouscription.SX_CODESEXE;
   //         if (clsMobileSouscription.SX_CODESEXE == "")
   //             vppParamSX_CODESEXE.Value = DBNull.Value;

   //         SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 2);
   //         vppParamFM_CODEFORMEJURIDIQUE.Value = clsMobileSouscription.FM_CODEFORMEJURIDIQUE;
   //         if (clsMobileSouscription.FM_CODEFORMEJURIDIQUE == "")
   //             vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;


   //         //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
   //         //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE;
   //         //if (clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE == "")
   //         //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


   //         //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
   //         //vppParamPF_CODEPROFESSION.Value = clsMobileSouscription.PF_CODEPROFESSION;
   //         //if (clsMobileSouscription.PF_CODEPROFESSION == "")
   //         //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;


   //         SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
   //         vppParamAC_CODEACTIVITE.Value = clsMobileSouscription.AC_CODEACTIVITE;
   //         if (clsMobileSouscription.AC_CODEACTIVITE == "")
   //             vppParamAC_CODEACTIVITE.Value = DBNull.Value;


   //         SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
   //         vppParamTP_CODETYPETIERS.Value = clsMobileSouscription.TP_CODETYPETIERS;

   //         SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
   //         vppParamTC_CODECOMPTETYPETIERS.Value = clsMobileSouscription.TC_CODECOMPTETYPETIERS;
   //         if (clsMobileSouscription.TC_CODECOMPTETYPETIERS == "")
   //             vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;

   //         SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 7);
   //         vppParamTI_NUMTIERS.Value = clsMobileSouscription.TI_NUMTIERS;

   //         SqlParameter vppParamTI_DATENAISSANCE = new SqlParameter("@TI_DATENAISSANCE", SqlDbType.DateTime);
   //         vppParamTI_DATENAISSANCE.Value = clsMobileSouscription.TI_DATENAISSANCE;
   //         if (clsMobileSouscription.TI_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamTI_DATENAISSANCE.Value = "01/01/1900";

   //         SqlParameter vppParamTI_DENOMINATION = new SqlParameter("@TI_DENOMINATION", SqlDbType.VarChar, 150);
   //         vppParamTI_DENOMINATION.Value = clsMobileSouscription.TI_DENOMINATION;

   //         SqlParameter vppParamTI_DESCRIPTIONTIERS = new SqlParameter("@TI_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
   //         vppParamTI_DESCRIPTIONTIERS.Value = clsMobileSouscription.TI_DESCRIPTIONTIERS;

   //         SqlParameter vppParamTI_ADRESSEPOSTALE = new SqlParameter("@TI_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
   //         vppParamTI_ADRESSEPOSTALE.Value = clsMobileSouscription.TI_ADRESSEPOSTALE;

   //         SqlParameter vppParamTI_ADRESSEGEOGRAPHIQUE = new SqlParameter("@TI_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
   //         vppParamTI_ADRESSEGEOGRAPHIQUE.Value = clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE;

   //         SqlParameter vppParamTI_TELEPHONE = new SqlParameter("@TI_TELEPHONE", SqlDbType.VarChar, 80);
   //         vppParamTI_TELEPHONE.Value = clsMobileSouscription.TI_TELEPHONE;

   //         SqlParameter vppParamTI_FAX = new SqlParameter("@TI_FAX", SqlDbType.VarChar, 80);
   //         vppParamTI_FAX.Value = clsMobileSouscription.TI_FAX;

   //         SqlParameter vppParamTI_SITEWEB = new SqlParameter("@TI_SITEWEB", SqlDbType.VarChar, 150);
   //         vppParamTI_SITEWEB.Value = clsMobileSouscription.TI_SITEWEB;

   //         SqlParameter vppParamTI_EMAIL = new SqlParameter("@TI_EMAIL", SqlDbType.VarChar, 80);
   //         vppParamTI_EMAIL.Value = clsMobileSouscription.TI_EMAIL;

   //         SqlParameter vppParamTI_GERANT = new SqlParameter("@TI_GERANT", SqlDbType.VarChar, 150);
   //         vppParamTI_GERANT.Value = clsMobileSouscription.TI_GERANT;

   //         //SqlParameter vppParamTI_STATUT = new SqlParameter("@TI_STATUT", SqlDbType.VarChar, 1);
   //         //vppParamTI_STATUT.Value = clsMobileSouscription.TI_STATUT;

   //         SqlParameter vppParamTI_DATESAISIE = new SqlParameter("@TI_DATESAISIE", SqlDbType.DateTime);
   //         vppParamTI_DATESAISIE.Value = clsMobileSouscription.TI_DATESAISIE;
   //         if (clsMobileSouscription.TI_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamTI_DATESAISIE.Value = "01/01/1900";

   //         SqlParameter vppParamTI_ASDI = new SqlParameter("@TI_ASDI", SqlDbType.VarChar, 1);
   //         vppParamTI_ASDI.Value = clsMobileSouscription.TI_ASDI;

   //         SqlParameter vppParamTI_TVA = new SqlParameter("@TI_TVA", SqlDbType.VarChar, 1);
   //         vppParamTI_TVA.Value = clsMobileSouscription.TI_TVA;

   //         SqlParameter vppParamTI_STATUTDOUTEUX = new SqlParameter("@TI_STATUTDOUTEUX", SqlDbType.Int);
   //         vppParamTI_STATUTDOUTEUX.Value = clsMobileSouscription.TI_STATUTDOUTEUX;

   //         SqlParameter vppParamTI_PLAFONDCREDIT = new SqlParameter("@TI_PLAFONDCREDIT", SqlDbType.Money);
   //         vppParamTI_PLAFONDCREDIT.Value = clsMobileSouscription.TI_PLAFONDCREDIT;

   //         SqlParameter vppParamTI_NUMCPTECONTIBUABLE = new SqlParameter("@TI_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
   //         vppParamTI_NUMCPTECONTIBUABLE.Value = clsMobileSouscription.TI_NUMCPTECONTIBUABLE;

   //         SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
   //         vppParamOP_CODEOPERATEUR.Value = clsMobileSouscription.OP_CODEOPERATEUR;
   //         SqlParameter vppParamTI_TAUXREMISE = new SqlParameter("@TI_TAUXREMISE", SqlDbType.Float);
   //         vppParamTI_TAUXREMISE.Value = clsMobileSouscription.TI_TAUXREMISE;

   //         SqlParameter vppParamTI_TAUXDECLARATION = new SqlParameter("@TI_TAUXDECLARATION", SqlDbType.Float);
   //         vppParamTI_TAUXDECLARATION.Value = clsMobileSouscription.TI_TAUXDECLARATION;
			////Préparation de la commande
   //         this.vapRequete = "INSERT INTO MobileSouscription (  AG_CODEAGENCE, TI_IDTIERS,TI_IDTIERSPRINCIPAL, NT_CODENATURETIERS, TI_SIEGE,SX_CODESEXE,FM_CODEFORMEJURIDIQUE,AC_CODEACTIVITE, TP_CODETYPETIERS,TC_CODECOMPTETYPETIERS, TI_NUMTIERS, TI_DATENAISSANCE, TI_DENOMINATION, TI_DESCRIPTIONTIERS, TI_ADRESSEPOSTALE, TI_ADRESSEGEOGRAPHIQUE, TI_TELEPHONE, TI_FAX, TI_SITEWEB, TI_EMAIL, TI_GERANT, TI_DATESAISIE, TI_ASDI, TI_TVA, TI_STATUTDOUTEUX, TI_PLAFONDCREDIT, TI_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR, TI_TAUXREMISE,TI_TAUXDECLARATION) " +
   //                  "VALUES ( @AG_CODEAGENCE, @TI_IDTIERS,  @TI_IDTIERSPRINCIPAL, @NT_CODENATURETIERS, @TI_SIEGE,@SX_CODESEXE,@FM_CODEFORMEJURIDIQUE,@AC_CODEACTIVITE, @TP_CODETYPETIERS,@TC_CODECOMPTETYPETIERS, @TI_NUMTIERS, @TI_DATENAISSANCE, @TI_DENOMINATION, @TI_DESCRIPTIONTIERS, @TI_ADRESSEPOSTALE, @TI_ADRESSEGEOGRAPHIQUE, @TI_TELEPHONE, @TI_FAX, @TI_SITEWEB, @TI_EMAIL, @TI_GERANT, @TI_DATESAISIE, @TI_ASDI, @TI_TVA, @TI_STATUTDOUTEUX, @TI_PLAFONDCREDIT, @TI_NUMCPTECONTIBUABLE, @OP_CODEOPERATEUR, @TI_TAUXREMISE,@TI_TAUXDECLARATION) ";
			//SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			////Ajout des paramètre à la commande
			//vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			//vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
   //         vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSPRINCIPAL);
   //         vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
   //         vppSqlCmd.Parameters.Add(vppParamTI_SIEGE);


   //         vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
   //         vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
   //         //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
   //         //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
   //         vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			//vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
   //         vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
			//vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
			//vppSqlCmd.Parameters.Add(vppParamTI_DATENAISSANCE);
			//vppSqlCmd.Parameters.Add(vppParamTI_DENOMINATION);
			//vppSqlCmd.Parameters.Add(vppParamTI_DESCRIPTIONTIERS);
			//vppSqlCmd.Parameters.Add(vppParamTI_ADRESSEPOSTALE);
			//vppSqlCmd.Parameters.Add(vppParamTI_ADRESSEGEOGRAPHIQUE);
			//vppSqlCmd.Parameters.Add(vppParamTI_TELEPHONE);
			//vppSqlCmd.Parameters.Add(vppParamTI_FAX);
			//vppSqlCmd.Parameters.Add(vppParamTI_SITEWEB);
			//vppSqlCmd.Parameters.Add(vppParamTI_EMAIL);
			//vppSqlCmd.Parameters.Add(vppParamTI_GERANT);
			//vppSqlCmd.Parameters.Add(vppParamTI_DATESAISIE);
			//vppSqlCmd.Parameters.Add(vppParamTI_ASDI);
			//vppSqlCmd.Parameters.Add(vppParamTI_TVA);
			//vppSqlCmd.Parameters.Add(vppParamTI_STATUTDOUTEUX);
			//vppSqlCmd.Parameters.Add(vppParamTI_PLAFONDCREDIT);
			//vppSqlCmd.Parameters.Add(vppParamTI_NUMCPTECONTIBUABLE);
			//vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
   //         vppSqlCmd.Parameters.Add(vppParamTI_TAUXREMISE);
   //         vppSqlCmd.Parameters.Add(vppParamTI_TAUXDECLARATION);
			////Ouverture de la connection et exécution de la commande
   //         clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsMobileSouscription>clsMobileSouscription</param>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription)
        {
        //    //Préparation des paramètres
        //    SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
        //    vppParamAG_CODEAGENCE.Value = clsMobileSouscription.AG_CODEAGENCE;

        //    SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
        //    vppParamEN_CODEENTREPOT.Value = clsMobileSouscription.EN_CODEENTREPOT;

        //    SqlParameter vppParamTI_IDTIERS = new SqlParameter("@TI_IDTIERS", SqlDbType.VarChar, 25);
        //    vppParamTI_IDTIERS.Value = clsMobileSouscription.TI_IDTIERS;

        //    SqlParameter vppParamTI_IDTIERSPRINCIPAL = new SqlParameter("@TI_IDTIERSPRINCIPAL", SqlDbType.VarChar, 25);
        //    vppParamTI_IDTIERSPRINCIPAL.Value = clsMobileSouscription.TI_IDTIERSPRINCIPAL;
        //    if(vppParamTI_IDTIERSPRINCIPAL.Value=="")vppParamTI_IDTIERSPRINCIPAL.Value = DBNull.Value;

            

        //    SqlParameter vppParamNT_CODENATURETYPETIERS = new SqlParameter("@NT_CODENATURETYPETIERS", SqlDbType.VarChar, 2);
        //    vppParamNT_CODENATURETYPETIERS.Value = clsMobileSouscription.NT_CODENATURETYPETIERS;
        //    if (clsMobileSouscription.NT_CODENATURETYPETIERS == "") vppParamNT_CODENATURETYPETIERS.Value = DBNull.Value;

        //    SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 5);
        //    vppParamNT_CODENATURETIERS.Value = clsMobileSouscription.NT_CODENATURETIERS;

        //    //SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 8);
        //    //vppParamPY_CODEPAYS.Value = clsMobileSouscription.PY_CODEPAYS;
        //    //if (clsMobileSouscription.PY_CODEPAYS == "") vppParamPY_CODEPAYS.Value = DBNull.Value;

        //    SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
        //    vppParamVL_CODEVILLE.Value = clsMobileSouscription.VL_CODEVILLE;
        //    if (clsMobileSouscription.VL_CODEVILLE == "") vppParamVL_CODEVILLE.Value = DBNull.Value;


        //    SqlParameter vppParamTI_SIEGE = new SqlParameter("@TI_SIEGE", SqlDbType.VarChar, 150);
        //    vppParamTI_SIEGE.Value = clsMobileSouscription.TI_SIEGE;
        //    if (clsMobileSouscription.TI_SIEGE == "")
        //        vppParamTI_SIEGE.Value = DBNull.Value;



        //    SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
        //    vppParamSX_CODESEXE.Value = clsMobileSouscription.SX_CODESEXE;
        //    if (clsMobileSouscription.SX_CODESEXE == "")
        //        vppParamSX_CODESEXE.Value = DBNull.Value;

        //    SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 2);
        //    vppParamFM_CODEFORMEJURIDIQUE.Value = clsMobileSouscription.FM_CODEFORMEJURIDIQUE;
        //    if (clsMobileSouscription.FM_CODEFORMEJURIDIQUE == "")
        //        vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;

        //    //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
        //    //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE;
        //    //if (clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE == "")
        //    //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


        //    //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
        //    //vppParamPF_CODEPROFESSION.Value = clsMobileSouscription.PF_CODEPROFESSION;
        //    //if (clsMobileSouscription.PF_CODEPROFESSION == "")
        //    //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;


        //    SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
        //    vppParamAC_CODEACTIVITE.Value = clsMobileSouscription.AC_CODEACTIVITE;
        //    if (clsMobileSouscription.AC_CODEACTIVITE == "")
        //        vppParamAC_CODEACTIVITE.Value = DBNull.Value;


        //    SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
        //    vppParamTP_CODETYPETIERS.Value = clsMobileSouscription.TP_CODETYPETIERS;


        //    SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
        //    vppParamTC_CODECOMPTETYPETIERS.Value = clsMobileSouscription.TC_CODECOMPTETYPETIERS;
        //    if (clsMobileSouscription.TC_CODECOMPTETYPETIERS == "")
        //        vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;


        //    SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 50);
        //    vppParamTI_NUMTIERS.Value = clsMobileSouscription.TI_NUMTIERS;

        //    SqlParameter vppParamTI_DATENAISSANCE = new SqlParameter("@TI_DATENAISSANCE", SqlDbType.DateTime);
        //    vppParamTI_DATENAISSANCE.Value = clsMobileSouscription.TI_DATENAISSANCE;
        //    if (clsMobileSouscription.TI_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamTI_DATENAISSANCE.Value = "01/01/1900";


        //    SqlParameter vppParamTI_DENOMINATION = new SqlParameter("@TI_DENOMINATION", SqlDbType.VarChar, 150);
        //    vppParamTI_DENOMINATION.Value = clsMobileSouscription.TI_DENOMINATION;

        //    SqlParameter vppParamTI_DESCRIPTIONTIERS = new SqlParameter("@TI_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
        //    vppParamTI_DESCRIPTIONTIERS.Value = clsMobileSouscription.TI_DESCRIPTIONTIERS;

        //    SqlParameter vppParamTI_ADRESSEPOSTALE = new SqlParameter("@TI_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
        //    vppParamTI_ADRESSEPOSTALE.Value = clsMobileSouscription.TI_ADRESSEPOSTALE;

        //    SqlParameter vppParamTI_ADRESSEGEOGRAPHIQUE = new SqlParameter("@TI_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
        //    vppParamTI_ADRESSEGEOGRAPHIQUE.Value = clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE;

        //    SqlParameter vppParamTI_TELEPHONE = new SqlParameter("@TI_TELEPHONE", SqlDbType.VarChar, 80);
        //    vppParamTI_TELEPHONE.Value = clsMobileSouscription.TI_TELEPHONE;

        //    SqlParameter vppParamTI_FAX = new SqlParameter("@TI_FAX", SqlDbType.VarChar, 80);
        //    vppParamTI_FAX.Value = clsMobileSouscription.TI_FAX;

        //    SqlParameter vppParamTI_SITEWEB = new SqlParameter("@TI_SITEWEB", SqlDbType.VarChar, 150);
        //    vppParamTI_SITEWEB.Value = clsMobileSouscription.TI_SITEWEB;

        //    SqlParameter vppParamTI_EMAIL = new SqlParameter("@TI_EMAIL", SqlDbType.VarChar, 80);
        //    vppParamTI_EMAIL.Value = clsMobileSouscription.TI_EMAIL;

        //    SqlParameter vppParamTI_GERANT = new SqlParameter("@TI_GERANT", SqlDbType.VarChar, 150);
        //    vppParamTI_GERANT.Value = clsMobileSouscription.TI_GERANT;

        //    SqlParameter vppParamTI_STATUT = new SqlParameter("@TI_STATUT", SqlDbType.VarChar, 1);
        //    vppParamTI_STATUT.Value = clsMobileSouscription.TI_STATUT;

        //    SqlParameter vppParamTI_DATESAISIE = new SqlParameter("@TI_DATESAISIE", SqlDbType.DateTime);
        //    vppParamTI_DATESAISIE.Value = clsMobileSouscription.TI_DATESAISIE;
        //    if (clsMobileSouscription.TI_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamTI_DATESAISIE.Value = "01/01/1900";

        //    SqlParameter vppParamTI_DATEDEPART = new SqlParameter("@TI_DATEDEPART", SqlDbType.DateTime);
        //    vppParamTI_DATEDEPART.Value = clsMobileSouscription.TI_DATEDEPART;
        //    if (clsMobileSouscription.TI_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamTI_DATEDEPART.Value = "01/01/1900";

        //    SqlParameter vppParamTI_ASDI = new SqlParameter("@TI_ASDI", SqlDbType.VarChar, 1);
        //    vppParamTI_ASDI.Value = clsMobileSouscription.TI_ASDI;

        //    SqlParameter vppParamTI_TVA = new SqlParameter("@TI_TVA", SqlDbType.VarChar, 1);
        //    vppParamTI_TVA.Value = clsMobileSouscription.TI_TVA;

        //    SqlParameter vppParamTI_STATUTDOUTEUX = new SqlParameter("@TI_STATUTDOUTEUX", SqlDbType.Int);
        //    vppParamTI_STATUTDOUTEUX.Value = clsMobileSouscription.TI_STATUTDOUTEUX;

        //    SqlParameter vppParamTI_PLAFONDCREDIT = new SqlParameter("@TI_PLAFONDCREDIT", SqlDbType.Money);
        //    vppParamTI_PLAFONDCREDIT.Value = clsMobileSouscription.TI_PLAFONDCREDIT;

        //    SqlParameter vppParamTI_NUMCPTECONTIBUABLE = new SqlParameter("@TI_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
        //    vppParamTI_NUMCPTECONTIBUABLE.Value = clsMobileSouscription.TI_NUMCPTECONTIBUABLE;

        //    SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
        //    vppParamOP_CODEOPERATEUR.Value = clsMobileSouscription.OP_CODEOPERATEUR;

        //    SqlParameter vppParamTI_PHOTO = new SqlParameter("@TI_PHOTO", SqlDbType.VarBinary);
        //    vppParamTI_PHOTO.Value = clsMobileSouscription.TI_PHOTO;
        //    if (clsMobileSouscription.TI_PHOTO == null) vppParamTI_PHOTO.Value = DBNull.Value;


        //    SqlParameter vppParamTI_SIGNATURE = new SqlParameter("@TI_SIGNATURE", SqlDbType.VarBinary);
        //    vppParamTI_SIGNATURE.Value = clsMobileSouscription.TI_SIGNATURE;
        //    if (clsMobileSouscription.TI_SIGNATURE == null) vppParamTI_SIGNATURE.Value = DBNull.Value;


        //    SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
        //    vppParamPL_NUMCOMPTE.Value = clsMobileSouscription.PL_NUMCOMPTE;
        //    SqlParameter vppParamTI_TAUXREMISE = new SqlParameter("@TI_TAUXREMISE", SqlDbType.Float);
        //    vppParamTI_TAUXREMISE.Value = clsMobileSouscription.TI_TAUXREMISE;

        //    SqlParameter vppParamCU_CODECASUTILISATION = new SqlParameter("@CU_CODECASUTILISATION", SqlDbType.VarChar, 3);
        //    vppParamCU_CODECASUTILISATION.Value = clsMobileSouscription.CU_CODECASUTILISATION;

        //    if (clsMobileSouscription.CU_CODECASUTILISATION == "")
        //        vppParamCU_CODECASUTILISATION.Value = DBNull.Value;

        //    SqlParameter vppParamTI_NUMEROAGREMENT = new SqlParameter("@TI_NUMEROAGREMENT", SqlDbType.VarChar, 150);
        //    vppParamTI_NUMEROAGREMENT.Value = clsMobileSouscription.TI_NUMEROAGREMENT;
        //    if (clsMobileSouscription.TI_NUMEROAGREMENT == "") vppParamTI_NUMEROAGREMENT.Value = DBNull.Value;
        //    SqlParameter vppParamTI_TAUXDECLARATION = new SqlParameter("@TI_TAUXDECLARATION", SqlDbType.Float);
        //    vppParamTI_TAUXDECLARATION.Value = clsMobileSouscription.TI_TAUXDECLARATION;

        //    SqlParameter vppParamGP_CODEGROUPE = new SqlParameter("@GP_CODEGROUPE", SqlDbType.VarChar, 4);
        //    vppParamGP_CODEGROUPE.Value = clsMobileSouscription.GP_CODEGROUPE;
        //    if (clsMobileSouscription.GP_CODEGROUPE == "")
        //        vppParamGP_CODEGROUPE.Value = DBNull.Value;

        //    SqlParameter vppParamTI_MANDATAIRE = new SqlParameter("@TI_MANDATAIRE", SqlDbType.VarChar, 150);
        //    vppParamTI_MANDATAIRE.Value = clsMobileSouscription.TI_MANDATAIRE;
        //    if (clsMobileSouscription.TI_MANDATAIRE == "")
        //        vppParamTI_MANDATAIRE.Value = DBNull.Value;

        //    SqlParameter vppParamTI_USAGER = new SqlParameter("@TI_USAGER", SqlDbType.VarChar, 150);
        //    vppParamTI_USAGER.Value = clsMobileSouscription.TI_USAGER;
        //    if (clsMobileSouscription.TI_USAGER == "")
        //        vppParamTI_USAGER.Value = DBNull.Value;


        //SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 150);
        //    vppParamIN_CODEINGREDIENT.Value = clsMobileSouscription.IN_CODEINGREDIENT;
        //if (clsMobileSouscription.IN_CODEINGREDIENT == "")
        //        vppParamIN_CODEINGREDIENT.Value = DBNull.Value;

        //    SqlParameter vppParamTI_ESCOMPTE = new SqlParameter("@TI_ESCOMPTE", SqlDbType.VarChar, 1);
        //    vppParamTI_ESCOMPTE.Value = clsMobileSouscription.TI_ESCOMPTE;

        //SqlParameter vppParamZN_CODEZONE = new SqlParameter("@ZN_CODEZONE", SqlDbType.VarChar, 150);
        //    vppParamZN_CODEZONE.Value = clsMobileSouscription.ZN_CODEZONE;
        //if (clsMobileSouscription.ZN_CODEZONE == "")
        //vppParamZN_CODEZONE.Value = DBNull.Value;

        //SqlParameter vppParamRE_CODEREGIMEIMPOSITION = new SqlParameter("@RE_CODEREGIMEIMPOSITION", SqlDbType.VarChar, 150);
        //    vppParamRE_CODEREGIMEIMPOSITION.Value = clsMobileSouscription.RE_CODEREGIMEIMPOSITION;
        //if (clsMobileSouscription.RE_CODEREGIMEIMPOSITION == "")
        //        vppParamRE_CODEREGIMEIMPOSITION.Value = DBNull.Value;

        //SqlParameter vppParamSP_CODESPECIALITE = new SqlParameter("@SP_CODESPECIALITE", SqlDbType.VarChar, 150);
        //    vppParamSP_CODESPECIALITE.Value = clsMobileSouscription.SP_CODESPECIALITE;
        //if (clsMobileSouscription.SP_CODESPECIALITE == "")
        //        vppParamSP_CODESPECIALITE.Value = DBNull.Value;

        //SqlParameter vppParamQU_CODEQUARTIER = new SqlParameter("@QU_CODEQUARTIER", SqlDbType.VarChar, 150);
        //    vppParamQU_CODEQUARTIER.Value = clsMobileSouscription.QU_CODEQUARTIER;
        //if (clsMobileSouscription.QU_CODEQUARTIER == "")
        //        vppParamQU_CODEQUARTIER.Value = DBNull.Value;

        //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 150);
        //    vppParamPF_CODEPROFESSION.Value = clsMobileSouscription.PF_CODEPROFESSION;
        //if (clsMobileSouscription.PF_CODEPROFESSION == "")
        //        vppParamPF_CODEPROFESSION.Value = DBNull.Value;

        //SqlParameter vppParamTI_LIEUNAISSANCE = new SqlParameter("@TI_LIEUNAISSANCE", SqlDbType.VarChar, 150);
        //    vppParamTI_LIEUNAISSANCE.Value = clsMobileSouscription.TI_LIEUNAISSANCE;
        //if (clsMobileSouscription.TI_LIEUNAISSANCE == "")
        //        vppParamTI_LIEUNAISSANCE.Value = DBNull.Value;


        //    SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
        //    vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
        //    SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
        //    vppParamTYPEOPERATION.Value = clsMobileSouscription.TYPEOPERATION;


        //    SqlParameter vppParamTI_NUMTIERSRETOUR = new SqlParameter("@TI_NUMTIERSRETOUR", SqlDbType.VarChar, 50);

        //    SqlCommand vppSqlCmd = new SqlCommand("PC_MobileSouscription", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    vppSqlCmd.CommandType = CommandType.StoredProcedure;

        //    ////Préparation de la commande
        //    //this.vapRequete = " EXECUTE [dbo].[PC_MobileSouscription]   @AG_CODEAGENCE, @TI_IDTIERS, @NT_CODENATURETIERS,@PY_CODEPAYS,@VL_CODEVILLE, @TI_SIEGE, @AC_CODEACTIVITE, @TP_CODETYPETIERS, @TI_NUMTIERS,  @TI_DATENAISSANCE, @TI_DENOMINATION, @TI_DESCRIPTIONTIERS, @TI_ADRESSEPOSTALE, @TI_ADRESSEGEOGRAPHIQUE, @TI_TELEPHONE, @TI_FAX, @TI_SITEWEB, @TI_EMAIL, @TI_GERANT, @TI_STATUT,  @TI_DATESAISIE, @TI_ASDI, @TI_TVA , @TI_STATUTDOUTEUX,  @TI_PLAFONDCREDIT,@TI_NUMCPTECONTIBUABLE,@OP_CODEOPERATEUR,@TI_DATEDEPART,@TI_PHOTO,@PL_NUMCOMPTE,@TI_TAUXREMISE,@CU_CODECASUTILISATION,@TI_NUMEROAGREMENT,@TI_TAUXDECLARATION,@CODECRYPTAGE,@TYPEOPERATION";
        //    //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

        //    //Ajout des paramètre à la commande
        //    vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
        //    vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
        //    vppSqlCmd.Parameters.Add(vppParamTI_IDTIERS);
        //    vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSPRINCIPAL);
        //    vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPETIERS);
        //    vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
        //    //vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
        //    vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_SIEGE);



        //    vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
        //    vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
        //    //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
        //    //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
        //    vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
        //    vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
        //    vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
        //    vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
        //    vppSqlCmd.Parameters.Add(vppParamTI_DATENAISSANCE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_DENOMINATION);
        //    vppSqlCmd.Parameters.Add(vppParamTI_DESCRIPTIONTIERS);
        //    vppSqlCmd.Parameters.Add(vppParamTI_ADRESSEPOSTALE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_ADRESSEGEOGRAPHIQUE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_TELEPHONE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_FAX);
        //    vppSqlCmd.Parameters.Add(vppParamTI_SITEWEB);
        //    vppSqlCmd.Parameters.Add(vppParamTI_EMAIL);
        //    vppSqlCmd.Parameters.Add(vppParamTI_GERANT);
        //    vppSqlCmd.Parameters.Add(vppParamTI_STATUT);
        //    vppSqlCmd.Parameters.Add(vppParamTI_DATESAISIE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_ASDI);
        //    vppSqlCmd.Parameters.Add(vppParamTI_TVA);
        //    vppSqlCmd.Parameters.Add(vppParamTI_STATUTDOUTEUX);
        //    vppSqlCmd.Parameters.Add(vppParamTI_PLAFONDCREDIT);
        //    vppSqlCmd.Parameters.Add(vppParamTI_NUMCPTECONTIBUABLE);
        //    vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
        //    vppSqlCmd.Parameters.Add(vppParamTI_DATEDEPART);
        //    vppSqlCmd.Parameters.Add(vppParamTI_PHOTO);
        //    vppSqlCmd.Parameters.Add(vppParamTI_SIGNATURE);
        //    vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_TAUXREMISE);
        //    vppSqlCmd.Parameters.Add(vppParamCU_CODECASUTILISATION);
        //    vppSqlCmd.Parameters.Add(vppParamTI_NUMEROAGREMENT);
        //    vppSqlCmd.Parameters.Add(vppParamTI_TAUXDECLARATION);
        //    vppSqlCmd.Parameters.Add(vppParamGP_CODEGROUPE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_MANDATAIRE);
        //    vppSqlCmd.Parameters.Add(vppParamTI_USAGER);
        //    vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
        //    vppSqlCmd.Parameters.Add(vppParamTI_ESCOMPTE);
        //    vppSqlCmd.Parameters.Add(vppParamZN_CODEZONE);
        //    vppSqlCmd.Parameters.Add(vppParamRE_CODEREGIMEIMPOSITION);
        //    vppSqlCmd.Parameters.Add(vppParamSP_CODESPECIALITE);
        //    vppSqlCmd.Parameters.Add(vppParamQU_CODEQUARTIER);
        //    vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
        //    vppSqlCmd.Parameters.Add(vppParamTI_LIEUNAISSANCE);
        //    vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
        //    vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
        //    vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERSRETOUR);
        //    vppParamTI_NUMTIERSRETOUR.Direction = ParameterDirection.Output;

            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
            //Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
            // valeurs de retour de la procedure stockée
            return null; //vppSqlCmd.Parameters["@TI_NUMTIERSRETOUR"].Value.ToString();
        }



		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsMobileSouscription>clsMobileSouscription</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsMobileSouscription clsMobileSouscription,params string[] vppCritere)
		{
			//Préparation des paramètres
            //SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            //vppParamSX_CODESEXE.Value = clsMobileSouscription.SX_CODESEXE;

            //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE;
            //if (clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE == "")
            //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;

            //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            //vppParamPF_CODEPROFESSION.Value = clsMobileSouscription.PF_CODEPROFESSION;
            //if (clsMobileSouscription.PF_CODEPROFESSION == "")
            //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;

   //         SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
   //         vppParamAC_CODEACTIVITE.Value = clsMobileSouscription.AC_CODEACTIVITE;
   //         if (clsMobileSouscription.AC_CODEACTIVITE == "")
   //             vppParamAC_CODEACTIVITE.Value = DBNull.Value;

   //         SqlParameter vppParamTI_IDTIERSPRINCIPAL = new SqlParameter("@TI_IDTIERSPRINCIPAL", SqlDbType.VarChar, 25);
   //         vppParamTI_IDTIERSPRINCIPAL.Value = clsMobileSouscription.TI_IDTIERSPRINCIPAL;
   //         if (clsMobileSouscription.TI_IDTIERSPRINCIPAL == "")
   //             vppParamTI_IDTIERSPRINCIPAL.Value = DBNull.Value;

   //         SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
   //         vppParamTP_CODETYPETIERS.Value = clsMobileSouscription.TP_CODETYPETIERS;

   //         SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
   //         vppParamTC_CODECOMPTETYPETIERS.Value = clsMobileSouscription.TC_CODECOMPTETYPETIERS;
   //         if (clsMobileSouscription.TC_CODECOMPTETYPETIERS == "")
   //             vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;

   //         SqlParameter vppParamTI_NUMTIERS = new SqlParameter("@TI_NUMTIERS", SqlDbType.VarChar, 7);
   //         vppParamTI_NUMTIERS.Value = clsMobileSouscription.TI_NUMTIERS;

   //         SqlParameter vppParamTI_DATENAISSANCE = new SqlParameter("@TI_DATENAISSANCE", SqlDbType.DateTime);
   //         vppParamTI_DATENAISSANCE.Value = clsMobileSouscription.TI_DATENAISSANCE;
   //         if(clsMobileSouscription.TI_DATENAISSANCE<DateTime.Parse("01/01/1900")) vppParamTI_DATENAISSANCE.Value ="01/01/1900";

   //         SqlParameter vppParamTI_DENOMINATION = new SqlParameter("@TI_DENOMINATION", SqlDbType.VarChar, 150);
   //         vppParamTI_DENOMINATION.Value = clsMobileSouscription.TI_DENOMINATION;

   //         SqlParameter vppParamTI_DESCRIPTIONTIERS = new SqlParameter("@TI_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
   //         vppParamTI_DESCRIPTIONTIERS.Value = clsMobileSouscription.TI_DESCRIPTIONTIERS;

   //         SqlParameter vppParamTI_ADRESSEPOSTALE = new SqlParameter("@TI_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
   //         vppParamTI_ADRESSEPOSTALE.Value = clsMobileSouscription.TI_ADRESSEPOSTALE;

   //         SqlParameter vppParamTI_ADRESSEGEOGRAPHIQUE = new SqlParameter("@TI_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
   //         vppParamTI_ADRESSEGEOGRAPHIQUE.Value = clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE;

   //         SqlParameter vppParamTI_TELEPHONE = new SqlParameter("@TI_TELEPHONE", SqlDbType.VarChar, 80);
   //         vppParamTI_TELEPHONE.Value = clsMobileSouscription.TI_TELEPHONE;

   //         SqlParameter vppParamTI_FAX = new SqlParameter("@TI_FAX", SqlDbType.VarChar, 80);
   //         vppParamTI_FAX.Value = clsMobileSouscription.TI_FAX;

   //         SqlParameter vppParamTI_SITEWEB = new SqlParameter("@TI_SITEWEB", SqlDbType.VarChar, 150);
   //         vppParamTI_SITEWEB.Value = clsMobileSouscription.TI_SITEWEB;

   //         SqlParameter vppParamTI_EMAIL = new SqlParameter("@TI_EMAIL", SqlDbType.VarChar, 80);
   //         vppParamTI_EMAIL.Value = clsMobileSouscription.TI_EMAIL;

   //         SqlParameter vppParamTI_GERANT = new SqlParameter("@TI_GERANT", SqlDbType.VarChar, 150);
   //         vppParamTI_GERANT.Value = clsMobileSouscription.TI_GERANT;

   //         //SqlParameter vppParamTI_STATUT = new SqlParameter("@TI_STATUT", SqlDbType.VarChar, 1);
   //         //vppParamTI_STATUT.Value = clsMobileSouscription.TI_STATUT;

   //         SqlParameter vppParamTI_DATESAISIE = new SqlParameter("@TI_DATESAISIE", SqlDbType.DateTime);
   //         vppParamTI_DATESAISIE.Value = clsMobileSouscription.TI_DATESAISIE;
   //         if (clsMobileSouscription.TI_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamTI_DATESAISIE.Value = "01/01/1900";


   //         SqlParameter vppParamTI_ASDI = new SqlParameter("@TI_ASDI", SqlDbType.VarChar, 1);
   //         vppParamTI_ASDI.Value = clsMobileSouscription.TI_ASDI;

   //         SqlParameter vppParamTI_TVA = new SqlParameter("@TI_TVA", SqlDbType.VarChar, 1);
   //         vppParamTI_TVA.Value = clsMobileSouscription.TI_TVA;

   //         SqlParameter vppParamTI_STATUTDOUTEUX = new SqlParameter("@TI_STATUTDOUTEUX", SqlDbType.Int);
   //         vppParamTI_STATUTDOUTEUX.Value = clsMobileSouscription.TI_STATUTDOUTEUX;

   //         SqlParameter vppParamTI_PLAFONDCREDIT = new SqlParameter("@TI_PLAFONDCREDIT", SqlDbType.Money);
   //         vppParamTI_PLAFONDCREDIT.Value = clsMobileSouscription.TI_PLAFONDCREDIT;

   //         SqlParameter vppParamTI_NUMCPTECONTIBUABLE = new SqlParameter("@TI_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
   //         vppParamTI_NUMCPTECONTIBUABLE.Value = clsMobileSouscription.TI_NUMCPTECONTIBUABLE;

			//SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
			//vppParamOP_CODEOPERATEUR.Value  = clsMobileSouscription.OP_CODEOPERATEUR ;

			//Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere); 
			 this.vapRequete = "UPDATE MobileSouscription SET " +
                            //"SX_CODESEXE = @SX_CODESEXE, "+
                            //"SM_CODESITUATIONMATRIMONIALE = @SM_CODESITUATIONMATRIMONIALE, "+
                            //"PF_CODEPROFESSION = @PF_CODEPROFESSION, "+
                            "TI_IDTIERSPRINCIPAL = @TI_IDTIERSPRINCIPAL, " +
							"AC_CODEACTIVITE = @AC_CODEACTIVITE, "+
							"TP_CODETYPETIERS = @TP_CODETYPETIERS, "+
                            "TC_CODECOMPTETYPETIERS = @TC_CODECOMPTETYPETIERS, " +
							"TI_NUMTIERS = @TI_NUMTIERS, "+
							"TI_DATENAISSANCE = @TI_DATENAISSANCE, "+
							"TI_DENOMINATION = @TI_DENOMINATION, "+
							"TI_DESCRIPTIONTIERS = @TI_DESCRIPTIONTIERS, "+
							"TI_ADRESSEPOSTALE = @TI_ADRESSEPOSTALE, "+
							"TI_ADRESSEGEOGRAPHIQUE = @TI_ADRESSEGEOGRAPHIQUE, "+
							"TI_TELEPHONE = @TI_TELEPHONE, "+
							"TI_FAX = @TI_FAX, "+
							"TI_SITEWEB = @TI_SITEWEB, "+
							"TI_EMAIL = @TI_EMAIL, "+
							"TI_GERANT = @TI_GERANT, "+
							"TI_DATESAISIE = @TI_DATESAISIE, "+
							"TI_ASDI = @TI_ASDI, "+
							"TI_TVA = @TI_TVA, "+
							"TI_STATUTDOUTEUX = @TI_STATUTDOUTEUX, "+
							"TI_PLAFONDCREDIT = @TI_PLAFONDCREDIT, "+
							"TI_NUMCPTECONTIBUABLE = @TI_NUMCPTECONTIBUABLE, "+
							"OP_CODEOPERATEUR = @OP_CODEOPERATEUR " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
   //         vppSqlCmd.Parameters.Add(vppParamTI_IDTIERSPRINCIPAL);
			//vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			//vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
   //         vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
			//vppSqlCmd.Parameters.Add(vppParamTI_NUMTIERS);
			//vppSqlCmd.Parameters.Add(vppParamTI_DATENAISSANCE);
			//vppSqlCmd.Parameters.Add(vppParamTI_DENOMINATION);
			//vppSqlCmd.Parameters.Add(vppParamTI_DESCRIPTIONTIERS);
			//vppSqlCmd.Parameters.Add(vppParamTI_ADRESSEPOSTALE);
			//vppSqlCmd.Parameters.Add(vppParamTI_ADRESSEGEOGRAPHIQUE);
			//vppSqlCmd.Parameters.Add(vppParamTI_TELEPHONE);
			//vppSqlCmd.Parameters.Add(vppParamTI_FAX);
			//vppSqlCmd.Parameters.Add(vppParamTI_SITEWEB);
			//vppSqlCmd.Parameters.Add(vppParamTI_EMAIL);
			//vppSqlCmd.Parameters.Add(vppParamTI_GERANT);
			//vppSqlCmd.Parameters.Add(vppParamTI_DATESAISIE);
			//vppSqlCmd.Parameters.Add(vppParamTI_ASDI);
			//vppSqlCmd.Parameters.Add(vppParamTI_TVA);
			//vppSqlCmd.Parameters.Add(vppParamTI_STATUTDOUTEUX);
			//vppSqlCmd.Parameters.Add(vppParamTI_PLAFONDCREDIT);
			//vppSqlCmd.Parameters.Add(vppParamTI_NUMCPTECONTIBUABLE);
			//vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}






       


       


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EL_CODEELEVE, IN_CODEINSCRIPTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDepartTiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@TI_IDTIERS", "@DATEJOURNEE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            //Préparation de la commande
            this.vapRequete = "EXEC PS_DEPARTTIERS @AG_CODEAGENCE,@TI_IDTIERS,@DATEJOURNEE,@OP_CODEOPERATEUR";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  MobileSouscription "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMobileSouscription </returns>
		///<author>Home Technology</author>
		public List<clsMobileSouscription> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, NT_CODENATURETIERS, TI_SIEGE, AC_CODEACTIVITE, TP_CODETYPETIERS, TI_NUMTIERS, TI_DATENAISSANCE, TI_DENOMINATION, TI_DESCRIPTIONTIERS, TI_ADRESSEPOSTALE, TI_ADRESSEGEOGRAPHIQUE, TI_TELEPHONE, TI_FAX, TI_SITEWEB, TI_EMAIL, TI_GERANT, TI_STATUT, TI_DATESAISIE, TI_ASDI, TI_TVA, TI_STATUTDOUTEUX, TI_PLAFONDCREDIT, TI_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsMobileSouscription> clsMobileSouscriptions = new List<clsMobileSouscription>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
					//clsMobileSouscription.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					//clsMobileSouscription.TI_IDTIERS = clsDonnee.vogDataReader["TI_IDTIERS"].ToString();
     //               clsMobileSouscription.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
     //               clsMobileSouscription.TI_SIEGE = clsDonnee.vogDataReader["TI_SIEGE"].ToString();


                    //clsMobileSouscription.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    //clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    //clsMobileSouscription.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();



					//clsMobileSouscription.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					//clsMobileSouscription.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					//clsMobileSouscription.TI_NUMTIERS = clsDonnee.vogDataReader["TI_NUMTIERS"].ToString();
					//clsMobileSouscription.TI_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATENAISSANCE"].ToString());
					//clsMobileSouscription.TI_DENOMINATION = clsDonnee.vogDataReader["TI_DENOMINATION"].ToString();
					//clsMobileSouscription.TI_DESCRIPTIONTIERS = clsDonnee.vogDataReader["TI_DESCRIPTIONTIERS"].ToString();
					//clsMobileSouscription.TI_ADRESSEPOSTALE = clsDonnee.vogDataReader["TI_ADRESSEPOSTALE"].ToString();
					//clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["TI_ADRESSEGEOGRAPHIQUE"].ToString();
					//clsMobileSouscription.TI_TELEPHONE = clsDonnee.vogDataReader["TI_TELEPHONE"].ToString();
					//clsMobileSouscription.TI_FAX = clsDonnee.vogDataReader["TI_FAX"].ToString();
					//clsMobileSouscription.TI_SITEWEB = clsDonnee.vogDataReader["TI_SITEWEB"].ToString();
					//clsMobileSouscription.TI_EMAIL = clsDonnee.vogDataReader["TI_EMAIL"].ToString();
					//clsMobileSouscription.TI_GERANT = clsDonnee.vogDataReader["TI_GERANT"].ToString();
					//clsMobileSouscription.TI_STATUT = clsDonnee.vogDataReader["TI_STATUT"].ToString();
					//clsMobileSouscription.TI_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["TI_DATESAISIE"].ToString());
					//clsMobileSouscription.TI_ASDI = clsDonnee.vogDataReader["TI_ASDI"].ToString();
					//clsMobileSouscription.TI_TVA = clsDonnee.vogDataReader["TI_TVA"].ToString();
     //               //clsMobileSouscription.TI_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["TI_STATUTDOUTEUX"].ToString());
					//clsMobileSouscription.TI_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["TI_PLAFONDCREDIT"].ToString());
					//clsMobileSouscription.TI_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["TI_NUMCPTECONTIBUABLE"].ToString();
					//clsMobileSouscription.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsMobileSouscriptions.Add(clsMobileSouscription);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsMobileSouscriptions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsMobileSouscription </returns>
		///<author>Home Technology</author>
		public List<clsMobileSouscription> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsMobileSouscription> clsMobileSouscriptions = new List<clsMobileSouscription>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, TI_IDTIERS, NT_CODENATURETIERS, TI_SIEGE, AC_CODEACTIVITE, TP_CODETYPETIERS, TI_NUMTIERS, TI_DATENAISSANCE, TI_DENOMINATION, TI_DESCRIPTIONTIERS, TI_ADRESSEPOSTALE, TI_ADRESSEGEOGRAPHIQUE, TI_TELEPHONE, TI_FAX, TI_SITEWEB, TI_EMAIL, TI_GERANT, TI_STATUT, TI_DATESAISIE, TI_ASDI, TI_TVA, TI_STATUTDOUTEUX, TI_PLAFONDCREDIT, TI_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
					clsMobileSouscription.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsMobileSouscription.TI_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_IDTIERS"].ToString();

     //               clsMobileSouscription.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
     //               clsMobileSouscription.TI_SIEGE = Dataset.Tables["TABLE"].Rows[Idx]["TI_SIEGE"].ToString();

     //               //clsMobileSouscription.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
     //               //clsMobileSouscription.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
     //               //clsMobileSouscription.PF_CODEPROFESSION = Dataset.Tables["TABLE"].Rows[Idx]["PF_CODEPROFESSION"].ToString();

					//clsMobileSouscription.AC_CODEACTIVITE = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEACTIVITE"].ToString();
					//clsMobileSouscription.TP_CODETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPETIERS"].ToString();
					//clsMobileSouscription.TI_NUMTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_NUMTIERS"].ToString();
					//clsMobileSouscription.TI_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_DATENAISSANCE"].ToString());
					//clsMobileSouscription.TI_DENOMINATION = Dataset.Tables["TABLE"].Rows[Idx]["TI_DENOMINATION"].ToString();
					//clsMobileSouscription.TI_DESCRIPTIONTIERS = Dataset.Tables["TABLE"].Rows[Idx]["TI_DESCRIPTIONTIERS"].ToString();
					//clsMobileSouscription.TI_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["TI_ADRESSEPOSTALE"].ToString();
					//clsMobileSouscription.TI_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["TI_ADRESSEGEOGRAPHIQUE"].ToString();
					//clsMobileSouscription.TI_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["TI_TELEPHONE"].ToString();
					//clsMobileSouscription.TI_FAX = Dataset.Tables["TABLE"].Rows[Idx]["TI_FAX"].ToString();
					//clsMobileSouscription.TI_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["TI_SITEWEB"].ToString();
					//clsMobileSouscription.TI_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["TI_EMAIL"].ToString();
					//clsMobileSouscription.TI_GERANT = Dataset.Tables["TABLE"].Rows[Idx]["TI_GERANT"].ToString();
					//clsMobileSouscription.TI_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["TI_STATUT"].ToString();
					//clsMobileSouscription.TI_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_DATESAISIE"].ToString());
					//clsMobileSouscription.TI_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["TI_ASDI"].ToString();
					//clsMobileSouscription.TI_TVA = Dataset.Tables["TABLE"].Rows[Idx]["TI_TVA"].ToString();
					//clsMobileSouscription.TI_STATUTDOUTEUX = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_STATUTDOUTEUX"].ToString());
					//clsMobileSouscription.TI_PLAFONDCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["TI_PLAFONDCREDIT"].ToString());
					//clsMobileSouscription.TI_NUMCPTECONTIBUABLE = Dataset.Tables["TABLE"].Rows[Idx]["TI_NUMCPTECONTIBUABLE"].ToString();
					//clsMobileSouscription.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsMobileSouscriptions.Add(clsMobileSouscription);
				}
				Dataset.Dispose();
			}
		return clsMobileSouscriptions;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            //this.vapRequete = "SELECT *  FROM dbo.MobileSouscription " + this.vapCritere;
            this.vapRequete = "SELECT *  FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgChargerRechercheTiersparNom(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            //vapNomParametre = new string[] { "@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
		

		public DataSet pvgChargerDansDataSetRecherche(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		public DataSet pvgChargerDansDataSetParSexe(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere2(clsDonnee,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet vlpDataset = new DataSet();
            vlpDataset =clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
            return vlpDataset;
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee,vppCritere);
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TP_CODETYPETIERS" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1].Replace("''", "'") };

            
            this.vapRequete = "EXEC PS_CHARGEMENTCOMBOTIERS @AG_CODEAGENCE,@TP_CODETYPETIERS,@CODECRYPTAGE  " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee,vppCritere);
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TP_CODETYPETIERS=@NT_CODENATURETYPETIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@NT_CODENATURETYPETIERS" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1].Replace("''", "'") };


            this.vapRequete = "EXEC PS_CHARGEMENTCOMBOTIERSSELONLANATURETYPETIERS @AG_CODEAGENCE,@NT_CODENATURETYPETIERS,@CODECRYPTAGE  ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgChargerDansDataSetTiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TI_DATESAISIE1", "@TI_DATESAISIE2", "@TP_CODETYPETIERS", "@SC_CODESECTION", "@CU_CODECASUTILISATION", "@OP_CODEOPERATEUREDITION", "@AP_CODEPRODUIT", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11], vppCritere[12] };

            this.vapRequete = "EXEC  [dbo].[PS_MobileSouscription] @AG_CODEAGENCE,@EN_CODEENTREPOT,@TI_STATUT,@TI_NUMTIERS,@TI_DENOMINATION, @TI_DATESAISIE1,@TI_DATESAISIE2,@TP_CODETYPETIERS,@SC_CODESECTION,@CU_CODECASUTILISATION,@OP_CODEOPERATEUREDITION,@AP_CODEPRODUIT,@TYPEOPERATION,@CODECRYPTAGE  ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet vlpDataset = new DataSet();
            vlpDataset = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            return vlpDataset;
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TI_NUMTIERS FROM dbo.FT_MobileSouscription(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

       
        public DataSet pvgControlComptesLies(clsDonnee clsDonnee,  params string[] vppCritere)
        {
            DataSet DataSet = new DataSet();

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@PL_NUMCOMPTEGENERAL", "@TI_NUMTIERS", "@NC_CODENATURECOMPTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };


            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PS_CONTROLCOMPTELIE]   @PL_NUMCOMPTEGENERAL, @TI_NUMTIERS, @NC_CODENATURECOMPTE, @CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            return DataSet;
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = " WHERE TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_IDTIERS", "@TP_CODETYPETIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
				break;
			}
		}


        public void pvpChoixCritereRecherche(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = "";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT = 'N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS=@TI_NUMTIERS AND TI_STATUT = 'N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+ @TI_NUMTIERS +'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+ @TI_NUMTIERS +'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+ @TI_NUMTIERS +'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

                case 6:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+ @TI_NUMTIERS +'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%' AND  ISNULL(CU_CODECASUTILISATION,'') LIKE '%'+@CU_CODECASUTILISATION+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION", "@CU_CODECASUTILISATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] };
                    break;
            }
        }



        //      public void pvpChoixCritereRecherche(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //	switch (vppCritere.Length) 
        //	 {
        //		case 0 :
        //		this.vapCritere ="";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
        //		break;
        //		case 1 :
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT = 'N'";
        //		vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
        //		break;
        //		case 2 :
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND [dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,TI_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')=@TI_NUMTIERS AND TI_STATUT = 'N'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@TI_NUMTIERS" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
        //		break;
        //		case 3 :
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+ [dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,TI_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')+'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
        //		break;
        //              case 4:
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,TI_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')+'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' ";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
        //              break;

        //              case 5:
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,TI_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')+'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4]};
        //              break;

        //              case 6:
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS like '%'+[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,TI_NUMTIERS,'" + clsDonnee.vogCleCryptage + "')+'%' AND TI_DENOMINATION like '%'+ @TI_DENOMINATION +'%' AND TI_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%' AND  ISNULL(CU_CODECASUTILISATION,'') LIKE '%'+@CU_CODECASUTILISATION+'%'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION", "@CU_CODECASUTILISATION" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4], vppCritere[5]};
        //              break;
        //	}
        //}






        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEZenithMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public DataSet pvgSouscriptionMobileBanking(clsDonnee clsDonnee, string LG_CODELANGUE, string AG_CODEAGENCE, string TI_IDTIERS, string SO_CODESOUSCRIPTION, string PY_CODEPAYS, string SO_TELEPHONE, string DATEJOURNEE, string SO_EMAIL, string SO_LIEURESIDENCE, string TYPEOPERATION)
        {
            List<clsMobileSouscription> clsMobileSouscriptions = new List<clsMobileSouscription>();
            DataSet Dataset = new DataSet();
            string SO_DATESOUSCRIPRION = DATEJOURNEE;
            string SO_DATEDESACTIVATION = "01/01/1900";
            if (TYPEOPERATION == "02")
                SO_DATEDESACTIVATION = DATEJOURNEE;


            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";
            vapNomParametre = new string[] { "@LG_CODELANGUE", "@AG_CODEAGENCE", "@TI_IDTIERS", "@SO_CODESOUSCRIPTION", "@PY_CODEPAYS", "@SO_TELEPHONE", "@SO_DATESOUSCRIPRION", "@SO_DATEDESACTIVATION", "@SO_EMAIL", "@SO_LIEURESIDENCE",  "@CODECRYPTAGE", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { LG_CODELANGUE, AG_CODEAGENCE, TI_IDTIERS, SO_CODESOUSCRIPTION, PY_CODEPAYS, SO_TELEPHONE, SO_DATESOUSCRIPRION, SO_DATEDESACTIVATION, SO_EMAIL, SO_LIEURESIDENCE,  clsDonnee.vogCleCryptage, TYPEOPERATION };
            this.vapRequete = "EXEC  [dbo].[PS_MOBILESOUSCRIPTIONMOBILEBANKING] @LG_CODELANGUE , @AG_CODEAGENCE, @TI_IDTIERS, @SO_CODESOUSCRIPTION,@PY_CODEPAYS, @SO_TELEPHONE , @SO_DATESOUSCRIPRION , @SO_DATEDESACTIVATION , @SO_EMAIL, @SO_LIEURESIDENCE,  @CODECRYPTAGE,@TYPEOPERATION"; //+ this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);


            //String.IsNullOrEmpty(vppValeurAFormater.Trim())) return "";

            //if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            //{
            //    for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
            //    {
            //        //clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //        clsMobileSouscription clsMobileSouscription = new clsMobileSouscription();
            //        clsMobileSouscription.SL_NOM = Dataset.Tables["TABLE"].Rows[Idx]["SL_NOM"].ToString();
            //        clsMobileSouscription.SL_PRENOMS = Dataset.Tables["TABLE"].Rows[Idx]["SL_PRENOMS"].ToString();
            //        clsMobileSouscription..SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
            //        clsMobileSouscription.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
            //        clsMobileSouscription.SL_CODEMESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_CODEMESSAGE"].ToString();
            //        clsMobileSouscriptions.Add(clsMobileSouscription);

            //    }
            //    Dataset.Dispose();
            //}
            return Dataset;
        }




        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEZenithMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public DataSet pvgCompteMobileMappe(clsDonnee clsDonnee, string LG_CODELANGUE, string AG_CODEAGENCE, string TI_IDTIERS,  string TYPEOPERATION)
        {
            //List<clsNumeroMobileMappe> clsNumeroMobileMappes = new List<clsNumeroMobileMappe>();
            DataSet Dataset = new DataSet();

            
            //this.vapCritere = "WHERE SL_LOGIN=@SL_LOGIN AND SL_MOTPASSE=@SL_MOTPASSE";
            vapNomParametre = new string[] { "@LG_CODELANGUE", "@AG_CODEAGENCE", "@TI_IDTIERS", "@TYPEOPERATION", "@CODECRYPTAGE" };
            vapValeurParametre = new object[] { LG_CODELANGUE, AG_CODEAGENCE, TI_IDTIERS, TYPEOPERATION, clsDonnee.vogCleCryptage };
            this.vapRequete = "EXEC  [dbo].[PS_MOBILELISTENUMEROMAPPE] @LG_CODELANGUE , @AG_CODEAGENCE, @TI_IDTIERS,@TYPEOPERATION,  @CODECRYPTAGE"; //+ this.vapCritere;
            this.vapCritere = ""; SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, Dataset);


            //String.IsNullOrEmpty(vppValeurAFormater.Trim())) return "";

            //if (int.Parse(clsDonnee.vagNombreLigneRequete) > 0)
            //{
            //    for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
            //    {
            //        clsMiccompteweb clsMiccompteweb = new clsMiccompteweb();
            //        clsNumeroMobileMappe clsNumeroMobileMappe = new clsNumeroMobileMappe();
            //        clsNumeroMobileMappe.SO_CODESOUSCRIPTION = Dataset.Tables["TABLE"].Rows[Idx]["SO_CODESOUSCRIPTION"].ToString();
            //        clsNumeroMobileMappe.SO_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["SO_TELEPHONE"].ToString();
            //        clsNumeroMobileMappe.CO_CODECOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["CO_CODECOMPTE"].ToString();
            //        clsNumeroMobileMappe.NUMEROCOMPTE = Dataset.Tables["TABLE"].Rows[Idx]["NUMEROCOMPTE"].ToString();
            //        clsNumeroMobileMappe.IDF = Dataset.Tables["TABLE"].Rows[Idx]["IDF"].ToString();
            //        clsNumeroMobileMappe.SL_RESULTAT = Dataset.Tables["TABLE"].Rows[Idx]["SL_RESULTAT"].ToString();
            //        clsNumeroMobileMappe.SL_MESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_MESSAGE"].ToString();
            //        clsNumeroMobileMappe.SL_CODEMESSAGE = Dataset.Tables["TABLE"].Rows[Idx]["SL_CODEMESSAGE"].ToString();
            //        clsNumeroMobileMappes.Add(clsNumeroMobileMappe);
            //    }
            //    Dataset.Dispose();
            //}
            return Dataset;
        }


        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = " WHERE TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_IDTIERS=@TI_IDTIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@TI_IDTIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
				break;

                case 4:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%'AND TI_TELEPHONE LIKE '%'+@TI_TELEPHONE+'%' AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TI_TELEPHONE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                break;
                case 5:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%'AND TI_TELEPHONE LIKE '%'+@TI_TELEPHONE+'%'  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_NUMTIERS", "@TI_DENOMINATION", "@TI_TELEPHONE", "@TP_CODETYPETIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                break;

			}
		}

		public void pvpChoixCritere2( clsDonnee clsDonnee,params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = " WHERE TI_DATEDEPART='01/01/1900' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, };
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;

                case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT AND TI_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                break;

                case 4:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT  AND TI_STATUT=@TI_STATUT  AND TI_NUMTIERS LIKE @TI_NUMTIERS'%' AND TI_DATEDEPART='01/01/1900'";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3]};
                //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
                break;

                case 5:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT  AND TI_NUMTIERS LIKE @TI_NUMTIERS'%'AND TI_DENOMINATION LIKE @TI_DENOMINATION'%' AND TI_DATEDEPART='01/01/1900'";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
                break;


                case 7:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT  AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TI_DATEDEPART='01/01/1900' ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6]  };
                //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                break;

                //case 7:
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%'    ";
                ////this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] , vppCritere[6]  };
                ////vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                ////vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                //break;


                case 8:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%'  AND TI_DATEDEPART='01/01/1900'   ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };
                
                break;



                case 9:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[8], "CU_CODECASUTILISATION") + ") AND TI_DATEDEPART='01/01/1900'   ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS", "@CU_CODECASUTILISATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] , vppCritere[8] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[8], 9, "CU_CODECASUTILISATION");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 9, "CU_CODECASUTILISATION");
                break;

                //case 8:
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%'    ";
                ////this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                ////vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                ////vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                //break;

                //case 8:

                //if (vppCritere[6] == "07" && vppCritere[7] == "CLT")
                //{
                //    vppCritere[6] = "001";
                //    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS =@TP_CODETYPETIERS    ";
                //}
                //else
                //if (vppCritere[6] != "07" && vppCritere[7] == "ALL")
                //{
                //    vppCritere[6] = "";
                //    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS +'%'      ";
                //}
                //else
                //{
                //    vppCritere[6] = "001";
                //    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS !=@TP_CODETYPETIERS    ";
                //}
                ////this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                ////vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                ////vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                //break;


                case 10:

                if (vppCritere[7] == "07" && vppCritere[8] == "CLT")
                {
                    vppCritere[7] = "001";
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS =@TP_CODETYPETIERS AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[9], "CU_CODECASUTILISATION") + ") AND TI_DATEDEPART='01/01/1900'  ";
                }
                else
                    if (vppCritere[7] != "07" && vppCritere[8] == "ALL")
                    {
                        vppCritere[7] = "";
                        this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS +'%'   AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[9], "CU_CODECASUTILISATION") + ")  AND TI_DATEDEPART='01/01/1900' ";
                    }
                    else
                    {
                        vppCritere[7] = "001";
                        this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE   AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND TI_STATUT=@TI_STATUT AND TI_NUMTIERS LIKE '%'+@TI_NUMTIERS+'%' AND TI_DENOMINATION LIKE '%'+@TI_DENOMINATION+'%' AND TI_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS !=@TP_CODETYPETIERS AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[9], "CU_CODECASUTILISATION") + ")   AND TI_DATEDEPART='01/01/1900' ";
                    }
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT=@TI_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@TI_STATUT", "@TI_NUMTIERS", "@TI_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS", "@CU_CODECASUTILISATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[9] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[9], 9, "CU_CODECASUTILISATION");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 9, "CU_CODECASUTILISATION");
                break;



			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, TI_IDTIERS, TP_CODETYPETIERS)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = " WHERE TI_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TP_CODETYPETIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND TI_IDTIERS=@TI_IDTIERS AND TI_STATUT = 'N' AND TI_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TP_CODETYPETIERS", "@TI_IDTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }


	}
}
