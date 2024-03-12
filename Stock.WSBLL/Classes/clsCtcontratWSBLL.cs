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
	public class clsCtcontratWSBLL: IObjetWSBLL<clsCtcontrat>
	{
		private clsCtcontratWSDAL clsCtcontratWSDAL= new clsCtcontratWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontrat comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontrat pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontrat">clsCtcontrat</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat , clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratWSDAL.pvgInsert(clsDonnee, clsCtcontrat);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontrat.CA_CODECONTRAT.ToString(), "A"));
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtcontrat">clsCtcontrat</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseAjour(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat , List<clsCtcontratgarantie> clsCtcontratgaranties,  List<clsCtcontratprime> clsCtcontratprimes,List<clsCtcontratreduction> clsCtcontratreductions,List<clsCtcontratayantdroit> clsCtcontratayantdroits,List<clsCtcontratcapitaux> clsCtcontratcapitauxs, clsObjetEnvoi clsObjetEnvoi)
        {
            clsCtcontratprimeWSDAL clsCtcontratprimeWSDAL = new clsCtcontratprimeWSDAL();
            clsCtcontratgarantieWSDAL clsCtcontratgarantieWSDAL = new clsCtcontratgarantieWSDAL();
            clsCtcontratreductionWSDAL clsCtcontratreductionWSDAL = new clsCtcontratreductionWSDAL();
            clsCtcontratayantdroitWSDAL clsCtcontratayantdroitWSDAL = new clsCtcontratayantdroitWSDAL();
            clsCtcontratcapitauxWSDAL clsCtcontratcapitauxWSDAL = new clsCtcontratcapitauxWSDAL();
            clsCtcontratdemandecreationWSBLL clsCtcontratdemandecreationWSBLL = new clsCtcontratdemandecreationWSBLL();
            if (clsCtcontrat.RQ_CODERISQUE == "04" || clsCtcontrat.RQ_CODERISQUE == "08" || clsCtcontrat.RQ_CODERISQUE == "09" || clsCtcontrat.RQ_CODERISQUE == "10")
            {
                clsCtpargarantieWSDAL clsCtpargarantieWSDAL = new clsCtpargarantieWSDAL();
                clsCtpargarantie clsCtpargarantie = new clsCtpargarantie();
                string vlpGA_CODEGARANTIE = "";
               

                DataSet vlpDataSet = new DataSet();
                vlpDataSet = clsCtpargarantieWSDAL.pvgChargerDansDataSetParDefaut(clsDonnee, "O");
                if (vlpDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in vlpDataSet.Tables[0].Rows)
                    {
                        vlpGA_CODEGARANTIE=row["GA_CODEGARANTIE"].ToString();
                    }
                }

                if(string.IsNullOrEmpty(vlpGA_CODEGARANTIE))
                //try
                //{
                    throw new Exception("La garantie par defaut doit être configurée !!!");
                //}
                //catch { return "La garantie par defaut doit être configurée !!!"; }
                
                clsCtcontratgarantie clsCtcontratgarantie = new clsCtcontratgarantie();
                clsCtcontratgarantie.AG_CODEAGENCE = clsCtcontrat.AG_CODEAGENCE;
                clsCtcontratgarantie.EN_CODEENTREPOT = clsCtcontrat.EN_CODEENTREPOT;
                clsCtcontratgarantie.CG_APRESREDUCTION = 0;
                clsCtcontratgarantie.CG_PRORATA = 0;
                clsCtcontratgarantie.CG_CAPITAUXASSURES = 0;
                clsCtcontratgarantie.CG_PRIMES = 0;
                clsCtcontratgarantie.CG_FRANCHISES = "";
                clsCtcontratgarantie.CG_TAUX = 0;
                clsCtcontratgarantie.CG_MONTANT = 0;
                clsCtcontratgarantie.CG_LIBELLE = "";
                clsCtcontratgarantie.GA_CODEGARANTIE = vlpGA_CODEGARANTIE;// "99999";
                clsCtcontratgarantie.CG_GARANTIE = "N";
                clsCtcontratgaranties.Add(clsCtcontratgarantie);
            }
            if(clsCtcontratgaranties.Count>0)
            clsCtcontrat.GA_CODEGARANTIE = clsCtcontratgaranties[0].GA_CODEGARANTIE;
            string vlpCA_CODECONTRATRETOUR = clsCtcontratWSDAL.pvgMiseAjour(clsDonnee, clsCtcontrat);



            if (clsCtcontrat.TYPEOPERATION !=15)
            {
                        // Sppression des données existantes avant insertion dans la base de données 
                        clsCtcontratgarantieWSDAL.pvgDelete(clsDonnee, clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, vlpCA_CODECONTRATRETOUR);
                        for (int Idx = 0; Idx < clsCtcontratgaranties.Count; Idx++)
                        {
                            clsCtcontratgaranties[Idx].CA_CODECONTRAT = vlpCA_CODECONTRATRETOUR;
                            clsCtcontratgarantieWSDAL.pvgInsert(clsDonnee, clsCtcontratgaranties[Idx]);
                        }

                        // Sppression des données existantes avant insertion dans la base de données 
                        clsCtcontratreductionWSDAL.pvgDelete(clsDonnee, clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, vlpCA_CODECONTRATRETOUR);
                        for (int Idx = 0; Idx < clsCtcontratreductions.Count; Idx++)
                        {
                            clsCtcontratreductions[Idx].CA_CODECONTRAT = vlpCA_CODECONTRATRETOUR;
                            clsCtcontratreductionWSDAL.pvgInsert(clsDonnee, clsCtcontratreductions[Idx]);
                        }

                        // Sppression des données existantes avant insertion dans la base de données 
                        clsCtcontratprimeWSDAL.pvgDelete(clsDonnee, clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, vlpCA_CODECONTRATRETOUR);

                        for (int Idx = 0; Idx < clsCtcontratprimes.Count; Idx++)
                        {
                            clsCtcontratprimes[Idx].CA_CODECONTRAT = vlpCA_CODECONTRATRETOUR;
                            clsCtcontratprimes[Idx].CM_DATEPIECE = clsCtcontrat.CA_DATESAISIE;
                            clsCtcontratprimes[Idx].OP_CODEOPERATEUR = clsCtcontrat.OP_CODEOPERATEUR;
                            clsCtcontratprimeWSDAL.pvgInsert(clsDonnee, clsCtcontratprimes[Idx]);
                        }

                        // Sppression des données existantes avant insertion dans la base de données 
                        clsCtcontratayantdroitWSDAL.pvgDeleteSelonCT(clsDonnee, clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, vlpCA_CODECONTRATRETOUR);

                        for (int Idx = 0; Idx < clsCtcontratayantdroits.Count; Idx++)
                        {
                            clsCtcontratayantdroits[Idx].CA_CODECONTRAT = vlpCA_CODECONTRATRETOUR;
                            clsCtcontratayantdroitWSDAL.pvgInsert(clsDonnee, clsCtcontratayantdroits[Idx]);
                        }
                        // Sppression des données existantes avant insertion dans la base de données 
                        clsCtcontratcapitauxWSDAL.pvgDelete(clsDonnee, clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, vlpCA_CODECONTRATRETOUR);

                        for (int Idx = 0; Idx < clsCtcontratcapitauxs.Count; Idx++)
                        {
                            clsCtcontratcapitauxs[Idx].CA_CODECONTRAT = vlpCA_CODECONTRATRETOUR;
                            clsCtcontratcapitauxWSDAL.pvgInsert(clsDonnee, clsCtcontratcapitauxs[Idx]);
                        }

                        if (clsCtcontrat.DE_CODEDEMANADE != "" && (clsCtcontrat.TYPEOPERATION== 0 || clsCtcontrat.TYPEOPERATION== 16) )//--//--validation de mande 
                        {
                            clsCtcontratdemandecreation clsCtcontratdemandecreation = new clsCtcontratdemandecreation();
                            clsCtcontratdemandecreation.TYPEOPERATION = "3";
                            clsCtcontratdemandecreation.DE_CODEDEMANADE = clsCtcontrat.DE_CODEDEMANADE;
                            clsCtcontratdemandecreation.CA_CODECONTRAT = vlpCA_CODECONTRATRETOUR;
                            clsCtcontratdemandecreation.DE_DATEVALIDATION = clsCtcontrat.CA_DATESAISIE;
                            clsCtcontratdemandecreationWSBLL.pvgUpdateAnnulationDemande(clsDonnee, clsCtcontratdemandecreation, clsObjetEnvoi);
                        }
            }


           


            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontrat.CA_CODECONTRAT.ToString(), "A"));
	        return vlpCA_CODECONTRATRETOUR;
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtcontrat">clsCtcontrat</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseAjourPrimeContrat(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat ,  List<clsCtcontratprime> clsCtcontratprimes, clsObjetEnvoi clsObjetEnvoi)
        {
            clsCtcontratprimeWSDAL clsCtcontratprimeWSDAL = new clsCtcontratprimeWSDAL();
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtcontratprimeWSDAL.pvgDelete(clsDonnee, clsCtcontrat.AG_CODEAGENCE, clsCtcontrat.EN_CODEENTREPOT, clsCtcontrat.CA_CODECONTRAT);
            for (int Idx = 0; Idx < clsCtcontratprimes.Count; Idx++)
            {
                clsCtcontratprimes[Idx].CA_CODECONTRAT = clsCtcontrat.CA_CODECONTRAT;
                clsCtcontratprimes[Idx].CM_DATEPIECE = clsCtcontrat.CA_DATESAISIE;
                clsCtcontratprimes[Idx].OP_CODEOPERATEUR = clsCtcontrat.OP_CODEOPERATEUR;
                clsCtcontratprimeWSDAL.pvgInsert(clsDonnee, clsCtcontratprimes[Idx]);
            }

            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontrat.CA_CODECONTRAT.ToString(), "A"));
            return clsCtcontrat.CA_CODECONTRAT;
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtcontrat">clsCtcontrat</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseAjourStatutContrat(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat, clsObjetEnvoi clsObjetEnvoi)
        {
            string vlpCA_CODECONTRATRETOUR = clsCtcontratWSDAL.pvgMiseAjour(clsDonnee, clsCtcontrat);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontrat.CA_CODECONTRAT.ToString(), "A"));
            return vlpCA_CODECONTRATRETOUR;
        }




        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtcontrats"> Liste d'objet clsCtcontrat</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtcontrat> clsCtcontrats , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsCtcontratWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsCtcontrats.Count; Idx++)
			{
				clsCtcontratWSDAL.pvgInsert(clsDonnee, clsCtcontrats[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontrats[Idx].CA_CODECONTRAT.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontrat">clsCtcontrat</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCtcontrat clsCtcontrat,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratWSDAL.pvgUpdate(clsDonnee, clsCtcontrat, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontrat.CA_CODECONTRAT.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            //=======
            clsCtcontratprimeWSDAL clsCtcontratprimeWSDAL = new clsCtcontratprimeWSDAL();
            clsCtcontratgarantieWSDAL clsCtcontratgarantieWSDAL = new clsCtcontratgarantieWSDAL();
            clsCtcontratreductionWSDAL clsCtcontratreductionWSDAL = new clsCtcontratreductionWSDAL();
            clsCtcontratayantdroitWSDAL clsCtcontratayantdroitWSDAL = new clsCtcontratayantdroitWSDAL();
            clsCtcontratcapitauxWSDAL clsCtcontratcapitauxWSDAL = new clsCtcontratcapitauxWSDAL();
            //=======
            string vlpAG_CODEAGENCE = clsObjetEnvoi.OE_PARAM[0];
            string vlpEN_CODEENTREPOT = clsObjetEnvoi.OE_PARAM[1];
            string vlpCA_CODECONTRAT = clsObjetEnvoi.OE_PARAM[2];
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtcontratreductionWSDAL.pvgDelete(clsDonnee, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT, vlpCA_CODECONTRAT);
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtcontratgarantieWSDAL.pvgDelete(clsDonnee, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT, vlpCA_CODECONTRAT);
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtcontratprimeWSDAL.pvgDelete(clsDonnee, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT, vlpCA_CODECONTRAT);
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtcontratayantdroitWSDAL.pvgDeleteSelonCT(clsDonnee, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT, vlpCA_CODECONTRAT);
            // Sppression des données existantes avant insertion dans la base de données 
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtcontratcapitauxWSDAL.pvgDelete(clsDonnee, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT, vlpCA_CODECONTRAT);
            //=======



            clsCtcontratWSDAL.pvgDelete(clsDonnee, vlpCA_CODECONTRAT, vlpAG_CODEAGENCE, vlpEN_CODEENTREPOT );
            
            string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtcontrat </returns>
		///<author>Home Technology</author>
		public List<clsCtcontrat> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontrat </returns>
		///<author>Home Technology</author>
		public List<clsCtcontrat> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetMontantFacture(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgChargerDansDataSetMontantFacture(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : CA_CODECONTRAT, AG_CODEAGENCE, IT_CODEINTERMEDIAIRE, AP_CODETYPEAPPARTEMENT, OC_CODETYPEOCCUPANT, CB_IDBRANCHE, OP_CODEOPERATEUR, ST_CODESTATUTSOCIOPROF, DU_CODEDUREE, AU_CODECATEGORIE, TA_CODETARIF, US_CODEUSAGE, GE_CODEGENRE, EN_CODEENERGIE, DI_CODEDESIGNATION, CA_CODECONTRATSECONDAIRE, CO_CODECOMMUNE, RQ_CODERISQUE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPARID(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsCtcontratWSDAL.pvgChargerDansDataSetPARID(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CTCONTRAT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CTCONTRAT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CTCONTRAT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CTCONTRAT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
