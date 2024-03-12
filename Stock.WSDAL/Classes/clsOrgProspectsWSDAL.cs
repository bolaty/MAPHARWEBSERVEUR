using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;

namespace Stock.WSDAL
{
	public class clsOrgProspectsWSDAL: ITableDAL<clsOrgProspects>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private string[] vapNomParametre = new string[]{};
		private object[] vapValeurParametre = new object[]{};

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteCount(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT COUNT(PR_NUMTIERS) AS PR_NUMTIERS  FROM dbo.ORGPROSPECTS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMin(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MIN(PR_IDTIERS) AS PR_IDTIERS  FROM dbo.ORGPROSPECTS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValueScalarRequeteMax(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(PR_IDTIERS) AS PR_IDTIERS  FROM dbo.ORGPROSPECTS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}
		public string pvgValueScalarRequeteMax1(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT MAX(PR_NUMTIERS) AS PR_NUMTIERS  FROM dbo.ORGPROSPECTS " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgValueScalarRequete(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsOrgProspects pvgTableLabel(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritereRecherche(clsDonnee, vppCritere);
            pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PR_IDTIERS,PR_NUMTIERS, AC_CODEACTIVITE,TP_CODETYPETIERS,PR_DATENAISSANCE,PR_DENOMINATION,PR_DESCRIPTIONTIERS,PR_ADRESSEPOSTALE,PR_ADRESSEGEOGRAPHIQUE,PR_TELEPHONE,PR_FAX,PR_SITEWEB,PR_EMAIL,PR_GERANT,PR_STATUT,PR_DATESAISIE,PR_ASDI,PR_TVA,PR_STATUTDOUTEUX,PR_PLAFONDCREDIT,PR_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,PR_SIEGE,PL_NUMCOMPTE FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsOrgProspects clsOrgProspects = new clsOrgProspects();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
                    //clsOrgProspects.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    clsOrgProspects.PR_IDTIERS = clsDonnee.vogDataReader["PR_IDTIERS"].ToString();
                    clsOrgProspects.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
                    clsOrgProspects.PR_SIEGE = clsDonnee.vogDataReader["PR_SIEGE"].ToString();
                    //clsOrgProspects.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    //clsOrgProspects.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
					clsOrgProspects.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					clsOrgProspects.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsOrgProspects.PR_NUMTIERS = clsDonnee.vogDataReader["PR_NUMTIERS"].ToString();
					clsOrgProspects.PR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATENAISSANCE"].ToString());
					clsOrgProspects.PR_DENOMINATION = clsDonnee.vogDataReader["PR_DENOMINATION"].ToString();
					clsOrgProspects.PR_DESCRIPTIONTIERS = clsDonnee.vogDataReader["PR_DESCRIPTIONTIERS"].ToString();
					clsOrgProspects.PR_ADRESSEPOSTALE = clsDonnee.vogDataReader["PR_ADRESSEPOSTALE"].ToString();
					clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsOrgProspects.PR_TELEPHONE = clsDonnee.vogDataReader["PR_TELEPHONE"].ToString();
					clsOrgProspects.PR_FAX = clsDonnee.vogDataReader["PR_FAX"].ToString();
					clsOrgProspects.PR_SITEWEB = clsDonnee.vogDataReader["PR_SITEWEB"].ToString();
					clsOrgProspects.PR_EMAIL = clsDonnee.vogDataReader["PR_EMAIL"].ToString();
					clsOrgProspects.PR_GERANT = clsDonnee.vogDataReader["PR_GERANT"].ToString();
					clsOrgProspects.PR_STATUT = clsDonnee.vogDataReader["PR_STATUT"].ToString();
					clsOrgProspects.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
					clsOrgProspects.PR_ASDI = clsDonnee.vogDataReader["PR_ASDI"].ToString();
					clsOrgProspects.PR_TVA = clsDonnee.vogDataReader["PR_TVA"].ToString();
                    //clsOrgProspects.PR_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["PR_STATUTDOUTEUX"].ToString());
					clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["PR_PLAFONDCREDIT"].ToString());
					clsOrgProspects.PR_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["PR_NUMCPTECONTIBUABLE"].ToString();
					clsOrgProspects.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsOrgProspects.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
				}
				clsDonnee.vogDataReader.Dispose();
			}
		return clsOrgProspects;
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsOrgProspects pvgTableLabelVENTE(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            //pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PR_IDTIERS,PR_NUMTIERS, AC_CODEACTIVITE,TP_CODETYPETIERS,PR_DATENAISSANCE,PR_DENOMINATION,PR_DESCRIPTIONTIERS,PR_ADRESSEPOSTALE,PR_ADRESSEGEOGRAPHIQUE,PR_TELEPHONE,PR_FAX,PR_SITEWEB,PR_EMAIL,PR_GERANT,PR_STATUT,PR_DATESAISIE,PR_ASDI,PR_TVA,PR_STATUTDOUTEUX,PR_PLAFONDCREDIT,PR_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,PR_SIEGE,PL_NUMCOMPTE,PY_CODEPAYS FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsOrgProspects clsOrgProspects = new clsOrgProspects();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    //clsOrgProspects.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    clsOrgProspects.PR_IDTIERS = clsDonnee.vogDataReader["PR_IDTIERS"].ToString();
                    clsOrgProspects.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
                    clsOrgProspects.PR_SIEGE = clsDonnee.vogDataReader["PR_SIEGE"].ToString();
                    //clsOrgProspects.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    //clsOrgProspects.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
                    clsOrgProspects.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
                    clsOrgProspects.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
                    clsOrgProspects.PR_NUMTIERS = clsDonnee.vogDataReader["PR_NUMTIERS"].ToString();
                    clsOrgProspects.PR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATENAISSANCE"].ToString());
                    clsOrgProspects.PR_DENOMINATION = clsDonnee.vogDataReader["PR_DENOMINATION"].ToString();
                    clsOrgProspects.PR_DESCRIPTIONTIERS = clsDonnee.vogDataReader["PR_DESCRIPTIONTIERS"].ToString();
                    clsOrgProspects.PR_ADRESSEPOSTALE = clsDonnee.vogDataReader["PR_ADRESSEPOSTALE"].ToString();
                    clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PR_ADRESSEGEOGRAPHIQUE"].ToString();
                    clsOrgProspects.PR_TELEPHONE = clsDonnee.vogDataReader["PR_TELEPHONE"].ToString();
                    clsOrgProspects.PR_FAX = clsDonnee.vogDataReader["PR_FAX"].ToString();
                    clsOrgProspects.PR_SITEWEB = clsDonnee.vogDataReader["PR_SITEWEB"].ToString();
                    clsOrgProspects.PR_EMAIL = clsDonnee.vogDataReader["PR_EMAIL"].ToString();
                    clsOrgProspects.PR_GERANT = clsDonnee.vogDataReader["PR_GERANT"].ToString();
                    clsOrgProspects.PR_STATUT = clsDonnee.vogDataReader["PR_STATUT"].ToString();
                    clsOrgProspects.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
                    clsOrgProspects.PR_ASDI = clsDonnee.vogDataReader["PR_ASDI"].ToString();
                    clsOrgProspects.PR_TVA = clsDonnee.vogDataReader["PR_TVA"].ToString();
                    //clsOrgProspects.PR_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["PR_STATUTDOUTEUX"].ToString());
                    clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["PR_PLAFONDCREDIT"].ToString());
                    clsOrgProspects.PR_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["PR_NUMCPTECONTIBUABLE"].ToString();
                    clsOrgProspects.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsOrgProspects.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    clsOrgProspects.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOrgProspects;
        }




        //public clsOrgProspects pvgTableLabelVENTE(clsDonnee clsDonnee, params string[] vppCritere)
        //{
        //    pvpChoixCritereRecherche(clsDonnee, vppCritere);
        //    //pvpChoixCritere3(clsDonnee, vppCritere);
        //    this.vapRequete = "SELECT PR_IDTIERS,[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,PR_NUMTIERS,'" + clsDonnee.vogCleCryptage + "'), AC_CODEACTIVITE,TP_CODETYPETIERS,PR_DATENAISSANCE,DECRYPTBYPASSPHRASE('" + clsDonnee.vogCleCryptage + "',PR_DENOMINATION) AS varchar(150)) AS  PR_DENOMINATION,PR_DESCRIPTIONTIERS,PR_ADRESSEPOSTALE,PR_ADRESSEGEOGRAPHIQUE,PR_TELEPHONE,PR_FAX,PR_SITEWEB,PR_EMAIL,PR_GERANT,PR_STATUT,PR_DATESAISIE,PR_ASDI,PR_TVA,PR_STATUTDOUTEUX,PR_PLAFONDCREDIT,PR_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,PR_SIEGE,PL_NUMCOMPTE,PY_CODEPAYS FROM dbo.VUE_ORGPROSPECTS  " + this.vapCritere;
        //    this.vapCritere = "";
        //    SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
        //    clsOrgProspects clsOrgProspects = new clsOrgProspects();
        //    if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
        //    {
        //        while (clsDonnee.vogDataReader.Read())
        //        {
        //            //clsOrgProspects.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
        //            clsOrgProspects.PR_IDTIERS = clsDonnee.vogDataReader["PR_IDTIERS"].ToString();
        //            clsOrgProspects.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
        //            clsOrgProspects.PR_SIEGE = clsDonnee.vogDataReader["PR_SIEGE"].ToString();
        //            //clsOrgProspects.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
        //            //clsOrgProspects.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
        //            clsOrgProspects.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
        //            clsOrgProspects.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
        //            clsOrgProspects.PR_NUMTIERS = clsDonnee.vogDataReader["PR_NUMTIERS"].ToString();
        //            clsOrgProspects.PR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATENAISSANCE"].ToString());
        //            clsOrgProspects.PR_DENOMINATION = clsDonnee.vogDataReader["PR_DENOMINATION"].ToString();
        //            clsOrgProspects.PR_DESCRIPTIONTIERS = clsDonnee.vogDataReader["PR_DESCRIPTIONTIERS"].ToString();
        //            clsOrgProspects.PR_ADRESSEPOSTALE = clsDonnee.vogDataReader["PR_ADRESSEPOSTALE"].ToString();
        //            clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PR_ADRESSEGEOGRAPHIQUE"].ToString();
        //            clsOrgProspects.PR_TELEPHONE = clsDonnee.vogDataReader["PR_TELEPHONE"].ToString();
        //            clsOrgProspects.PR_FAX = clsDonnee.vogDataReader["PR_FAX"].ToString();
        //            clsOrgProspects.PR_SITEWEB = clsDonnee.vogDataReader["PR_SITEWEB"].ToString();
        //            clsOrgProspects.PR_EMAIL = clsDonnee.vogDataReader["PR_EMAIL"].ToString();
        //            clsOrgProspects.PR_GERANT = clsDonnee.vogDataReader["PR_GERANT"].ToString();
        //            clsOrgProspects.PR_STATUT = clsDonnee.vogDataReader["PR_STATUT"].ToString();
        //            clsOrgProspects.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
        //            clsOrgProspects.PR_ASDI = clsDonnee.vogDataReader["PR_ASDI"].ToString();
        //            clsOrgProspects.PR_TVA = clsDonnee.vogDataReader["PR_TVA"].ToString();
        //            //clsOrgProspects.PR_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["PR_STATUTDOUTEUX"].ToString());
        //            clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["PR_PLAFONDCREDIT"].ToString());
        //            clsOrgProspects.PR_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["PR_NUMCPTECONTIBUABLE"].ToString();
        //            clsOrgProspects.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
        //            clsOrgProspects.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
        //            clsOrgProspects.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
        //        }
        //        clsDonnee.vogDataReader.Dispose();
        //    }
        //    return clsOrgProspects;
        //}







        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsOrgProspects comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsOrgProspects pvgTableLabelVENTECaisse(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere1(clsDonnee, vppCritere);
            //pvpChoixCritere3(clsDonnee, vppCritere);
            this.vapRequete = "SELECT TOP 1 PR_IDTIERS,PR_NUMTIERS, AC_CODEACTIVITE,TP_CODETYPETIERS,PR_DATENAISSANCE,PR_DENOMINATION,PR_DESCRIPTIONTIERS,PR_ADRESSEPOSTALE,PR_ADRESSEGEOGRAPHIQUE,PR_TELEPHONE,PR_FAX,PR_SITEWEB,PR_EMAIL,PR_GERANT,PR_STATUT,PR_DATESAISIE,PR_ASDI,PR_TVA,PR_STATUTDOUTEUX,PR_PLAFONDCREDIT,PR_NUMCPTECONTIBUABLE,OP_CODEOPERATEUR,NT_CODENATURETIERS,PR_SIEGE,PL_NUMCOMPTE,PY_CODEPAYS FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsOrgProspects clsOrgProspects = new clsOrgProspects();
            if (clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
            {
                while (clsDonnee.vogDataReader.Read())
                {
                    //clsOrgProspects.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    clsOrgProspects.PR_IDTIERS = clsDonnee.vogDataReader["PR_IDTIERS"].ToString();
                    clsOrgProspects.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
                    clsOrgProspects.PR_SIEGE = clsDonnee.vogDataReader["PR_SIEGE"].ToString();
                    //clsOrgProspects.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    //clsOrgProspects.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();
                    clsOrgProspects.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
                    clsOrgProspects.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
                    clsOrgProspects.PR_NUMTIERS = clsDonnee.vogDataReader["PR_NUMTIERS"].ToString();
                    clsOrgProspects.PR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATENAISSANCE"].ToString());
                    clsOrgProspects.PR_DENOMINATION = clsDonnee.vogDataReader["PR_DENOMINATION"].ToString();
                    clsOrgProspects.PR_DESCRIPTIONTIERS = clsDonnee.vogDataReader["PR_DESCRIPTIONTIERS"].ToString();
                    clsOrgProspects.PR_ADRESSEPOSTALE = clsDonnee.vogDataReader["PR_ADRESSEPOSTALE"].ToString();
                    clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PR_ADRESSEGEOGRAPHIQUE"].ToString();
                    clsOrgProspects.PR_TELEPHONE = clsDonnee.vogDataReader["PR_TELEPHONE"].ToString();
                    clsOrgProspects.PR_FAX = clsDonnee.vogDataReader["PR_FAX"].ToString();
                    clsOrgProspects.PR_SITEWEB = clsDonnee.vogDataReader["PR_SITEWEB"].ToString();
                    clsOrgProspects.PR_EMAIL = clsDonnee.vogDataReader["PR_EMAIL"].ToString();
                    clsOrgProspects.PR_GERANT = clsDonnee.vogDataReader["PR_GERANT"].ToString();
                    clsOrgProspects.PR_STATUT = clsDonnee.vogDataReader["PR_STATUT"].ToString();
                    clsOrgProspects.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
                    clsOrgProspects.PR_ASDI = clsDonnee.vogDataReader["PR_ASDI"].ToString();
                    clsOrgProspects.PR_TVA = clsDonnee.vogDataReader["PR_TVA"].ToString();
                    //clsOrgProspects.PR_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["PR_STATUTDOUTEUX"].ToString());
                    clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["PR_PLAFONDCREDIT"].ToString());
                    clsOrgProspects.PR_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["PR_NUMCPTECONTIBUABLE"].ToString();
                    clsOrgProspects.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
                    clsOrgProspects.PL_NUMCOMPTE = clsDonnee.vogDataReader["PL_NUMCOMPTE"].ToString();
                    clsOrgProspects.PY_CODEPAYS = clsDonnee.vogDataReader["PY_CODEPAYS"].ToString();
                }
                clsDonnee.vogDataReader.Dispose();
            }
            return clsOrgProspects;
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOrgProspects>clsOrgProspects</param>
		///<author>Home Technology</author>
		public void pvgInsert(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects)
		{
			//Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar,5);
            vppParamAG_CODEAGENCE.Value = clsOrgProspects.AG_CODEAGENCE;

            SqlParameter vppParamPR_IDTIERS = new SqlParameter("@PR_IDTIERS", SqlDbType.BigInt);
            vppParamPR_IDTIERS.Value = clsOrgProspects.PR_IDTIERS;

            SqlParameter vppParamPR_IDTIERSPRINCIPAL = new SqlParameter("@PR_IDTIERSPRINCIPAL", SqlDbType.BigInt);
            vppParamPR_IDTIERSPRINCIPAL.Value = clsOrgProspects.PR_IDTIERSPRINCIPAL;
            if(clsOrgProspects.PR_IDTIERSPRINCIPAL=="") vppParamPR_IDTIERSPRINCIPAL.Value = DBNull.Value;

            SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 5);
            vppParamNT_CODENATURETIERS.Value = clsOrgProspects.NT_CODENATURETIERS;

            SqlParameter vppParamPR_SIEGE = new SqlParameter("@PR_SIEGE", SqlDbType.VarChar,150);
            vppParamPR_SIEGE.Value = clsOrgProspects.PR_SIEGE;
            if (clsOrgProspects.PR_SIEGE == "")
                vppParamPR_SIEGE.Value = DBNull.Value;

            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsOrgProspects.SX_CODESEXE;
            if (clsOrgProspects.SX_CODESEXE == "")
                vppParamSX_CODESEXE.Value = DBNull.Value;

            SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 2);
            vppParamFM_CODEFORMEJURIDIQUE.Value = clsOrgProspects.FM_CODEFORMEJURIDIQUE;
            if (clsOrgProspects.FM_CODEFORMEJURIDIQUE == "")
                vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;


            //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsOrgProspects.SM_CODESITUATIONMATRIMONIALE;
            //if (clsOrgProspects.SM_CODESITUATIONMATRIMONIALE == "")
            //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


            //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            //vppParamPF_CODEPROFESSION.Value = clsOrgProspects.PF_CODEPROFESSION;
            //if (clsOrgProspects.PF_CODEPROFESSION == "")
            //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;


            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsOrgProspects.AC_CODEACTIVITE;
            if (clsOrgProspects.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;


            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPETIERS.Value = clsOrgProspects.TP_CODETYPETIERS;

            SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
            vppParamTC_CODECOMPTETYPETIERS.Value = clsOrgProspects.TC_CODECOMPTETYPETIERS;
            if (clsOrgProspects.TC_CODECOMPTETYPETIERS == "")
                vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamPR_NUMTIERS = new SqlParameter("@PR_NUMTIERS", SqlDbType.VarChar, 7);
            vppParamPR_NUMTIERS.Value = clsOrgProspects.PR_NUMTIERS;

            SqlParameter vppParamPR_DATENAISSANCE = new SqlParameter("@PR_DATENAISSANCE", SqlDbType.DateTime);
            vppParamPR_DATENAISSANCE.Value = clsOrgProspects.PR_DATENAISSANCE;
            if (clsOrgProspects.PR_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamPR_DATENAISSANCE.Value = "01/01/1900";

            SqlParameter vppParamPR_DENOMINATION = new SqlParameter("@PR_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamPR_DENOMINATION.Value = clsOrgProspects.PR_DENOMINATION;

            SqlParameter vppParamPR_DESCRIPTIONTIERS = new SqlParameter("@PR_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
            vppParamPR_DESCRIPTIONTIERS.Value = clsOrgProspects.PR_DESCRIPTIONTIERS;

            SqlParameter vppParamPR_ADRESSEPOSTALE = new SqlParameter("@PR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEPOSTALE.Value = clsOrgProspects.PR_ADRESSEPOSTALE;

            SqlParameter vppParamPR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@PR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEGEOGRAPHIQUE.Value = clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamPR_TELEPHONE = new SqlParameter("@PR_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamPR_TELEPHONE.Value = clsOrgProspects.PR_TELEPHONE;

            SqlParameter vppParamPR_FAX = new SqlParameter("@PR_FAX", SqlDbType.VarChar, 80);
            vppParamPR_FAX.Value = clsOrgProspects.PR_FAX;

            SqlParameter vppParamPR_SITEWEB = new SqlParameter("@PR_SITEWEB", SqlDbType.VarChar, 150);
            vppParamPR_SITEWEB.Value = clsOrgProspects.PR_SITEWEB;

            SqlParameter vppParamPR_EMAIL = new SqlParameter("@PR_EMAIL", SqlDbType.VarChar, 80);
            vppParamPR_EMAIL.Value = clsOrgProspects.PR_EMAIL;

            SqlParameter vppParamPR_GERANT = new SqlParameter("@PR_GERANT", SqlDbType.VarChar, 150);
            vppParamPR_GERANT.Value = clsOrgProspects.PR_GERANT;

            //SqlParameter vppParamPR_STATUT = new SqlParameter("@PR_STATUT", SqlDbType.VarChar, 1);
            //vppParamPR_STATUT.Value = clsOrgProspects.PR_STATUT;

            SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
            vppParamPR_DATESAISIE.Value = clsOrgProspects.PR_DATESAISIE;
            if (clsOrgProspects.PR_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamPR_DATESAISIE.Value = "01/01/1900";

            SqlParameter vppParamPR_ASDI = new SqlParameter("@PR_ASDI", SqlDbType.VarChar, 1);
            vppParamPR_ASDI.Value = clsOrgProspects.PR_ASDI;

            SqlParameter vppParamPR_TVA = new SqlParameter("@PR_TVA", SqlDbType.VarChar, 1);
            vppParamPR_TVA.Value = clsOrgProspects.PR_TVA;

            SqlParameter vppParamPR_STATUTDOUTEUX = new SqlParameter("@PR_STATUTDOUTEUX", SqlDbType.Int);
            vppParamPR_STATUTDOUTEUX.Value = clsOrgProspects.PR_STATUTDOUTEUX;

            SqlParameter vppParamPR_PLAFONDCREDIT = new SqlParameter("@PR_PLAFONDCREDIT", SqlDbType.Money);
            vppParamPR_PLAFONDCREDIT.Value = clsOrgProspects.PR_PLAFONDCREDIT;

            SqlParameter vppParamPR_NUMCPTECONTIBUABLE = new SqlParameter("@PR_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamPR_NUMCPTECONTIBUABLE.Value = clsOrgProspects.PR_NUMCPTECONTIBUABLE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsOrgProspects.OP_CODEOPERATEUR;
            SqlParameter vppParamPR_TAUXREMISE = new SqlParameter("@PR_TAUXREMISE", SqlDbType.Float);
            vppParamPR_TAUXREMISE.Value = clsOrgProspects.PR_TAUXREMISE;

            SqlParameter vppParamPR_TAUXDECLARATION = new SqlParameter("@PR_TAUXDECLARATION", SqlDbType.Float);
            vppParamPR_TAUXDECLARATION.Value = clsOrgProspects.PR_TAUXDECLARATION;
			//Préparation de la commande
            this.vapRequete = "INSERT INTO ORGPROSPECTS (  AG_CODEAGENCE, PR_IDTIERS,PR_IDTIERSPRINCIPAL, NT_CODENATURETIERS, PR_SIEGE,SX_CODESEXE,FM_CODEFORMEJURIDIQUE,AC_CODEACTIVITE, TP_CODETYPETIERS,TC_CODECOMPTETYPETIERS, PR_NUMTIERS, PR_DATENAISSANCE, PR_DENOMINATION, PR_DESCRIPTIONTIERS, PR_ADRESSEPOSTALE, PR_ADRESSEGEOGRAPHIQUE, PR_TELEPHONE, PR_FAX, PR_SITEWEB, PR_EMAIL, PR_GERANT, PR_DATESAISIE, PR_ASDI, PR_TVA, PR_STATUTDOUTEUX, PR_PLAFONDCREDIT, PR_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR, PR_TAUXREMISE,PR_TAUXDECLARATION) " +
                     "VALUES ( @AG_CODEAGENCE, @PR_IDTIERS,  @PR_IDTIERSPRINCIPAL, @NT_CODENATURETIERS, @PR_SIEGE,@SX_CODESEXE,@FM_CODEFORMEJURIDIQUE,@AC_CODEACTIVITE, @TP_CODETYPETIERS,@TC_CODECOMPTETYPETIERS, @PR_NUMTIERS, @PR_DATENAISSANCE, @PR_DENOMINATION, @PR_DESCRIPTIONTIERS, @PR_ADRESSEPOSTALE, @PR_ADRESSEGEOGRAPHIQUE, @PR_TELEPHONE, @PR_FAX, @PR_SITEWEB, @PR_EMAIL, @PR_GERANT, @PR_DATESAISIE, @PR_ASDI, @PR_TVA, @PR_STATUTDOUTEUX, @PR_PLAFONDCREDIT, @PR_NUMCPTECONTIBUABLE, @OP_CODEOPERATEUR, @PR_TAUXREMISE,@PR_TAUXDECLARATION) ";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
			vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
			vppSqlCmd.Parameters.Add(vppParamPR_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERSPRINCIPAL);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_SIEGE);


            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
            //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMTIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_DATENAISSANCE);
			vppSqlCmd.Parameters.Add(vppParamPR_DENOMINATION);
			vppSqlCmd.Parameters.Add(vppParamPR_DESCRIPTIONTIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamPR_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamPR_FAX);
			vppSqlCmd.Parameters.Add(vppParamPR_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamPR_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamPR_GERANT);
			vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamPR_ASDI);
			vppSqlCmd.Parameters.Add(vppParamPR_TVA);
			vppSqlCmd.Parameters.Add(vppParamPR_STATUTDOUTEUX);
			vppSqlCmd.Parameters.Add(vppParamPR_PLAFONDCREDIT);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMCPTECONTIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamPR_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamPR_TAUXDECLARATION);
			//Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsOrgProspects>clsOrgProspects</param>
        ///<author>Home Technology</author>
        public string pvgMiseajour(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOrgProspects.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsOrgProspects.EN_CODEENTREPOT;

            SqlParameter vppParamPR_IDTIERS = new SqlParameter("@PR_IDTIERS", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERS.Value = clsOrgProspects.PR_IDTIERS;

            SqlParameter vppParamPR_IDTIERSPRINCIPAL = new SqlParameter("@PR_IDTIERSPRINCIPAL", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERSPRINCIPAL.Value = clsOrgProspects.PR_IDTIERSPRINCIPAL;
            if(vppParamPR_IDTIERSPRINCIPAL.Value=="")vppParamPR_IDTIERSPRINCIPAL.Value = DBNull.Value;

            

            SqlParameter vppParamNT_CODENATURETYPETIERS = new SqlParameter("@NT_CODENATURETYPETIERS", SqlDbType.VarChar, 2);
            vppParamNT_CODENATURETYPETIERS.Value = clsOrgProspects.NT_CODENATURETYPETIERS;
            if (clsOrgProspects.NT_CODENATURETYPETIERS == "") vppParamNT_CODENATURETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 5);
            vppParamNT_CODENATURETIERS.Value = clsOrgProspects.NT_CODENATURETIERS;

            SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 8);
            vppParamPY_CODEPAYS.Value = clsOrgProspects.PY_CODEPAYS;
            if (clsOrgProspects.PY_CODEPAYS == "") vppParamPY_CODEPAYS.Value = DBNull.Value;

            SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
            vppParamVL_CODEVILLE.Value = clsOrgProspects.VL_CODEVILLE;
            if (clsOrgProspects.VL_CODEVILLE == "") vppParamVL_CODEVILLE.Value = DBNull.Value;


            SqlParameter vppParamPR_SIEGE = new SqlParameter("@PR_SIEGE", SqlDbType.VarChar, 150);
            vppParamPR_SIEGE.Value = clsOrgProspects.PR_SIEGE;
            if (clsOrgProspects.PR_SIEGE == "")
                vppParamPR_SIEGE.Value = DBNull.Value;



            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsOrgProspects.SX_CODESEXE;
            if (clsOrgProspects.SX_CODESEXE == "")
                vppParamSX_CODESEXE.Value = DBNull.Value;

            SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 2);
            vppParamFM_CODEFORMEJURIDIQUE.Value = clsOrgProspects.FM_CODEFORMEJURIDIQUE;
            if (clsOrgProspects.FM_CODEFORMEJURIDIQUE == "")
                vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;

            //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsOrgProspects.SM_CODESITUATIONMATRIMONIALE;
            //if (clsOrgProspects.SM_CODESITUATIONMATRIMONIALE == "")
            //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


            //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            //vppParamPF_CODEPROFESSION.Value = clsOrgProspects.PF_CODEPROFESSION;
            //if (clsOrgProspects.PF_CODEPROFESSION == "")
            //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;


            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsOrgProspects.AC_CODEACTIVITE;
            if (clsOrgProspects.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;


            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPETIERS.Value = clsOrgProspects.TP_CODETYPETIERS;


            SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
            vppParamTC_CODECOMPTETYPETIERS.Value = clsOrgProspects.TC_CODECOMPTETYPETIERS;
            if (clsOrgProspects.TC_CODECOMPTETYPETIERS == "")
                vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;


            SqlParameter vppParamPR_NUMTIERS = new SqlParameter("@PR_NUMTIERS", SqlDbType.VarChar, 50);
            vppParamPR_NUMTIERS.Value = clsOrgProspects.PR_NUMTIERS;

            SqlParameter vppParamPR_DATENAISSANCE = new SqlParameter("@PR_DATENAISSANCE", SqlDbType.DateTime);
            vppParamPR_DATENAISSANCE.Value = clsOrgProspects.PR_DATENAISSANCE;
            if (clsOrgProspects.PR_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamPR_DATENAISSANCE.Value = "01/01/1900";


            SqlParameter vppParamPR_DENOMINATION = new SqlParameter("@PR_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamPR_DENOMINATION.Value = clsOrgProspects.PR_DENOMINATION;

            SqlParameter vppParamPR_DESCRIPTIONTIERS = new SqlParameter("@PR_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
            vppParamPR_DESCRIPTIONTIERS.Value = clsOrgProspects.PR_DESCRIPTIONTIERS;

            SqlParameter vppParamPR_ADRESSEPOSTALE = new SqlParameter("@PR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEPOSTALE.Value = clsOrgProspects.PR_ADRESSEPOSTALE;

            SqlParameter vppParamPR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@PR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEGEOGRAPHIQUE.Value = clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamPR_TELEPHONE = new SqlParameter("@PR_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamPR_TELEPHONE.Value = clsOrgProspects.PR_TELEPHONE;

            SqlParameter vppParamPR_FAX = new SqlParameter("@PR_FAX", SqlDbType.VarChar, 80);
            vppParamPR_FAX.Value = clsOrgProspects.PR_FAX;

            SqlParameter vppParamPR_SITEWEB = new SqlParameter("@PR_SITEWEB", SqlDbType.VarChar, 150);
            vppParamPR_SITEWEB.Value = clsOrgProspects.PR_SITEWEB;

            SqlParameter vppParamPR_EMAIL = new SqlParameter("@PR_EMAIL", SqlDbType.VarChar, 150);
            vppParamPR_EMAIL.Value = clsOrgProspects.PR_EMAIL;

            SqlParameter vppParamPR_GERANT = new SqlParameter("@PR_GERANT", SqlDbType.VarChar, 150);
            vppParamPR_GERANT.Value = clsOrgProspects.PR_GERANT;

            SqlParameter vppParamPR_STATUT = new SqlParameter("@PR_STATUT", SqlDbType.VarChar, 1);
            vppParamPR_STATUT.Value = clsOrgProspects.PR_STATUT;

            SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
            vppParamPR_DATESAISIE.Value = clsOrgProspects.PR_DATESAISIE;
            if (clsOrgProspects.PR_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamPR_DATESAISIE.Value = "01/01/1900";

            SqlParameter vppParamPR_DATEDEPART = new SqlParameter("@PR_DATEDEPART", SqlDbType.DateTime);
            vppParamPR_DATEDEPART.Value = clsOrgProspects.PR_DATEDEPART;
            if (clsOrgProspects.PR_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamPR_DATEDEPART.Value = "01/01/1900";

            SqlParameter vppParamPR_ASDI = new SqlParameter("@PR_ASDI", SqlDbType.VarChar, 1);
            vppParamPR_ASDI.Value = clsOrgProspects.PR_ASDI;

            SqlParameter vppParamPR_TVA = new SqlParameter("@PR_TVA", SqlDbType.VarChar, 1);
            vppParamPR_TVA.Value = clsOrgProspects.PR_TVA;

            SqlParameter vppParamPR_STATUTDOUTEUX = new SqlParameter("@PR_STATUTDOUTEUX", SqlDbType.Int);
            vppParamPR_STATUTDOUTEUX.Value = clsOrgProspects.PR_STATUTDOUTEUX;

            SqlParameter vppParamPR_PLAFONDCREDIT = new SqlParameter("@PR_PLAFONDCREDIT", SqlDbType.Money);
            vppParamPR_PLAFONDCREDIT.Value = clsOrgProspects.PR_PLAFONDCREDIT;

            SqlParameter vppParamPR_NUMCPTECONTIBUABLE = new SqlParameter("@PR_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamPR_NUMCPTECONTIBUABLE.Value = clsOrgProspects.PR_NUMCPTECONTIBUABLE;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsOrgProspects.OP_CODEOPERATEUR;

            SqlParameter vppParamPR_PHOTO = new SqlParameter("@PR_PHOTO", SqlDbType.VarBinary);
            vppParamPR_PHOTO.Value = clsOrgProspects.PR_PHOTO;
            if (clsOrgProspects.PR_PHOTO == null) vppParamPR_PHOTO.Value = DBNull.Value;


            SqlParameter vppParamPR_SIGNATURE = new SqlParameter("@PR_SIGNATURE", SqlDbType.VarBinary);
            vppParamPR_SIGNATURE.Value = clsOrgProspects.PR_SIGNATURE;
            if (clsOrgProspects.PR_SIGNATURE == null) vppParamPR_SIGNATURE.Value = DBNull.Value;


            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsOrgProspects.PL_NUMCOMPTE;
            SqlParameter vppParamPR_TAUXREMISE = new SqlParameter("@PR_TAUXREMISE", SqlDbType.Float);
            vppParamPR_TAUXREMISE.Value = clsOrgProspects.PR_TAUXREMISE;

            SqlParameter vppParamCU_CODECASUTILISATION = new SqlParameter("@CU_CODECASUTILISATION", SqlDbType.VarChar, 3);
            vppParamCU_CODECASUTILISATION.Value = clsOrgProspects.CU_CODECASUTILISATION;

            if (clsOrgProspects.CU_CODECASUTILISATION == "")
                vppParamCU_CODECASUTILISATION.Value = DBNull.Value;

            SqlParameter vppParamPR_NUMEROAGREMENT = new SqlParameter("@PR_NUMEROAGREMENT", SqlDbType.VarChar, 150);
            vppParamPR_NUMEROAGREMENT.Value = clsOrgProspects.PR_NUMEROAGREMENT;
            if (clsOrgProspects.PR_NUMEROAGREMENT == "") vppParamPR_NUMEROAGREMENT.Value = DBNull.Value;
            SqlParameter vppParamPR_TAUXDECLARATION = new SqlParameter("@PR_TAUXDECLARATION", SqlDbType.Float);
            vppParamPR_TAUXDECLARATION.Value = clsOrgProspects.PR_TAUXDECLARATION;

            SqlParameter vppParamGP_CODEGROUPE = new SqlParameter("@GP_CODEGROUPE", SqlDbType.VarChar, 4);
            vppParamGP_CODEGROUPE.Value = clsOrgProspects.GP_CODEGROUPE;
            if (clsOrgProspects.GP_CODEGROUPE == "")
                vppParamGP_CODEGROUPE.Value = DBNull.Value;

            SqlParameter vppParamPR_MANDATAIRE = new SqlParameter("@PR_MANDATAIRE", SqlDbType.VarChar, 150);
            vppParamPR_MANDATAIRE.Value = clsOrgProspects.PR_MANDATAIRE;
            if (clsOrgProspects.PR_MANDATAIRE == "")
                vppParamPR_MANDATAIRE.Value = DBNull.Value;

            SqlParameter vppParamPR_USAGER = new SqlParameter("@PR_USAGER", SqlDbType.VarChar, 150);
            vppParamPR_USAGER.Value = clsOrgProspects.PR_USAGER;
            if (clsOrgProspects.PR_USAGER == "")
                vppParamPR_USAGER.Value = DBNull.Value;


        SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 150);
            vppParamIN_CODEINGREDIENT.Value = clsOrgProspects.IN_CODEINGREDIENT;
        if (clsOrgProspects.IN_CODEINGREDIENT == "")
                vppParamIN_CODEINGREDIENT.Value = DBNull.Value;

            SqlParameter vppParamPR_ESCOMPTE = new SqlParameter("@PR_ESCOMPTE", SqlDbType.VarChar, 1);
            vppParamPR_ESCOMPTE.Value = clsOrgProspects.PR_ESCOMPTE;

            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;
            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsOrgProspects.TYPEOPERATION;


            SqlParameter vppParamPR_NUMTIERSRETOUR = new SqlParameter("@PR_NUMTIERSRETOUR", SqlDbType.VarChar, 50);

            SqlCommand vppSqlCmd = new SqlCommand("PC_ORGPROSPECTSWF", clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            vppSqlCmd.CommandType = CommandType.StoredProcedure;

            ////Préparation de la commande
            //this.vapRequete = " EXECUTE [dbo].[PC_ORGPROSPECTSWF]   @AG_CODEAGENCE, @PR_IDTIERS, @NT_CODENATURETIERS,@PY_CODEPAYS,@VL_CODEVILLE, @PR_SIEGE, @AC_CODEACTIVITE, @TP_CODETYPETIERS, @PR_NUMTIERS,  @PR_DATENAISSANCE, @PR_DENOMINATION, @PR_DESCRIPTIONTIERS, @PR_ADRESSEPOSTALE, @PR_ADRESSEGEOGRAPHIQUE, @PR_TELEPHONE, @PR_FAX, @PR_SITEWEB, @PR_EMAIL, @PR_GERANT, @PR_STATUT,  @PR_DATESAISIE, @PR_ASDI, @PR_TVA , @PR_STATUTDOUTEUX,  @PR_PLAFONDCREDIT,@PR_NUMCPTECONTIBUABLE,@OP_CODEOPERATEUR,@PR_DATEDEPART,@PR_PHOTO,@PL_NUMCOMPTE,@PR_TAUXREMISE,@CU_CODECASUTILISATION,@PR_NUMEROAGREMENT,@PR_TAUXDECLARATION,@CODECRYPTAGE,@TYPEOPERATION";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERSPRINCIPAL);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
            vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
            vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
            vppSqlCmd.Parameters.Add(vppParamPR_SIEGE);



            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
            //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamPR_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamPR_DESCRIPTIONTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamPR_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamPR_FAX);
            vppSqlCmd.Parameters.Add(vppParamPR_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamPR_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamPR_GERANT);
            vppSqlCmd.Parameters.Add(vppParamPR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamPR_ASDI);
            vppSqlCmd.Parameters.Add(vppParamPR_TVA);
            vppSqlCmd.Parameters.Add(vppParamPR_STATUTDOUTEUX);
            vppSqlCmd.Parameters.Add(vppParamPR_PLAFONDCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPR_NUMCPTECONTIBUABLE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamPR_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamPR_PHOTO);
            vppSqlCmd.Parameters.Add(vppParamPR_SIGNATURE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPR_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECASUTILISATION);
            vppSqlCmd.Parameters.Add(vppParamPR_NUMEROAGREMENT);
            vppSqlCmd.Parameters.Add(vppParamPR_TAUXDECLARATION);
            vppSqlCmd.Parameters.Add(vppParamGP_CODEGROUPE);
            vppSqlCmd.Parameters.Add(vppParamPR_MANDATAIRE);
            vppSqlCmd.Parameters.Add(vppParamPR_USAGER);
            vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
            vppSqlCmd.Parameters.Add(vppParamPR_ESCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);
            vppSqlCmd.Parameters.Add(vppParamPR_NUMTIERSRETOUR);
            vppParamPR_NUMTIERSRETOUR.Direction = ParameterDirection.Output;

            ////Ouverture de la connection et exécution de la commande
            //clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
            // valeurs de retour de la procedure stockée
            return vppSqlCmd.Parameters["@PR_NUMTIERSRETOUR"].Value.ToString();
        }



		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name=clsOrgProspects>clsOrgProspects</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgUpdate(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects,params string[] vppCritere)
		{
			//Préparation des paramètres
            //SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            //vppParamSX_CODESEXE.Value = clsOrgProspects.SX_CODESEXE;

            //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsOrgProspects.SM_CODESITUATIONMATRIMONIALE;
            //if (clsOrgProspects.SM_CODESITUATIONMATRIMONIALE == "")
            //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;

            //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            //vppParamPF_CODEPROFESSION.Value = clsOrgProspects.PF_CODEPROFESSION;
            //if (clsOrgProspects.PF_CODEPROFESSION == "")
            //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;

            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsOrgProspects.AC_CODEACTIVITE;
            if (clsOrgProspects.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;

            SqlParameter vppParamPR_IDTIERSPRINCIPAL = new SqlParameter("@PR_IDTIERSPRINCIPAL", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERSPRINCIPAL.Value = clsOrgProspects.PR_IDTIERSPRINCIPAL;
            if (clsOrgProspects.PR_IDTIERSPRINCIPAL == "")
                vppParamPR_IDTIERSPRINCIPAL.Value = DBNull.Value;

            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPETIERS.Value = clsOrgProspects.TP_CODETYPETIERS;

            SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
            vppParamTC_CODECOMPTETYPETIERS.Value = clsOrgProspects.TC_CODECOMPTETYPETIERS;
            if (clsOrgProspects.TC_CODECOMPTETYPETIERS == "")
                vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamPR_NUMTIERS = new SqlParameter("@PR_NUMTIERS", SqlDbType.VarChar, 7);
            vppParamPR_NUMTIERS.Value = clsOrgProspects.PR_NUMTIERS;

            SqlParameter vppParamPR_DATENAISSANCE = new SqlParameter("@PR_DATENAISSANCE", SqlDbType.DateTime);
            vppParamPR_DATENAISSANCE.Value = clsOrgProspects.PR_DATENAISSANCE;
            if(clsOrgProspects.PR_DATENAISSANCE<DateTime.Parse("01/01/1900")) vppParamPR_DATENAISSANCE.Value ="01/01/1900";

            SqlParameter vppParamPR_DENOMINATION = new SqlParameter("@PR_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamPR_DENOMINATION.Value = clsOrgProspects.PR_DENOMINATION;

            SqlParameter vppParamPR_DESCRIPTIONTIERS = new SqlParameter("@PR_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
            vppParamPR_DESCRIPTIONTIERS.Value = clsOrgProspects.PR_DESCRIPTIONTIERS;

            SqlParameter vppParamPR_ADRESSEPOSTALE = new SqlParameter("@PR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEPOSTALE.Value = clsOrgProspects.PR_ADRESSEPOSTALE;

            SqlParameter vppParamPR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@PR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEGEOGRAPHIQUE.Value = clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE;

            SqlParameter vppParamPR_TELEPHONE = new SqlParameter("@PR_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamPR_TELEPHONE.Value = clsOrgProspects.PR_TELEPHONE;

            SqlParameter vppParamPR_FAX = new SqlParameter("@PR_FAX", SqlDbType.VarChar, 80);
            vppParamPR_FAX.Value = clsOrgProspects.PR_FAX;

            SqlParameter vppParamPR_SITEWEB = new SqlParameter("@PR_SITEWEB", SqlDbType.VarChar, 150);
            vppParamPR_SITEWEB.Value = clsOrgProspects.PR_SITEWEB;

            SqlParameter vppParamPR_EMAIL = new SqlParameter("@PR_EMAIL", SqlDbType.VarChar, 150);
            vppParamPR_EMAIL.Value = clsOrgProspects.PR_EMAIL;

            SqlParameter vppParamPR_GERANT = new SqlParameter("@PR_GERANT", SqlDbType.VarChar, 150);
            vppParamPR_GERANT.Value = clsOrgProspects.PR_GERANT;

            //SqlParameter vppParamPR_STATUT = new SqlParameter("@PR_STATUT", SqlDbType.VarChar, 1);
            //vppParamPR_STATUT.Value = clsOrgProspects.PR_STATUT;

            SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
            vppParamPR_DATESAISIE.Value = clsOrgProspects.PR_DATESAISIE;
            if (clsOrgProspects.PR_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamPR_DATESAISIE.Value = "01/01/1900";


            SqlParameter vppParamPR_ASDI = new SqlParameter("@PR_ASDI", SqlDbType.VarChar, 1);
            vppParamPR_ASDI.Value = clsOrgProspects.PR_ASDI;

            SqlParameter vppParamPR_TVA = new SqlParameter("@PR_TVA", SqlDbType.VarChar, 1);
            vppParamPR_TVA.Value = clsOrgProspects.PR_TVA;

            SqlParameter vppParamPR_STATUTDOUTEUX = new SqlParameter("@PR_STATUTDOUTEUX", SqlDbType.Int);
            vppParamPR_STATUTDOUTEUX.Value = clsOrgProspects.PR_STATUTDOUTEUX;

            SqlParameter vppParamPR_PLAFONDCREDIT = new SqlParameter("@PR_PLAFONDCREDIT", SqlDbType.Money);
            vppParamPR_PLAFONDCREDIT.Value = clsOrgProspects.PR_PLAFONDCREDIT;

            SqlParameter vppParamPR_NUMCPTECONTIBUABLE = new SqlParameter("@PR_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamPR_NUMCPTECONTIBUABLE.Value = clsOrgProspects.PR_NUMCPTECONTIBUABLE;

			SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
			vppParamOP_CODEOPERATEUR.Value  = clsOrgProspects.OP_CODEOPERATEUR ;

			//Préparation de la commande
            pvpChoixCritere(clsDonnee, vppCritere); 
			 this.vapRequete = "UPDATE ORGPROSPECTS SET " +
                            //"SX_CODESEXE = @SX_CODESEXE, "+
                            //"SM_CODESITUATIONMATRIMONIALE = @SM_CODESITUATIONMATRIMONIALE, "+
                            //"PF_CODEPROFESSION = @PF_CODEPROFESSION, "+
                            "PR_IDTIERSPRINCIPAL = @PR_IDTIERSPRINCIPAL, " +
							"AC_CODEACTIVITE = @AC_CODEACTIVITE, "+
							"TP_CODETYPETIERS = @TP_CODETYPETIERS, "+
                            "TC_CODECOMPTETYPETIERS = @TC_CODECOMPTETYPETIERS, " +
							"PR_NUMTIERS = @PR_NUMTIERS, "+
							"PR_DATENAISSANCE = @PR_DATENAISSANCE, "+
							"PR_DENOMINATION = @PR_DENOMINATION, "+
							"PR_DESCRIPTIONTIERS = @PR_DESCRIPTIONTIERS, "+
							"PR_ADRESSEPOSTALE = @PR_ADRESSEPOSTALE, "+
							"PR_ADRESSEGEOGRAPHIQUE = @PR_ADRESSEGEOGRAPHIQUE, "+
							"PR_TELEPHONE = @PR_TELEPHONE, "+
							"PR_FAX = @PR_FAX, "+
							"PR_SITEWEB = @PR_SITEWEB, "+
							"PR_EMAIL = @PR_EMAIL, "+
							"PR_GERANT = @PR_GERANT, "+
							"PR_DATESAISIE = @PR_DATESAISIE, "+
							"PR_ASDI = @PR_ASDI, "+
							"PR_TVA = @PR_TVA, "+
							"PR_STATUTDOUTEUX = @PR_STATUTDOUTEUX, "+
							"PR_PLAFONDCREDIT = @PR_PLAFONDCREDIT, "+
							"PR_NUMCPTECONTIBUABLE = @PR_NUMCPTECONTIBUABLE, "+
							"OP_CODEOPERATEUR = @OP_CODEOPERATEUR " + vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ajout des paramètre à la commande
            //vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERSPRINCIPAL);
			vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
			vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMTIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_DATENAISSANCE);
			vppSqlCmd.Parameters.Add(vppParamPR_DENOMINATION);
			vppSqlCmd.Parameters.Add(vppParamPR_DESCRIPTIONTIERS);
			vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEPOSTALE);
			vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEGEOGRAPHIQUE);
			vppSqlCmd.Parameters.Add(vppParamPR_TELEPHONE);
			vppSqlCmd.Parameters.Add(vppParamPR_FAX);
			vppSqlCmd.Parameters.Add(vppParamPR_SITEWEB);
			vppSqlCmd.Parameters.Add(vppParamPR_EMAIL);
			vppSqlCmd.Parameters.Add(vppParamPR_GERANT);
			vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
			vppSqlCmd.Parameters.Add(vppParamPR_ASDI);
			vppSqlCmd.Parameters.Add(vppParamPR_TVA);
			vppSqlCmd.Parameters.Add(vppParamPR_STATUTDOUTEUX);
			vppSqlCmd.Parameters.Add(vppParamPR_PLAFONDCREDIT);
			vppSqlCmd.Parameters.Add(vppParamPR_NUMCPTECONTIBUABLE);
			vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}






        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name=clsOrgProspects>clsOrgProspects</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgMiseajourNumero(clsDonnee clsDonnee, clsOrgProspects clsOrgProspects)
        {
            //Préparation des paramètres
            SqlParameter vppParamAG_CODEAGENCE = new SqlParameter("@AG_CODEAGENCE", SqlDbType.VarChar, 25);
            vppParamAG_CODEAGENCE.Value = clsOrgProspects.AG_CODEAGENCE;

            SqlParameter vppParamEN_CODEENTREPOT = new SqlParameter("@EN_CODEENTREPOT", SqlDbType.VarChar, 25);
            vppParamEN_CODEENTREPOT.Value = clsOrgProspects.EN_CODEENTREPOT;

            SqlParameter vppParamPR_IDTIERS = new SqlParameter("@PR_IDTIERS", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERS.Value = clsOrgProspects.PR_IDTIERS;

            SqlParameter vppParamPR_IDTIERSPRINCIPAL = new SqlParameter("@PR_IDTIERSPRINCIPAL", SqlDbType.VarChar, 25);
            vppParamPR_IDTIERSPRINCIPAL.Value = clsOrgProspects.PR_IDTIERSPRINCIPAL;

            SqlParameter vppParamNT_CODENATURETYPETIERS = new SqlParameter("@NT_CODENATURETYPETIERS", SqlDbType.VarChar, 2);
            vppParamNT_CODENATURETYPETIERS.Value = clsOrgProspects.NT_CODENATURETYPETIERS;
            if (clsOrgProspects.NT_CODENATURETYPETIERS == "")
                vppParamNT_CODENATURETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamNT_CODENATURETIERS = new SqlParameter("@NT_CODENATURETIERS", SqlDbType.VarChar, 5);
            vppParamNT_CODENATURETIERS.Value = clsOrgProspects.NT_CODENATURETIERS;
            if (clsOrgProspects.NT_CODENATURETIERS == "")
                vppParamNT_CODENATURETIERS.Value = DBNull.Value;


            SqlParameter vppParamPY_CODEPAYS = new SqlParameter("@PY_CODEPAYS", SqlDbType.VarChar, 8);
            vppParamPY_CODEPAYS.Value = clsOrgProspects.PY_CODEPAYS;
            if (clsOrgProspects.PY_CODEPAYS == "") vppParamPY_CODEPAYS.Value = DBNull.Value;

            SqlParameter vppParamVL_CODEVILLE = new SqlParameter("@VL_CODEVILLE", SqlDbType.VarChar, 8);
            vppParamVL_CODEVILLE.Value = clsOrgProspects.VL_CODEVILLE;
            if (clsOrgProspects.VL_CODEVILLE == "")
                vppParamVL_CODEVILLE.Value = DBNull.Value;


            SqlParameter vppParamPR_SIEGE = new SqlParameter("@PR_SIEGE", SqlDbType.VarChar, 150);
            vppParamPR_SIEGE.Value = clsOrgProspects.PR_SIEGE;
            if (clsOrgProspects.PR_SIEGE == "")
                vppParamPR_SIEGE.Value = DBNull.Value;


            SqlParameter vppParamSX_CODESEXE = new SqlParameter("@SX_CODESEXE", SqlDbType.VarChar, 2);
            vppParamSX_CODESEXE.Value = clsOrgProspects.SX_CODESEXE;
            if (clsOrgProspects.SX_CODESEXE == "")
                vppParamSX_CODESEXE.Value = DBNull.Value;

            SqlParameter vppParamFM_CODEFORMEJURIDIQUE = new SqlParameter("@FM_CODEFORMEJURIDIQUE", SqlDbType.VarChar, 2);
            vppParamFM_CODEFORMEJURIDIQUE.Value = clsOrgProspects.FM_CODEFORMEJURIDIQUE;
            if (clsOrgProspects.FM_CODEFORMEJURIDIQUE == "")
                vppParamFM_CODEFORMEJURIDIQUE.Value = DBNull.Value;

            //SqlParameter vppParamSM_CODESITUATIONMATRIMONIALE = new SqlParameter("@SM_CODESITUATIONMATRIMONIALE", SqlDbType.VarChar, 2);
            //vppParamSM_CODESITUATIONMATRIMONIALE.Value = clsOrgProspects.SM_CODESITUATIONMATRIMONIALE;
            //if (clsOrgProspects.SM_CODESITUATIONMATRIMONIALE == "")
            //    vppParamSM_CODESITUATIONMATRIMONIALE.Value = DBNull.Value;


            //SqlParameter vppParamPF_CODEPROFESSION = new SqlParameter("@PF_CODEPROFESSION", SqlDbType.VarChar, 4);
            //vppParamPF_CODEPROFESSION.Value = clsOrgProspects.PF_CODEPROFESSION;
            //if (clsOrgProspects.PF_CODEPROFESSION == "")
            //    vppParamPF_CODEPROFESSION.Value = DBNull.Value;


            SqlParameter vppParamAC_CODEACTIVITE = new SqlParameter("@AC_CODEACTIVITE", SqlDbType.VarChar, 4);
            vppParamAC_CODEACTIVITE.Value = clsOrgProspects.AC_CODEACTIVITE;
            if (clsOrgProspects.AC_CODEACTIVITE == "")
                vppParamAC_CODEACTIVITE.Value = DBNull.Value;


            SqlParameter vppParamTP_CODETYPETIERS = new SqlParameter("@TP_CODETYPETIERS", SqlDbType.VarChar, 3);
            vppParamTP_CODETYPETIERS.Value = clsOrgProspects.TP_CODETYPETIERS;
            if (clsOrgProspects.TP_CODETYPETIERS == "")
                vppParamTP_CODETYPETIERS.Value = DBNull.Value;

            SqlParameter vppParamTC_CODECOMPTETYPETIERS = new SqlParameter("@TC_CODECOMPTETYPETIERS", SqlDbType.VarChar, 4);
            vppParamTC_CODECOMPTETYPETIERS.Value = clsOrgProspects.TC_CODECOMPTETYPETIERS;
            if (clsOrgProspects.TC_CODECOMPTETYPETIERS == "")
                vppParamTC_CODECOMPTETYPETIERS.Value = DBNull.Value;


            SqlParameter vppParamPR_NUMTIERS = new SqlParameter("@PR_NUMTIERS", SqlDbType.VarChar, 50);
            vppParamPR_NUMTIERS.Value = clsOrgProspects.PR_NUMTIERS;

            SqlParameter vppParamPR_DATENAISSANCE = new SqlParameter("@PR_DATENAISSANCE", SqlDbType.DateTime);
            vppParamPR_DATENAISSANCE.Value = clsOrgProspects.PR_DATENAISSANCE;
            if (clsOrgProspects.PR_DATENAISSANCE < DateTime.Parse("01/01/1900")) vppParamPR_DATENAISSANCE.Value = "01/01/1900";


            SqlParameter vppParamPR_DENOMINATION = new SqlParameter("@PR_DENOMINATION", SqlDbType.VarChar, 150);
            vppParamPR_DENOMINATION.Value = clsOrgProspects.PR_DENOMINATION;
            if (clsOrgProspects.PR_DENOMINATION == "")
                vppParamPR_DENOMINATION.Value = DBNull.Value;

            SqlParameter vppParamPR_DESCRIPTIONTIERS = new SqlParameter("@PR_DESCRIPTIONTIERS", SqlDbType.VarChar, 150);
            vppParamPR_DESCRIPTIONTIERS.Value = clsOrgProspects.PR_DESCRIPTIONTIERS;
            if (clsOrgProspects.PR_DESCRIPTIONTIERS == "")
                vppParamPR_DESCRIPTIONTIERS.Value = DBNull.Value;

            SqlParameter vppParamPR_ADRESSEPOSTALE = new SqlParameter("@PR_ADRESSEPOSTALE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEPOSTALE.Value = clsOrgProspects.PR_ADRESSEPOSTALE;
            if (clsOrgProspects.PR_ADRESSEPOSTALE == "")
                vppParamPR_ADRESSEPOSTALE.Value = DBNull.Value;

            SqlParameter vppParamPR_ADRESSEGEOGRAPHIQUE = new SqlParameter("@PR_ADRESSEGEOGRAPHIQUE", SqlDbType.VarChar, 150);
            vppParamPR_ADRESSEGEOGRAPHIQUE.Value = clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE;
            if (clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE == "")
                vppParamPR_ADRESSEGEOGRAPHIQUE.Value = DBNull.Value;

            SqlParameter vppParamPR_TELEPHONE = new SqlParameter("@PR_TELEPHONE", SqlDbType.VarChar, 80);
            vppParamPR_TELEPHONE.Value = clsOrgProspects.PR_TELEPHONE;
            if (clsOrgProspects.PR_TELEPHONE == "")
                vppParamPR_TELEPHONE.Value = DBNull.Value;

            SqlParameter vppParamPR_FAX = new SqlParameter("@PR_FAX", SqlDbType.VarChar, 80);
            vppParamPR_FAX.Value = clsOrgProspects.PR_FAX;
            if (clsOrgProspects.PR_FAX == "")
                vppParamPR_FAX.Value = DBNull.Value;

            SqlParameter vppParamPR_SITEWEB = new SqlParameter("@PR_SITEWEB", SqlDbType.VarChar, 150);
            vppParamPR_SITEWEB.Value = clsOrgProspects.PR_SITEWEB;
            if (clsOrgProspects.PR_SITEWEB == "")
                vppParamPR_SITEWEB.Value = DBNull.Value;

            SqlParameter vppParamPR_EMAIL = new SqlParameter("@PR_EMAIL", SqlDbType.VarChar, 80);
            vppParamPR_EMAIL.Value = clsOrgProspects.PR_EMAIL;
            if (clsOrgProspects.PR_EMAIL == "")
                vppParamPR_EMAIL.Value = DBNull.Value;

            SqlParameter vppParamPR_GERANT = new SqlParameter("@PR_GERANT", SqlDbType.VarChar, 150);
            vppParamPR_GERANT.Value = clsOrgProspects.PR_GERANT;
            if (clsOrgProspects.PR_GERANT == "")
                vppParamPR_GERANT.Value = DBNull.Value;

            SqlParameter vppParamPR_STATUT = new SqlParameter("@PR_STATUT", SqlDbType.VarChar, 1);
            vppParamPR_STATUT.Value = clsOrgProspects.PR_STATUT;
            if (clsOrgProspects.PR_STATUT == "")
                vppParamPR_STATUT.Value = DBNull.Value;

            SqlParameter vppParamPR_DATESAISIE = new SqlParameter("@PR_DATESAISIE", SqlDbType.DateTime);
            vppParamPR_DATESAISIE.Value = clsOrgProspects.PR_DATESAISIE;
            if (clsOrgProspects.PR_DATESAISIE < DateTime.Parse("01/01/1900")) vppParamPR_DATESAISIE.Value = "01/01/1900";

            SqlParameter vppParamPR_DATEDEPART = new SqlParameter("@PR_DATEDEPART", SqlDbType.DateTime);
            vppParamPR_DATEDEPART.Value = clsOrgProspects.PR_DATEDEPART;
            if (clsOrgProspects.PR_DATEDEPART < DateTime.Parse("01/01/1900")) vppParamPR_DATEDEPART.Value = "01/01/1900";

            SqlParameter vppParamPR_ASDI = new SqlParameter("@PR_ASDI", SqlDbType.VarChar, 1);
            vppParamPR_ASDI.Value = clsOrgProspects.PR_ASDI;
            if (clsOrgProspects.PR_ASDI == "")
                vppParamPR_ASDI.Value = DBNull.Value;

            SqlParameter vppParamPR_TVA = new SqlParameter("@PR_TVA", SqlDbType.VarChar, 1);
            vppParamPR_TVA.Value = clsOrgProspects.PR_TVA;
            if (clsOrgProspects.PR_TVA == "")
                vppParamPR_TVA.Value = DBNull.Value;

            SqlParameter vppParamPR_STATUTDOUTEUX = new SqlParameter("@PR_STATUTDOUTEUX", SqlDbType.Int);
            vppParamPR_STATUTDOUTEUX.Value = clsOrgProspects.PR_STATUTDOUTEUX;
           

            SqlParameter vppParamPR_PLAFONDCREDIT = new SqlParameter("@PR_PLAFONDCREDIT", SqlDbType.Money);
            vppParamPR_PLAFONDCREDIT.Value = clsOrgProspects.PR_PLAFONDCREDIT;

            SqlParameter vppParamPR_NUMCPTECONTIBUABLE = new SqlParameter("@PR_NUMCPTECONTIBUABLE", SqlDbType.VarChar, 50);
            vppParamPR_NUMCPTECONTIBUABLE.Value = clsOrgProspects.PR_NUMCPTECONTIBUABLE;
            if (clsOrgProspects.PR_NUMCPTECONTIBUABLE == "")
                vppParamPR_NUMCPTECONTIBUABLE.Value = DBNull.Value;

            SqlParameter vppParamOP_CODEOPERATEUR = new SqlParameter("@OP_CODEOPERATEUR", SqlDbType.VarChar, 10);
            vppParamOP_CODEOPERATEUR.Value = clsOrgProspects.OP_CODEOPERATEUR;
            if (clsOrgProspects.OP_CODEOPERATEUR == "")
                vppParamOP_CODEOPERATEUR.Value = DBNull.Value;

            SqlParameter vppParamPR_PHOTO = new SqlParameter("@PR_PHOTO", SqlDbType.VarBinary);
            vppParamPR_PHOTO.Value = clsOrgProspects.PR_PHOTO;
            if (clsOrgProspects.PR_PHOTO == null) vppParamPR_PHOTO.Value = DBNull.Value;

            SqlParameter vppParamPR_SIGNATURE = new SqlParameter("@PR_SIGNATURE", SqlDbType.VarBinary);
            vppParamPR_SIGNATURE.Value = clsOrgProspects.PR_SIGNATURE;
            if (clsOrgProspects.PR_SIGNATURE == null) vppParamPR_SIGNATURE.Value = DBNull.Value;


            SqlParameter vppParamPL_NUMCOMPTE = new SqlParameter("@PL_NUMCOMPTE", SqlDbType.VarChar, 25);
            vppParamPL_NUMCOMPTE.Value = clsOrgProspects.PL_NUMCOMPTE;

            SqlParameter vppParamPR_TAUXREMISE = new SqlParameter("@PR_TAUXREMISE", SqlDbType.Float);
            vppParamPR_TAUXREMISE.Value = clsOrgProspects.PR_TAUXREMISE;
            SqlParameter vppParamCU_CODECASUTILISATION = new SqlParameter("@CU_CODECASUTILISATION", SqlDbType.VarChar, 3);
            vppParamCU_CODECASUTILISATION.Value = clsOrgProspects.CU_CODECASUTILISATION;
            if (clsOrgProspects.CU_CODECASUTILISATION == "")
                vppParamCU_CODECASUTILISATION.Value = DBNull.Value;

            SqlParameter vppParamPR_NUMEROAGREMENT = new SqlParameter("@PR_NUMEROAGREMENT", SqlDbType.VarChar,150);
            vppParamPR_NUMEROAGREMENT.Value = clsOrgProspects.PR_NUMEROAGREMENT;
            if (clsOrgProspects.PR_NUMEROAGREMENT == "") vppParamPR_NUMEROAGREMENT.Value = DBNull.Value;

            SqlParameter vppParamPR_TAUXDECLARATION = new SqlParameter("@PR_TAUXDECLARATION", SqlDbType.Float);
            vppParamPR_TAUXDECLARATION.Value = clsOrgProspects.PR_TAUXDECLARATION;

            SqlParameter vppParamGP_CODEGROUPE = new SqlParameter("@GP_CODEGROUPE", SqlDbType.VarChar, 3);
            vppParamGP_CODEGROUPE.Value = clsOrgProspects.GP_CODEGROUPE;
            if (clsOrgProspects.GP_CODEGROUPE == "")
                vppParamGP_CODEGROUPE.Value = DBNull.Value;


        SqlParameter vppParamPR_MANDATAIRE = new SqlParameter("@PR_MANDATAIRE", SqlDbType.VarChar, 150);
            vppParamPR_MANDATAIRE.Value = clsOrgProspects.PR_MANDATAIRE;
        if (clsOrgProspects.PR_MANDATAIRE == "")
                vppParamPR_MANDATAIRE.Value = DBNull.Value;


            SqlParameter vppParamPR_USAGER = new SqlParameter("@PR_USAGER", SqlDbType.VarChar, 150);
            vppParamPR_USAGER.Value = clsOrgProspects.PR_USAGER;
            if (clsOrgProspects.PR_USAGER == "")
                vppParamPR_USAGER.Value = DBNull.Value;

            SqlParameter vppParamIN_CODEINGREDIENT = new SqlParameter("@IN_CODEINGREDIENT", SqlDbType.VarChar, 150);
            vppParamIN_CODEINGREDIENT.Value = clsOrgProspects.IN_CODEINGREDIENT;
            if (clsOrgProspects.IN_CODEINGREDIENT == "")
                vppParamIN_CODEINGREDIENT.Value = DBNull.Value;

            SqlParameter vppParamPR_ESCOMPTE = new SqlParameter("@PR_ESCOMPTE", SqlDbType.VarChar, 1);
            vppParamPR_ESCOMPTE.Value = clsOrgProspects.PR_ESCOMPTE;


            SqlParameter vppParamCODECRYPTAGE = new SqlParameter("@CODECRYPTAGE", SqlDbType.VarChar, 50);
            vppParamCODECRYPTAGE.Value = clsDonnee.vogCleCryptage;



            SqlParameter vppParamTYPEOPERATION = new SqlParameter("@TYPEOPERATION", SqlDbType.Int);
            vppParamTYPEOPERATION.Value = clsOrgProspects.TYPEOPERATION;



            //Préparation de la commande

            this.vapRequete = "EXECUTE [dbo].[PC_ORGPROSPECTSWF]@AG_CODEAGENCE,@EN_CODEENTREPOT,@PR_IDTIERS,@PR_IDTIERSPRINCIPAL,@NT_CODENATURETYPETIERS,@NT_CODENATURETIERS,@PY_CODEPAYS,@VL_CODEVILLE,@PR_SIEGE,SX_CODESEXE,FM_CODEFORMEJURIDIQUE,@AC_CODEACTIVITE,@TP_CODETYPETIERS,@TC_CODECOMPTETYPETIERS,@PR_NUMTIERS,@PR_DATENAISSANCE,@PR_DENOMINATION,@PR_DESCRIPTIONTIERS,@PR_ADRESSEPOSTALE,@PR_ADRESSEGEOGRAPHIQUE,@PR_TELEPHONE,@PR_FAX,@PR_SITEWEB,@PR_EMAIL,@PR_GERANT,@PR_STATUT,@PR_DATESAISIE,@PR_ASDI,@PR_TVA,@PR_STATUTDOUTEUX,@PR_PLAFONDCREDIT,@PR_NUMCPTECONTIBUABLE,@OP_CODEOPERATEUR,@PR_DATEDEPART,@PR_PHOTO,@PR_SIGNATURE,@PL_NUMCOMPTE,@PR_TAUXREMISE,@CU_CODECASUTILISATION,@PR_NUMEROAGREMENT,@PR_TAUXDECLARATION,@GP_CODEGROUPE,@PR_MANDATAIRE,@PR_USAGER,@IN_CODEINGREDIENT,@PR_ESCOMPTE,@CODECRYPTAGE,@TYPEOPERATION,'' ";
        SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //this.vapRequete = " EXECUTE [dbo].[PC_ORGPROSPECTSWF]   @AG_CODEAGENCE,@EN_CODEENTREPOT, @PR_IDTIERS,@PR_IDTIERSPRINCIPAL, @NT_CODENATURETYPETIERS, @NT_CODENATURETIERS,@PY_CODEPAYS,@VL_CODEVILLE, @PR_SIEGE,@AC_CODEACTIVITE, @TP_CODETYPETIERS,@PR_NUMTIERS, @TC_CODECOMPTETYPETIERS,   @PR_DATENAISSANCE, @PR_DENOMINATION, @PR_DESCRIPTIONTIERS, @PR_ADRESSEPOSTALE, @PR_ADRESSEGEOGRAPHIQUE, @PR_TELEPHONE, @PR_FAX, @PR_SITEWEB, @PR_EMAIL, @PR_GERANT, @PR_STATUT,  @PR_DATESAISIE, @PR_ASDI, @PR_TVA , @PR_STATUTDOUTEUX,  @PR_PLAFONDCREDIT,@PR_NUMCPTECONTIBUABLE,@OP_CODEOPERATEUR,@PR_DATEDEPART,@PR_PHOTO,@PL_NUMCOMPTE,@PR_TAUXREMISE,@CU_CODECASUTILISATION,@PR_NUMEROAGREMENT,@PR_TAUXDECLARATION,@GP_CODEGROUPE,@CODECRYPTAGE,@TYPEOPERATION";
            //SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ajout des paramètre à la commande
            vppSqlCmd.Parameters.Add(vppParamAG_CODEAGENCE);
            vppSqlCmd.Parameters.Add(vppParamEN_CODEENTREPOT);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_IDTIERSPRINCIPAL);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamNT_CODENATURETIERS);
            vppSqlCmd.Parameters.Add(vppParamPY_CODEPAYS);
            vppSqlCmd.Parameters.Add(vppParamVL_CODEVILLE);
            vppSqlCmd.Parameters.Add(vppParamPR_SIEGE);

            vppSqlCmd.Parameters.Add(vppParamSX_CODESEXE);
            vppSqlCmd.Parameters.Add(vppParamFM_CODEFORMEJURIDIQUE);
            //vppSqlCmd.Parameters.Add(vppParamSM_CODESITUATIONMATRIMONIALE);
            //vppSqlCmd.Parameters.Add(vppParamPF_CODEPROFESSION);
            vppSqlCmd.Parameters.Add(vppParamAC_CODEACTIVITE);
            vppSqlCmd.Parameters.Add(vppParamTP_CODETYPETIERS);
            vppSqlCmd.Parameters.Add(vppParamTC_CODECOMPTETYPETIERS);

            vppSqlCmd.Parameters.Add(vppParamPR_NUMTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_DATENAISSANCE);
            vppSqlCmd.Parameters.Add(vppParamPR_DENOMINATION);
            vppSqlCmd.Parameters.Add(vppParamPR_DESCRIPTIONTIERS);
            vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEPOSTALE);
            vppSqlCmd.Parameters.Add(vppParamPR_ADRESSEGEOGRAPHIQUE);
            vppSqlCmd.Parameters.Add(vppParamPR_TELEPHONE);
            vppSqlCmd.Parameters.Add(vppParamPR_FAX);
            vppSqlCmd.Parameters.Add(vppParamPR_SITEWEB);
            vppSqlCmd.Parameters.Add(vppParamPR_EMAIL);
            vppSqlCmd.Parameters.Add(vppParamPR_GERANT);
            vppSqlCmd.Parameters.Add(vppParamPR_STATUT);
            vppSqlCmd.Parameters.Add(vppParamPR_DATESAISIE);
            vppSqlCmd.Parameters.Add(vppParamPR_ASDI);
            vppSqlCmd.Parameters.Add(vppParamPR_TVA);
            vppSqlCmd.Parameters.Add(vppParamPR_STATUTDOUTEUX);
            vppSqlCmd.Parameters.Add(vppParamPR_PLAFONDCREDIT);
            vppSqlCmd.Parameters.Add(vppParamPR_NUMCPTECONTIBUABLE);
            vppSqlCmd.Parameters.Add(vppParamOP_CODEOPERATEUR);
            vppSqlCmd.Parameters.Add(vppParamPR_DATEDEPART);
            vppSqlCmd.Parameters.Add(vppParamPR_PHOTO);
            vppSqlCmd.Parameters.Add(vppParamPR_SIGNATURE);
            vppSqlCmd.Parameters.Add(vppParamPL_NUMCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamPR_TAUXREMISE);
            vppSqlCmd.Parameters.Add(vppParamCU_CODECASUTILISATION);
            vppSqlCmd.Parameters.Add(vppParamPR_NUMEROAGREMENT);
            vppSqlCmd.Parameters.Add(vppParamPR_TAUXDECLARATION);
            vppSqlCmd.Parameters.Add(vppParamGP_CODEGROUPE);
            vppSqlCmd.Parameters.Add(vppParamPR_MANDATAIRE);
            vppSqlCmd.Parameters.Add(vppParamPR_USAGER);

            vppSqlCmd.Parameters.Add(vppParamIN_CODEINGREDIENT);
            vppSqlCmd.Parameters.Add(vppParamPR_ESCOMPTE);
            vppSqlCmd.Parameters.Add(vppParamCODECRYPTAGE);
            vppSqlCmd.Parameters.Add(vppParamTYPEOPERATION);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, null, null);
        }


       


        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, EL_CODEELEVE, IN_CODEINSCRIPTION ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public void pvgDepartTiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@AG_CODEAGENCE", "@PR_IDTIERS", "@DATEJOURNEE", "@OP_CODEOPERATEUR" };
            vapValeurParametre = new object[] { vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
            //Préparation de la commande
            this.vapRequete = "EXEC PS_DEPARTTIERS @AG_CODEAGENCE,@PR_IDTIERS,@DATEJOURNEE,@OP_CODEOPERATEUR";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

            //Ouverture de la connection et exécution de la commande
            clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
        }


		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public void pvgDelete(clsDonnee clsDonnee,params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
			//Préparation de la commande
			 this.vapRequete = "DELETE FROM  ORGPROSPECTS "+ this.vapCritere;;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);

			//Ouverture de la connection et exécution de la commande
			clsDonnee.pvgMiseAJourBaseDeDonnees(vppSqlCmd, vapNomParametre, vapValeurParametre);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOrgProspects </returns>
		///<author>Home Technology</author>
		public List<clsOrgProspects> pvgSelect(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, PR_IDTIERS, NT_CODENATURETIERS, PR_SIEGE, AC_CODEACTIVITE, TP_CODETYPETIERS, PR_NUMTIERS, PR_DATENAISSANCE, PR_DENOMINATION, PR_DESCRIPTIONTIERS, PR_ADRESSEPOSTALE, PR_ADRESSEGEOGRAPHIQUE, PR_TELEPHONE, PR_FAX, PR_SITEWEB, PR_EMAIL, PR_GERANT, PR_STATUT, PR_DATESAISIE, PR_ASDI, PR_TVA, PR_STATUTDOUTEUX, PR_PLAFONDCREDIT, PR_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			List<clsOrgProspects> clsOrgProspectss = new List<clsOrgProspects>();
			if(clsDonnee.pvgRemplirDataReader(vppSqlCmd, vapNomParametre, vapValeurParametre))
			{
				while(clsDonnee.vogDataReader.Read())
				{
					clsOrgProspects clsOrgProspects = new clsOrgProspects();
					clsOrgProspects.AG_CODEAGENCE = clsDonnee.vogDataReader["AG_CODEAGENCE"].ToString();
					clsOrgProspects.PR_IDTIERS = clsDonnee.vogDataReader["PR_IDTIERS"].ToString();
                    clsOrgProspects.NT_CODENATURETIERS = clsDonnee.vogDataReader["NT_CODENATURETIERS"].ToString();
                    clsOrgProspects.PR_SIEGE = clsDonnee.vogDataReader["PR_SIEGE"].ToString();


                    //clsOrgProspects.SX_CODESEXE = clsDonnee.vogDataReader["SX_CODESEXE"].ToString();
                    //clsOrgProspects.SM_CODESITUATIONMATRIMONIALE = clsDonnee.vogDataReader["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    //clsOrgProspects.PF_CODEPROFESSION = clsDonnee.vogDataReader["PF_CODEPROFESSION"].ToString();



					clsOrgProspects.AC_CODEACTIVITE = clsDonnee.vogDataReader["AC_CODEACTIVITE"].ToString();
					clsOrgProspects.TP_CODETYPETIERS = clsDonnee.vogDataReader["TP_CODETYPETIERS"].ToString();
					clsOrgProspects.PR_NUMTIERS = clsDonnee.vogDataReader["PR_NUMTIERS"].ToString();
					clsOrgProspects.PR_DATENAISSANCE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATENAISSANCE"].ToString());
					clsOrgProspects.PR_DENOMINATION = clsDonnee.vogDataReader["PR_DENOMINATION"].ToString();
					clsOrgProspects.PR_DESCRIPTIONTIERS = clsDonnee.vogDataReader["PR_DESCRIPTIONTIERS"].ToString();
					clsOrgProspects.PR_ADRESSEPOSTALE = clsDonnee.vogDataReader["PR_ADRESSEPOSTALE"].ToString();
					clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = clsDonnee.vogDataReader["PR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsOrgProspects.PR_TELEPHONE = clsDonnee.vogDataReader["PR_TELEPHONE"].ToString();
					clsOrgProspects.PR_FAX = clsDonnee.vogDataReader["PR_FAX"].ToString();
					clsOrgProspects.PR_SITEWEB = clsDonnee.vogDataReader["PR_SITEWEB"].ToString();
					clsOrgProspects.PR_EMAIL = clsDonnee.vogDataReader["PR_EMAIL"].ToString();
					clsOrgProspects.PR_GERANT = clsDonnee.vogDataReader["PR_GERANT"].ToString();
					clsOrgProspects.PR_STATUT = clsDonnee.vogDataReader["PR_STATUT"].ToString();
					clsOrgProspects.PR_DATESAISIE = DateTime.Parse(clsDonnee.vogDataReader["PR_DATESAISIE"].ToString());
					clsOrgProspects.PR_ASDI = clsDonnee.vogDataReader["PR_ASDI"].ToString();
					clsOrgProspects.PR_TVA = clsDonnee.vogDataReader["PR_TVA"].ToString();
                    //clsOrgProspects.PR_STATUTDOUTEUX = int.Parse(clsDonnee.vogDataReader["PR_STATUTDOUTEUX"].ToString());
					clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(clsDonnee.vogDataReader["PR_PLAFONDCREDIT"].ToString());
					clsOrgProspects.PR_NUMCPTECONTIBUABLE = clsDonnee.vogDataReader["PR_NUMCPTECONTIBUABLE"].ToString();
					clsOrgProspects.OP_CODEOPERATEUR = clsDonnee.vogDataReader["OP_CODEOPERATEUR"].ToString();
					clsOrgProspectss.Add(clsOrgProspects);
				}
				clsDonnee.vogDataReader.Dispose();
			}
			return clsOrgProspectss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsOrgProspects </returns>
		///<author>Home Technology</author>
		public List<clsOrgProspects> pvgSelectDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
			List<clsOrgProspects> clsOrgProspectss = new List<clsOrgProspects>();
			DataSet Dataset = new DataSet();

            pvpChoixCritere1(clsDonnee,vppCritere);
            this.vapRequete = "SELECT  AG_CODEAGENCE, PR_IDTIERS, NT_CODENATURETIERS, PR_SIEGE, AC_CODEACTIVITE, TP_CODETYPETIERS, PR_NUMTIERS, PR_DATENAISSANCE, PR_DENOMINATION, PR_DESCRIPTIONTIERS, PR_ADRESSEPOSTALE, PR_ADRESSEGEOGRAPHIQUE, PR_TELEPHONE, PR_FAX, PR_SITEWEB, PR_EMAIL, PR_GERANT, PR_STATUT, PR_DATESAISIE, PR_ASDI, PR_TVA, PR_STATUTDOUTEUX, PR_PLAFONDCREDIT, PR_NUMCPTECONTIBUABLE, OP_CODEOPERATEUR FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere="";			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,Dataset);
			if(int.Parse(clsDonnee.vagNombreLigneRequete)>0)
			{
				for (int Idx = 0; Idx < int.Parse(clsDonnee.vagNombreLigneRequete); Idx++)
				{
					clsOrgProspects clsOrgProspects = new clsOrgProspects();
					clsOrgProspects.AG_CODEAGENCE = Dataset.Tables["TABLE"].Rows[Idx]["AG_CODEAGENCE"].ToString();
					clsOrgProspects.PR_IDTIERS = Dataset.Tables["TABLE"].Rows[Idx]["PR_IDTIERS"].ToString();

                    clsOrgProspects.NT_CODENATURETIERS = Dataset.Tables["TABLE"].Rows[Idx]["NT_CODENATURETIERS"].ToString();
                    clsOrgProspects.PR_SIEGE = Dataset.Tables["TABLE"].Rows[Idx]["PR_SIEGE"].ToString();

                    //clsOrgProspects.SX_CODESEXE = Dataset.Tables["TABLE"].Rows[Idx]["SX_CODESEXE"].ToString();
                    //clsOrgProspects.SM_CODESITUATIONMATRIMONIALE = Dataset.Tables["TABLE"].Rows[Idx]["SM_CODESITUATIONMATRIMONIALE"].ToString();
                    //clsOrgProspects.PF_CODEPROFESSION = Dataset.Tables["TABLE"].Rows[Idx]["PF_CODEPROFESSION"].ToString();

					clsOrgProspects.AC_CODEACTIVITE = Dataset.Tables["TABLE"].Rows[Idx]["AC_CODEACTIVITE"].ToString();
					clsOrgProspects.TP_CODETYPETIERS = Dataset.Tables["TABLE"].Rows[Idx]["TP_CODETYPETIERS"].ToString();
					clsOrgProspects.PR_NUMTIERS = Dataset.Tables["TABLE"].Rows[Idx]["PR_NUMTIERS"].ToString();
					clsOrgProspects.PR_DATENAISSANCE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PR_DATENAISSANCE"].ToString());
					clsOrgProspects.PR_DENOMINATION = Dataset.Tables["TABLE"].Rows[Idx]["PR_DENOMINATION"].ToString();
					clsOrgProspects.PR_DESCRIPTIONTIERS = Dataset.Tables["TABLE"].Rows[Idx]["PR_DESCRIPTIONTIERS"].ToString();
					clsOrgProspects.PR_ADRESSEPOSTALE = Dataset.Tables["TABLE"].Rows[Idx]["PR_ADRESSEPOSTALE"].ToString();
					clsOrgProspects.PR_ADRESSEGEOGRAPHIQUE = Dataset.Tables["TABLE"].Rows[Idx]["PR_ADRESSEGEOGRAPHIQUE"].ToString();
					clsOrgProspects.PR_TELEPHONE = Dataset.Tables["TABLE"].Rows[Idx]["PR_TELEPHONE"].ToString();
					clsOrgProspects.PR_FAX = Dataset.Tables["TABLE"].Rows[Idx]["PR_FAX"].ToString();
					clsOrgProspects.PR_SITEWEB = Dataset.Tables["TABLE"].Rows[Idx]["PR_SITEWEB"].ToString();
					clsOrgProspects.PR_EMAIL = Dataset.Tables["TABLE"].Rows[Idx]["PR_EMAIL"].ToString();
					clsOrgProspects.PR_GERANT = Dataset.Tables["TABLE"].Rows[Idx]["PR_GERANT"].ToString();
					clsOrgProspects.PR_STATUT = Dataset.Tables["TABLE"].Rows[Idx]["PR_STATUT"].ToString();
					clsOrgProspects.PR_DATESAISIE = DateTime.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PR_DATESAISIE"].ToString());
					clsOrgProspects.PR_ASDI = Dataset.Tables["TABLE"].Rows[Idx]["PR_ASDI"].ToString();
					clsOrgProspects.PR_TVA = Dataset.Tables["TABLE"].Rows[Idx]["PR_TVA"].ToString();
					clsOrgProspects.PR_STATUTDOUTEUX = int.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PR_STATUTDOUTEUX"].ToString());
					clsOrgProspects.PR_PLAFONDCREDIT = double.Parse(Dataset.Tables["TABLE"].Rows[Idx]["PR_PLAFONDCREDIT"].ToString());
					clsOrgProspects.PR_NUMCPTECONTIBUABLE = Dataset.Tables["TABLE"].Rows[Idx]["PR_NUMCPTECONTIBUABLE"].ToString();
					clsOrgProspects.OP_CODEOPERATEUR = Dataset.Tables["TABLE"].Rows[Idx]["OP_CODEOPERATEUR"].ToString();
					clsOrgProspectss.Add(clsOrgProspects);
				}
				Dataset.Dispose();
			}
		return clsOrgProspectss;
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere(clsDonnee, vppCritere);
            //this.vapRequete = "SELECT *  FROM dbo.ORGPROSPECTS " + this.vapCritere;
            this.vapRequete = "SELECT *  FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE) " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

        public DataSet pvgChargerRechercheTiersparNom(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            //vapNomParametre = new string[] { "@CODECRYPTAGE" };
            //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
            this.vapRequete = "SELECT *  FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)   " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }
		

		public DataSet pvgChargerDansDataSetRecherche(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritereRecherche(clsDonnee, vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}

		public DataSet pvgChargerDansDataSetParSexe(clsDonnee clsDonnee, params string[] vppCritere)
		{
            pvpChoixCritere2(clsDonnee,vppCritere);
            this.vapRequete = "SELECT *  FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet vlpDataset = new DataSet();
            vlpDataset =clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
            return vlpDataset;
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, params string[] vppCritere)
		{
            //pvpChoixCritere(clsDonnee,vppCritere);
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TP_CODETYPETIERS" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1].Replace("''", "'") };

            
            this.vapRequete = "EXEC PS_CHARGEMENTCOMBOTIERS @AG_CODEAGENCE,@TP_CODETYPETIERS,@CODECRYPTAGE  " ;
			this.vapCritere = "";
			SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
			return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre,true);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboSelonNaturetypetiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            //pvpChoixCritere(clsDonnee,vppCritere);
            //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TP_CODETYPETIERS=@NT_CODENATURETYPETIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@NT_CODENATURETYPETIERS" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1].Replace("''", "'") };


            this.vapRequete = "EXEC PS_CHARGEMENTCOMBOTIERSSELONLANATURETYPETIERS @AG_CODEAGENCE,@NT_CODENATURETYPETIERS,@CODECRYPTAGE  ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }


        public DataSet pvgChargerDansDataSetTiers(clsDonnee clsDonnee, params string[] vppCritere)
        {
            vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@PR_DATESAISIE1", "@PR_DATESAISIE2", "@TP_CODETYPETIERS", "@SC_CODESECTION", "@CU_CODECASUTILISATION", "@OP_CODEOPERATEUREDITION", "@TYPEOPERATION" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[8], vppCritere[9], vppCritere[10], vppCritere[11] };

            this.vapRequete = "EXEC  [dbo].[PS_ORGPROSPECTS] @AG_CODEAGENCE,@EN_CODEENTREPOT,@PR_STATUT,@PR_NUMTIERS,@PR_DENOMINATION, @PR_DATESAISIE1,@PR_DATESAISIE2,@TP_CODETYPETIERS,@SC_CODESECTION,@CU_CODECASUTILISATION,@OP_CODEOPERATEUREDITION,@TYPEOPERATION,@CODECRYPTAGE  ";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            DataSet vlpDataset = new DataSet();
            vlpDataset = clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            return vlpDataset;
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourCombo1(clsDonnee clsDonnee, params string[] vppCritere)
        {
            pvpChoixCritere(clsDonnee, vppCritere);
            this.vapRequete = "SELECT PR_NUMTIERS FROM dbo.FT_ORGPROSPECTS(@AG_CODEAGENCE,@CODECRYPTAGE)  " + this.vapCritere;
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            return clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
        }

       
        public DataSet pvgControlComptesLies(clsDonnee clsDonnee,  params string[] vppCritere)
        {
            DataSet DataSet = new DataSet();

            vapNomParametre = new string[] { "@CODECRYPTAGE", "@PL_NUMCOMPTEGENERAL", "@PR_NUMTIERS", "@NC_CODENATURECOMPTE" };
            vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };


            //Préparation de la commande
            this.vapRequete = " EXECUTE [dbo].[PS_CONTROLCOMPTELIE]   @PL_NUMCOMPTEGENERAL, @PR_NUMTIERS, @NC_CODENATURECOMPTE, @CODECRYPTAGE";
            this.vapCritere = "";
            SqlCommand vppSqlCmd = new SqlCommand(this.vapRequete, clsDonnee.vogObjetConnexionLocal, clsDonnee.vogObjetTransactionLocal);
            clsDonnee.pvgRemplirDataset(vppSqlCmd, vapNomParametre, vapValeurParametre, true);
            return DataSet;
        }


		///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS)</summary>
		///<param name="vppCritere">Les critères de la requète</param>
		///<author>Home Technologie</author>
        public void pvpChoixCritere(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = " WHERE PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage};
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_IDTIERS=@PR_IDTIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_IDTIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_IDTIERS=@PR_IDTIERS AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_IDTIERS", "@TP_CODETYPETIERS" };
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
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT = 'N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS=@PR_NUMTIERS AND PR_STATUT = 'N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+ @PR_NUMTIERS +'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
                case 4:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+ @PR_NUMTIERS +'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' ";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@TP_CODETYPETIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                    break;

                case 5:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+ @PR_NUMTIERS +'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                    break;

                case 6:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+ @PR_NUMTIERS +'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%' AND  ISNULL(CU_CODECASUTILISATION,'') LIKE '%'+@CU_CODECASUTILISATION+'%'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION", "@CU_CODECASUTILISATION" };
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
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT = 'N'";
        //		vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
        //		break;
        //		case 2 :
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND [dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,PR_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')=@PR_NUMTIERS AND PR_STATUT = 'N'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@PR_NUMTIERS" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
        //		break;
        //		case 3 :
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+ [dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,PR_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')+'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
        //		break;
        //              case 4:
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,PR_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')+'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' ";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@TP_CODETYPETIERS" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] , vppCritere[3] };
        //              break;

        //              case 5:
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,PR_NUMTIERS,'"+clsDonnee.vogCleCryptage+"')+'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4]};
        //              break;

        //              case 6:
        //              this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS like '%'+[dbo].[FC_FORMATMATRICULE] (EN_CODEENTREPOT,PR_NUMTIERS,'" + clsDonnee.vogCleCryptage + "')+'%' AND PR_DENOMINATION like '%'+ @PR_DENOMINATION +'%' AND PR_STATUT = 'N' AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND SC_CODESECTION LIKE '%'+@SC_CODESECTION+'%' AND  ISNULL(CU_CODECASUTILISATION,'') LIKE '%'+@CU_CODECASUTILISATION+'%'";
        //              vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@TP_CODETYPETIERS", "@SC_CODESECTION", "@CU_CODECASUTILISATION" };
        //              vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] , vppCritere[4], vppCritere[5]};
        //              break;
        //	}
        //}




        public void pvpChoixCritere1(clsDonnee clsDonnee, params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = " WHERE PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
				vapNomParametre = new string[]{"@CODECRYPTAGE","@AG_CODEAGENCE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_IDTIERS=@PR_IDTIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@PR_IDTIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1] };
				break;
				case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE","@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage,vppCritere[0], vppCritere[1], vppCritere[2] };
				break;

                case 4:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%'AND PR_TELEPHONE LIKE '%'+@PR_TELEPHONE+'%' AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@PR_TELEPHONE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3] };
                break;
                case 5:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%'AND PR_TELEPHONE LIKE '%'+@PR_TELEPHONE+'%'  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_NUMTIERS", "@PR_DENOMINATION", "@PR_TELEPHONE", "@TP_CODETYPETIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                break;

			}
		}

		public void pvpChoixCritere2( clsDonnee clsDonnee,params string[] vppCritere)
		{
			switch (vppCritere.Length) 
			 {
				case 0 :
                     this.vapCritere = " WHERE PR_DATEDEPART='01/01/1900' ";
                vapNomParametre = new string[] { "@CODECRYPTAGE"};
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, };
				break;
				case 1 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
				break;
				case 2 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
				break;

                case 3 :
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT AND PR_DATEDEPART='01/01/1900'";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                break;

                case 4:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT  AND PR_STATUT=@PR_STATUT  AND PR_NUMTIERS LIKE @PR_NUMTIERS'%' AND PR_DATEDEPART='01/01/1900'";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3]};
                //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
                break;

                case 5:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT  AND PR_NUMTIERS LIKE @PR_NUMTIERS'%'AND PR_DENOMINATION LIKE @PR_DENOMINATION'%' AND PR_DATEDEPART='01/01/1900'";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4] };
                //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[2], 3, "SX_CODESEXE");
                //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 3, "SX_CODESEXE");
                break;


                case 7:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT  AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND PR_DATEDEPART='01/01/1900' ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6]  };
                //vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                //vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                break;

                //case 7:
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%'    ";
                ////this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5] , vppCritere[6]  };
                ////vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                ////vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                //break;


                case 8:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%'  AND PR_DATEDEPART='01/01/1900'   ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] };
                
                break;



                case 9:
                this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%' AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[8], "CU_CODECASUTILISATION") + ") AND PR_DATEDEPART='01/01/1900'   ";
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS", "@CU_CODECASUTILISATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7] , vppCritere[8] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[8], 9, "CU_CODECASUTILISATION");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 9, "CU_CODECASUTILISATION");
                break;

                //case 8:
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS+'%'    ";
                ////this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                ////vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                ////vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                //break;

                //case 8:

                //if (vppCritere[6] == "07" && vppCritere[7] == "CLT")
                //{
                //    vppCritere[6] = "001";
                //    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS =@TP_CODETYPETIERS    ";
                //}
                //else
                //if (vppCritere[6] != "07" && vppCritere[7] == "ALL")
                //{
                //    vppCritere[6] = "";
                //    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS +'%'      ";
                //}
                //else
                //{
                //    vppCritere[6] = "001";
                //    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS !=@TP_CODETYPETIERS    ";
                //}
                ////this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                //vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS" };
                //vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6] };
                ////vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[6], 7, "SX_CODESEXE");
                ////vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 7, "SX_CODESEXE");
                //break;


                case 10:

                if (vppCritere[7] == "07" && vppCritere[8] == "CLT")
                {
                    vppCritere[7] = "001";
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS =@TP_CODETYPETIERS AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[9], "CU_CODECASUTILISATION") + ") AND PR_DATEDEPART='01/01/1900'  ";
                }
                else
                    if (vppCritere[7] != "07" && vppCritere[8] == "ALL")
                    {
                        vppCritere[7] = "";
                        this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS LIKE '%'+@TP_CODETYPETIERS +'%'   AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[9], "CU_CODECASUTILISATION") + ")  AND PR_DATEDEPART='01/01/1900' ";
                    }
                    else
                    {
                        vppCritere[7] = "001";
                        this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE   AND EN_CODEENTREPOT=@EN_CODEENTREPOT AND PR_STATUT=@PR_STATUT AND PR_NUMTIERS LIKE '%'+@PR_NUMTIERS+'%' AND PR_DENOMINATION LIKE '%'+@PR_DENOMINATION+'%' AND PR_DATESAISIE BETWEEN @DATE1 AND @DATE2  AND TP_CODETYPETIERS !=@TP_CODETYPETIERS AND CU_CODECASUTILISATION NOT IN(" + clsDonnee.pvpParametreIN(vppCritere[9], "CU_CODECASUTILISATION") + ")   AND PR_DATEDEPART='01/01/1900' ";
                    }
                //this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT=@PR_STATUT ";
                vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@EN_CODEENTREPOT", "@PR_STATUT", "@PR_NUMTIERS", "@PR_DENOMINATION", "@DATE1", "@DATE2", "@TP_CODETYPETIERS", "@CU_CODECASUTILISATION" };
                vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2], vppCritere[3], vppCritere[4], vppCritere[5], vppCritere[6], vppCritere[7], vppCritere[9] };
                vapNomParametre = clsDonnee.pvpTransformationIN(vapNomParametre, vppCritere[9], 9, "CU_CODECASUTILISATION");
                vapValeurParametre = clsDonnee.pvpTransformationIN(vapValeurParametre, 9, "CU_CODECASUTILISATION");
                break;



			}
		}

        ///<summary>Cette fonction permet de definir les critères d'une requête avec ou sans critères (Ordre Critères :AG_CODEAGENCE, PR_IDTIERS, TP_CODETYPETIERS)</summary>
        ///<param name="vppCritere">Les critères de la requète</param>
        ///<author>Home Technologie</author>
        public void pvpChoixCritere3(clsDonnee clsDonnee, params string[] vppCritere)
        {
            switch (vppCritere.Length)
            {
                case 0:
                    this.vapCritere = " WHERE PR_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage };
                    break;
                case 1:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0] };
                    break;
                case 2:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TP_CODETYPETIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1] };
                    break;
                case 3:
                    this.vapCritere = "WHERE AG_CODEAGENCE=@AG_CODEAGENCE  AND TP_CODETYPETIERS=@TP_CODETYPETIERS AND PR_IDTIERS=@PR_IDTIERS AND PR_STATUT = 'N' AND PR_DATEDEPART='01/01/1900' AND NT_CODENATURETYPETIERS='02'";
                    vapNomParametre = new string[] { "@CODECRYPTAGE", "@AG_CODEAGENCE", "@TP_CODETYPETIERS", "@PR_IDTIERS" };
                    vapValeurParametre = new object[] { clsDonnee.vogCleCryptage, vppCritere[0], vppCritere[1], vppCritere[2] };
                    break;
            }
        }


	}
}
