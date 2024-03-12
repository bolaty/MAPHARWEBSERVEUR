using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;

namespace Stock.WSBLL
{
	public class clsSmsoutWSBLL: IObjetWSBLL<clsSmsout>
	{
		private clsSmsoutWSDAL clsSmsoutWSDAL= new clsSmsoutWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsSmsout comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsSmsout pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsout">clsSmsout</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsSmsout clsSmsout , clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsout.SM_NUMSEQUENCE = string.Format( "{0:00000000000000000000}" , double.Parse(clsSmsoutWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsSmsoutWSDAL.pvgInsert(clsDonnee, clsSmsout);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsout.SM_NUMSEQUENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsouts"> Liste d'objet clsSmsout</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsSmsout> clsSmsouts , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsSmsoutWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsSmsouts.Count; Idx++)
			{
				clsSmsouts[Idx].AG_CODEAGENCE = string.Format( "{0:00000000000000000000}" , double.Parse(clsSmsoutWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsSmsoutWSDAL.pvgInsert(clsDonnee, clsSmsouts[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsouts[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsSmsout">clsSmsout</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsSmsout clsSmsout,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsoutWSDAL.pvgUpdate(clsDonnee, clsSmsout, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsSmsout.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsSmsoutWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsSmsout </returns>
		///<author>Home Technology</author>
		public List<clsSmsout> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsSmsout </returns>
		///<author>Home Technology</author>
		public List<clsSmsout> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, SM_DATEPIECE, SM_NUMPIECE, SM_NUMSEQUENCE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsSmsoutWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}









        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public clsParams pvgTraitementSms(clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string SM_TELEPHONE, string OP_CODEOPERATEUR, DateTime SM_DATEPIECE, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {


            ////Processus d'envoi du sms
            clsParams clsParams = new clsParams();//BOJ model de retour
            clsParams clsParams1 = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            clsSmsoutWSDAL clsSmsoutWSDAL = new clsSmsoutWSDAL();
            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();


            try
            {

                Objet = clsSmsoutWSBLL.pvpPreparationSms(clsDonnee,  AG_CODEAGENCE, PV_CODEPOINTVENTE, CO_CODECOMPTE, OB_NOMOBJET, SM_TELEPHONE, OP_CODEOPERATEUR, SM_DATEPIECE, MB_IDTIERS, CL_IDCLIENT, EJ_IDEPARGNANTJOURNALIER, SMSTEXT, TE_CODESMSTYPEOPERATION, SM_NUMSEQUENCE, SM_DATEEMISSIONSMS, MC_NUMPIECE, null, SM_STATUT, TYPEOPERATION, SL_LIBELLE1, SL_LIBELLE2);

                if (Objet == null)
                {
                    clsParams1.SL_CODEMESSAGE = "00";
                    clsParams1.SL_MESSAGE = "Echec d'appel de l'api sms !!!";
                    clsParams1.SL_RESULTAT = "FALSE";
                    Objet.Add(clsParams1);
                }
                else
                {
                    Objet[0].CodeAgence = AG_CODEAGENCE;
                    SM_NUMSEQUENCE = Objet[0].SM_NUMSEQUENCE;

                }

                //--Preparation d'appel de l'apisms et mise a jour de sms
                //--appel de l'api sms
                if (Objet[0].SL_RESULTAT != "TRUE") return Objet[0];
                Objet = clsAppelServiceWeb.excecuteServiceWeb(clsParams, Objet, "post", Stock.WSTOOLS.clsDeclaration.URL_ADRESSE_API_SMS).ToList();
                if (Objet == null)
                {
                    clsParams1.SL_CODEMESSAGE = "00";
                    clsParams1.SL_MESSAGE = "Echec d'appel de l'api sms !!!";
                    clsParams1.SL_RESULTAT = "FALSE";
                    //clsParams1.SM_NUMSEQUENCE = SM_NUMSEQUENCE;
                    Objet.Add(clsParams1);
                }
                //--mise a jour du statut de sms 
                if (Objet.Count > 0)
                {
                    if (Objet[0].SL_RESULTAT == "TRUE")
                        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                    if (Objet[0].SL_RESULTAT == "FALSE")
                    {
                        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                        clsParamss[0].SL_RESULTAT = "FALSE";
                        clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                        Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                    }
                }
                else
                {
                    if (Objet.Count > 0)
                    {
                        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), Objet[0].SM_NUMSEQUENCE, "N", "");
                        //clsParamss[0].SL_RESULTAT = "FALSE";
                        //clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        Objet[0].SL_RESULTAT = "FALSE";
                        Objet[0].SL_MESSAGE = "e+Echec envoi de sms !!!";
                    }
                    else
                    {
                        clsParams1.SL_CODEMESSAGE = "00";
                        clsParams1.SL_MESSAGE = "e+Echec envoi de sms !!!";
                        clsParams1.SL_RESULTAT = "FALSE";
                        Objet.Add(clsParams1);
                    }
                    

                }


                //if (Objet.Count>0)
                //{
                //    if (Objet[0].SL_RESULTAT == "TRUE")
                //        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, SM_NUMSEQUENCE, "E", "OK");
                //    if (Objet[0].SL_RESULTAT == "FALSE")
                //    {
                //        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, SM_DATEPIECE, SM_NUMSEQUENCE, "N", Objet[0].SL_MESSAGE);
                //        //clsParamss[0].SL_RESULTAT = "FALSE";
                //        //clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                //        //Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                //        //Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                //    }
                //}


            }
            catch (System.Net.WebException e)
            {
                clsParams1.SL_CODEMESSAGE = "00";
                clsParams1.SL_MESSAGE = e.Message.ToString();
                clsParams1.SL_RESULTAT = "FALSE";
                Objet.Add(clsParams1);
                clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), Objet[0].SM_NUMSEQUENCE, "N", e.Message.ToString());
            }
            catch (Exception ex)
            {

                clsParams1.SL_CODEMESSAGE = "00";
                clsParams1.SL_MESSAGE = ex.Message.ToString();
                clsParams1.SL_RESULTAT = "FALSE";
                Objet.Add(clsParams1);
                clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            return Objet[0];
        }


        ///<summary>Cette fonction permet de definir les criteres d'une requete avec ou sans criteres (Ordre Criteres :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE, TE_CODESMSTYPEOPERATION, CO_CODECOMPTE)</summary>
		///<param name="clsDonnee"> clsDonnee</param>
		///<param name="vppCritere">Les criteres de la requete</param>
		///<author>Home Technologie</author>
		public List<clsParams> pvpPreparationSms(clsDonnee clsDonnee, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string CO_CODECOMPTE, string OB_NOMOBJET, string CL_TELEPHONE, string OP_CODEOPERATEUR, DateTime CL_DATECREATION, string MB_IDTIERS, string CL_IDCLIENT, string EJ_IDEPARGNANTJOURNALIER, string SMSTEXT, string TE_CODESMSTYPEOPERATION, string SM_NUMSEQUENCE, string SM_DATEEMISSIONSMS, string MC_NUMPIECE, string MC_NUMSEQUENCE, string SM_STATUT, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {
            //Processus d'envoi du sms
            //clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            clsParams clsParams = new clsParams();//liste BOJ selon model retourne
            //List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();

            clsParams.CodeAgence = AG_CODEAGENCE;
            clsParams.LibelleMouchard = "";
            clsParams.LibelleEcran = "";
            clsParams.LG_CODELANGUE = "FR";
            clsParams.SL_LIBELLE1 = SL_LIBELLE1;
            clsParams.SL_LIBELLE2 = SL_LIBELLE2;
            clsParams.CO_CODECOMPTE = CO_CODECOMPTE;
            clsParams.LO_LOGICIEL = "1";
            clsParams.OB_NOMOBJET = OB_NOMOBJET;
            clsParams.SL_VALEURRETOURS = "";
            clsParams.INDICATIF = "";
            clsParams.RECIPIENTPHONE = CL_TELEPHONE;
            clsParams.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
            clsParams.CodeOperateur = OP_CODEOPERATEUR;
            clsParams.SM_DATEPIECE = CL_DATECREATION.ToShortDateString().Replace("/", "-");
            clsParams.SM_RAISONNONENVOISMS = "";
            clsParams.TYPEOPERATION = TYPEOPERATION;
            clsParams.SMSTEXT = SMSTEXT;
            clsParams.MB_IDTIERS = MB_IDTIERS;
            clsParams.EJ_IDEPARGNANTJOURNALIER = EJ_IDEPARGNANTJOURNALIER;
            clsParams.CL_IDCLIENT = CL_IDCLIENT;
            clsParams.TE_CODESMSTYPEOPERATION = TE_CODESMSTYPEOPERATION;
            clsParams.SM_NUMSEQUENCE = SM_NUMSEQUENCE;
            clsParams.SM_DATEEMISSIONSMS = DateTime.Parse(SM_DATEEMISSIONSMS);
            clsParams.MC_NUMPIECE = MC_NUMPIECE;
            clsParams.MC_NUMSEQUENCE = MC_NUMSEQUENCE;
            clsParams.SM_STATUT = SM_STATUT;

            clsSmsouts = clsSmsoutWSDAL.pvgMobileSms(clsDonnee, clsParams);

            clsParams.SM_NUMSEQUENCE = clsSmsouts[0].SM_NUMSEQUENCE;
            clsParams.SMSTEXT = clsSmsouts[0].SM_MESSAGE;
            clsParams.RECIPIENTPHONE = clsSmsouts[0].SM_TELEPHONE;
            clsParams.SL_CODEMESSAGE = clsSmsouts[0].SL_CODEMESSAGE;
            clsParams.SL_MESSAGE = clsSmsouts[0].SL_MESSAGE;
            clsParams.SL_RESULTAT = clsSmsouts[0].SL_RESULTAT;

            clsParams.SL_MESSAGEOBJET = clsSmsouts[0].SL_MESSAGEOBJET;
            clsParams.AG_EMAIL = clsSmsouts[0].AG_EMAIL;
            clsParams.AG_EMAILMOTDEPASSE = clsSmsouts[0].AG_EMAILMOTDEPASSE;

            clsDeclaration.ClasseDeclaration.AG_EMAIL = clsParams.AG_EMAIL;
            clsDeclaration.ClasseDeclaration.AG_EMAILMOTDEPASSE = clsParams.AG_EMAILMOTDEPASSE;
            clsDeclaration.ClasseDeclaration.SL_MESSAGEOBJET = clsParams.SL_MESSAGEOBJET;
            clsDeclaration.ClasseDeclaration.SMSTEXT = clsParams.SMSTEXT;

            clsParamss.Add(clsParams);

            return clsParamss;
        }



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsSmsout">clsSmsout</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public clsParams pvgTraitementSmsSimple(clsDonnee clsDonnee, string AG_CODEAGENCE,string OB_NOMOBJET, string SM_TELEPHONE, string PV_CODEPOINTVENTE,   string CL_IDCLIENT, string SMSTEXT,string TE_CODESMSTYPEOPERATION, DateTime SM_DATEPIECE, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {


            ////Processus d'envoi du sms
            clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            clsParams clsParams1 = new clsParams();//BOJ model de retour
            List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            clsSmsoutWSDAL clsSmsoutWSDAL = new clsSmsoutWSDAL();
            clsSmsoutWSBLL clsSmsoutWSBLL = new clsSmsoutWSBLL();
            //string CL_TELEPHONE,  string SMSTEXT,   string SM_DATEEMISSIONSMS,string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2

            Objet = clsSmsoutWSBLL.pvpPreparationSmsSimple(clsDonnee,  AG_CODEAGENCE, OB_NOMOBJET, SM_TELEPHONE, PV_CODEPOINTVENTE,   CL_IDCLIENT, SMSTEXT, TE_CODESMSTYPEOPERATION, SM_DATEPIECE.ToShortDateString(), TYPEOPERATION, SL_LIBELLE1, SL_LIBELLE2);


            try
            {
                //--Preparation d'appel de l'apisms et mise a jour de sms
                //--appel de l'api sms
                if (Objet[0].SL_RESULTAT != "TRUE") return Objet[0];
                clsParamss = clsAppelServiceWeb.excecuteServiceWeb(clsParams, Objet, "post", Stock.WSTOOLS.clsDeclaration.URL_ADRESSE_API_SMS).ToList();
                //--mise a jour du statut de sms 
                if (clsParamss.Count>0)
                {
                    if (clsParamss[0].SL_RESULTAT == "TRUE")
                        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE,DateTime.Parse(SM_DATEPIECE.ToShortDateString()), SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "E", "OK");
                    if (clsParamss[0].SL_RESULTAT == "FALSE")
                    {
                        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), SM_DATEPIECE, Objet[0].SM_NUMSEQUENCE, "N", clsParamss[0].SL_MESSAGE);
                        clsParamss[0].SL_RESULTAT = "FALSE";
                        clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        Objet[0].SL_RESULTAT = clsParamss[0].SL_RESULTAT;
                        Objet[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                    }
                }
                else
                {

                    if (Objet.Count > 0)
                    {
                        clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), Objet[0].SM_NUMSEQUENCE, "N", "");
                        //clsParamss[0].SL_RESULTAT = "FALSE";
                        //clsParamss[0].SL_MESSAGE = clsParamss[0].SL_MESSAGE;
                        Objet[0].SL_RESULTAT = "FALSE";
                        Objet[0].SL_MESSAGE = "e+Echec envoi de sms !!!";
                    }
                    else
                    {
                        clsParams1.SL_CODEMESSAGE = "00";
                        clsParams1.SL_MESSAGE = "e+Echec envoi de sms !!!";
                        clsParams1.SL_RESULTAT = "FALSE";
                        Objet.Add(clsParams1);
                    }

                }
                
            }
            catch (System.Net.WebException ex)
            {
                clsParams1.SL_CODEMESSAGE = "00";
                clsParams1.SL_MESSAGE = ex.Message.ToString();
                clsParams1.SL_RESULTAT = "FALSE";
                Objet.Add(clsParams1);
                clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            catch (Exception ex)
            {
                clsParams1.SL_CODEMESSAGE = "00";
                clsParams1.SL_MESSAGE = ex.Message.ToString();
                clsParams1.SL_RESULTAT = "FALSE";
                Objet.Add(clsParams1);
                clsSmsoutWSDAL.pvgMobileSmsUpdateStatut(clsDonnee, AG_CODEAGENCE, SM_DATEPIECE, DateTime.Parse(SM_DATEPIECE.ToShortDateString()), Objet[0].SM_NUMSEQUENCE, "N", ex.Message.ToString());
            }
            return Objet[0];
        }

        ///<summary>Cette fonction permet de definir les criteres d'une requete avec ou sans criteres (Ordre Criteres :AG_CODEAGENCE, SM_DATEPIECE, SM_NUMSEQUENCE,TE_CODESMSTYPEOPERATION, CO_CODECOMPTE)</summary>
        ///<param name="clsDonnee"> clsDonnee</param>
        ///<param name="vppCritere">Les criteres de la requete</param>
        ///<author>Home Technologie</author>
        public List<clsParams> pvpPreparationSmsSimple(clsDonnee clsDonnee,string AG_CODEAGENCE,string OB_NOMOBJET, string CL_TELEPHONE,string PV_CODEPOINTVENTE, string CL_IDCLIENT, string SMSTEXT,string TE_CODESMSTYPEOPERATION, string SM_DATEEMISSIONSMS, string TYPEOPERATION, string SL_LIBELLE1, string SL_LIBELLE2)
        {
            //Processus d'envoi du sms
            //clsParams clsParams = new clsParams();//BOJ model de retour
            List<clsParams> clsParamss = new List<clsParams>();//liste BOJ selon model retourne
            clsParams clsParams = new clsParams();//liste BOJ selon model retourne
            //List<clsParams> Objet = new List<clsParams>();//BOJ ou liste BOJ envoye   
            List<clsSmsout> clsSmsouts = new List<clsSmsout>();

            clsParams.CodeAgence = AG_CODEAGENCE;
            clsParams.LibelleMouchard = "";
            clsParams.LibelleEcran = "";
            clsParams.LG_CODELANGUE = "FR";
            clsParams.SL_LIBELLE1 = SL_LIBELLE1;
            clsParams.SL_LIBELLE2 = SL_LIBELLE2;
            clsParams.CO_CODECOMPTE = "";
            clsParams.LO_LOGICIEL = "1";
            clsParams.OB_NOMOBJET = OB_NOMOBJET;
            clsParams.SL_VALEURRETOURS = "";
            clsParams.INDICATIF = "";
            clsParams.RECIPIENTPHONE = CL_TELEPHONE;
            clsParams.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
            clsParams.CodeOperateur = "";
            clsParams.SM_DATEPIECE = SM_DATEEMISSIONSMS.Replace("/", "-");
            clsParams.SM_RAISONNONENVOISMS = "";
            clsParams.TYPEOPERATION = TYPEOPERATION;
            clsParams.SMSTEXT = SMSTEXT;
            clsParams.MB_IDTIERS = "";
            clsParams.EJ_IDEPARGNANTJOURNALIER = "";
            clsParams.CL_IDCLIENT = CL_IDCLIENT;
            clsParams.TE_CODESMSTYPEOPERATION = TE_CODESMSTYPEOPERATION;
            clsParams.SM_NUMSEQUENCE = "";
            clsParams.SM_DATEEMISSIONSMS = DateTime.Parse(SM_DATEEMISSIONSMS);
            clsParams.MC_NUMPIECE = "";
            clsParams.MC_NUMSEQUENCE = "";
            clsParams.SM_STATUT = "N";


            clsSmsouts = clsSmsoutWSDAL.pvgMobileSms(clsDonnee, clsParams);

            clsParams.SM_NUMSEQUENCE = clsSmsouts[0].SM_NUMSEQUENCE;
            clsParams.SMSTEXT = clsSmsouts[0].SM_MESSAGE;
            clsParams.RECIPIENTPHONE = clsSmsouts[0].SM_TELEPHONE;
            clsParams.SL_CODEMESSAGE = "99";
            clsParams.SL_MESSAGE = "ok";
            clsParams.SL_RESULTAT = clsSmsouts[0].SL_RESULTAT;



            clsParamss.Add(clsParams);

            return clsParamss;
        }


        ///<summary>Cette fonction permet de generer le mouchard</summary>
        ///<param name="vppAction">Action réalisé</param>
        ///<param name="vppTypeAction">Type d'action</param>
        ///<returns>clsMouchard</returns>
        ///<author>Home Technologie</author>
        public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi,string vppAction, string vppTypeAction)
		{
			clsMouchard clsMouchard = new clsMouchard();
			clsMouchard.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
			clsMouchard.OP_CODEOPERATEUR = clsObjetEnvoi.OE_Y;
			switch (vppTypeAction)
			{
				case "A":
					clsMouchard.MO_ACTION = "SMSOUT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "SMSOUT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "SMSOUT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "SMSOUT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
