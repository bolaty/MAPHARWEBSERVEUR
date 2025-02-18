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
	public class clsPhamouvementstockreglementWSBLL: IObjetWSBLL<clsPhamouvementstockreglement>
	{
		private clsPhamouvementstockreglementWSDAL clsPhamouvementstockreglementWSDAL= new clsPhamouvementstockreglementWSDAL();

		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteCountTestContreinte(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMaxTestContreinte(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }





        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgValueCodeModeReglement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgValueCodeModeReglement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public string pvgSoldeReglement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
            return clsPhamouvementstockreglementWSDAL.pvgSoldeReglement(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public string pvgMontantFacture(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgMontantFacture(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public string pvgMontantFactureTTC(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgMontantFactureTTC(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public string pvgMontantReglementSurFacture(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgMontantReglementSurFacture(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public string pvgSoldeGlobalReglement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgSoldeGlobalReglement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public string pvgSoldeCompteOperateur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgSoldeCompteOperateur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public string pvgTauxRemiseAppliquee(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgTauxRemiseAppliquee(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementstockreglement comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementstockreglement pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}





		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockreglement">clsPhamouvementstockreglement</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockreglement.MV_NUMPIECE = string.Format( "{0:000000000000000000000000000000}" , double.Parse(clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhamouvementstockreglementWSDAL.pvgInsert(clsDonnee, clsPhamouvementstockreglement);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementstockreglementWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
			{
				clsPhamouvementstockreglements[Idx].MV_NUMPIECE = string.Format( "{0:000000000000000000000000000000}" , double.Parse(clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhamouvementstockreglementWSDAL.pvgInsert(clsDonnee, clsPhamouvementstockreglements[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
			}
			return "";
		}

            ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
            ///<param name="clsDonnee">Classe d'acces aux donnees</param>
            ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
            ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
            ///<returns>string</returns>
            ///<author>Home Technology</author>
            public string pvgAjouterListeCharge(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements , clsObjetEnvoi clsObjetEnvoi)
            {
                string MV_NUMPIECERETOUR = "";
                //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

                string VlpNumPiece1 = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglement(clsDonnee, clsPhamouvementstockreglements[0]);
                
                for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
	            {
                    clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
                    clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                    MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee,  clsPhamouvementstockreglements[Idx]);
		            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
	            }
                return MV_NUMPIECERETOUR;
            }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEWEB, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public clsMiccomptewebResultat pvgCreationDetailFacture(clsDonnee clsDonnee, string AG_CODEAGENCE, string DT_NUMEROTRANSACTION, string DT_NUMEROFACTURE, string DT_REFERENCE, string DT_DESIGNATION, string DT_QUANTITE, string DT_PU, string DT_TOTALARTICLE, string DT_TOTALFACTURE, string PY_CODESTATUT, string EJ_IDEPARGNANTJOURNALIER, string NO_CODENATUREVIREMENT, string DT_DATEVALIDATION, string PI_CODEPIECE, string DT_NOMTIERS, string DT_NUMPIECETIERS, string SO_CODESOUSCRIPTION, string TK_TOKEN, string OP_CODEOPERATEUR, string MS_NUMPIECE, string MONTANTFACTURETTC, string TYPEOPERATION)
        {
            return clsPhamouvementstockreglementWSDAL.pvgCreationDetailFacture(clsDonnee, AG_CODEAGENCE, DT_NUMEROTRANSACTION, DT_NUMEROFACTURE, DT_REFERENCE, DT_DESIGNATION, DT_QUANTITE, DT_PU, DT_TOTALARTICLE, DT_TOTALFACTURE, PY_CODESTATUT, EJ_IDEPARGNANTJOURNALIER, NO_CODENATUREVIREMENT, DT_DATEVALIDATION, PI_CODEPIECE, DT_NOMTIERS, DT_NUMPIECETIERS, SO_CODESOUSCRIPTION, TK_TOKEN, OP_CODEOPERATEUR,  MS_NUMPIECE,  MONTANTFACTURETTC, TYPEOPERATION);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete,avec ou sans critères:(Ordre critere:AC_CODEACTIVITE)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsObjetEnvoi.OE_PARAM">Critère de la requête SELECT</param>
        ///<returns>DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgChargerDansDataSetMOBILEDETAILOPERATION(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetMOBILEDETAILOPERATION(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }









        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeChargeAvecRepartition(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
            {
                string MV_NUMPIECERETOUR = "";
                string TI_IDTIERSIMMOBILISATION = "";
                string AG_CODEAGENCE = "";
                string NO_CODENATUREOPERATION = "";

                //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

                string VlpNumPiece1 = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglement(clsDonnee, clsPhamouvementstockreglements[0]);
                
                for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
	            {

                 TI_IDTIERSIMMOBILISATION = clsPhamouvementstockreglements[0].TI_IDTIERSIMMOBILISATION;
                 AG_CODEAGENCE = clsPhamouvementstockreglements[0].AG_CODEAGENCE;
                NO_CODENATUREOPERATION = clsPhamouvementstockreglements[0].NO_CODENATUREOPERATION;
                clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
                    clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                    MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee,  clsPhamouvementstockreglements[Idx]);
		            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
                    if(clsPhamouvementstockreglements[Idx].MV_NUMPIECE !="")
                    clsPhamouvementstockreglementWSDAL.pvgUpduteTemp(clsDonnee,  clsPhamouvementstockreglements[Idx].AG_CODEAGENCE,clsPhamouvementstockreglements[Idx].MV_NUMPIECE, MV_NUMPIECERETOUR);

	            }



                //les articles du mouvementstock
                for (int Idx = 0; Idx < clsPhamouvementstockreglementrepartitions.Count; Idx++)
                {
                    clsPhamouvementstockreglementrepartitions[Idx].MV_NUMPIECE = MV_NUMPIECERETOUR;



                    //clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                    //clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                    //clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                    //insertion dans mouvementStockdetail
                    new clsPhamouvementstockreglementrepartitionWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementrepartitions[Idx]);
                    //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

                    ////GESTION DES ACCESSOIRS OU DES EMBALLAGES
                    //DataSet = new clsPhamouvementStockdetailWSDAL().pvgEMBALLAGE(clsDonnee, clsPhamouvementStockdetails[Idx].AR_CODEARTICLE, clsPhamouvementStock.MS_DATEPIECE.ToShortDateString());

                    //for (int Idx1 = 0; Idx1 <DataSet.Tables[0].Rows.Count; Idx1++)
                    //{

                    //if( clsPhamouvementStockdetails[Idx].MD_QUANTITEENTREE!=0)
                    //{
                    //clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                    //clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREACHAT =double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                    //}

                    //if (clsPhamouvementStockdetails[Idx].MD_QUANTITESORTIE != 0)
                    //{
                    //    clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                    //    clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREVENTE = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                    //}
                    //    //insertion dans mouvementStockdetail
                    //new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                    //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
                    //}

                    //;

                }


            if (NO_CODENATUREOPERATION == "00049")
                clsPhamouvementstockreglementWSDAL.pvgGenererTableauAmortissement( clsDonnee, AG_CODEAGENCE, TI_IDTIERSIMMOBILISATION);

                return MV_NUMPIECERETOUR;
            }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgSuppressionEecritureNonValider(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
        {
            string MV_NUMPIECERETOUR = "";
            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            {
                if (clsPhamouvementstockreglements[Idx].MV_NUMPIECE != "")
                    clsPhamouvementstockreglementWSDAL.pvgUpduteTemp(clsDonnee, clsPhamouvementstockreglements[Idx].AG_CODEAGENCE, clsPhamouvementstockreglements[Idx].MV_NUMPIECE, MV_NUMPIECERETOUR);
            }
            return MV_NUMPIECERETOUR;
        }






        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeChargeAvecRepartitionTEMP(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
        {
            string MV_NUMPIECERETOUR = "";
            string TI_IDTIERSIMMOBILISATION = "";
            string AG_CODEAGENCE = "";
            string NO_CODENATUREOPERATION = "";
            string VlpNumPiece1 = "";
            if (clsPhamouvementstockreglements[0].TYPEOPERATION!=1)
            {
                //clsPhamouvementstockreglementWSDAL.pvgDeleteTemp(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString(), clsPhamouvementstockreglements[0].MV_NUMEROPIECE);
                //new clsPhamouvementstockreglementrepartitionWSDAL().pvgDeleteTEMP(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString(), clsPhamouvementstockreglements[0].MV_NUMEROPIECE, clsPhamouvementstockreglements[0].OP_CODEOPERATEUR);
             VlpNumPiece1 = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglementTEMP(clsDonnee, clsPhamouvementstockreglements[0]);
            }


            //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();



            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
	        {

                TI_IDTIERSIMMOBILISATION = clsPhamouvementstockreglements[0].TI_IDTIERSIMMOBILISATION;
                AG_CODEAGENCE = clsPhamouvementstockreglements[0].AG_CODEAGENCE;
                NO_CODENATUREOPERATION = clsPhamouvementstockreglements[0].NO_CODENATUREOPERATION;
                if (clsPhamouvementstockreglements[0].TYPEOPERATION != 1)
                {
                    clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
                    clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                }

                MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgMiseajourTemp(clsDonnee,  clsPhamouvementstockreglements[Idx]);
                if(clsPhamouvementstockreglements[Idx].TYPEOPERATION == 0)
		             clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
                else
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "M"));
	        }



            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockreglementrepartitions.Count; Idx++)
            {
                clsPhamouvementstockreglementrepartitions[Idx].MV_NUMPIECE = MV_NUMPIECERETOUR;



                //clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                //clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                //clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockreglementrepartitionWSDAL().pvgInsertTEMP(clsDonnee, clsPhamouvementstockreglementrepartitions[Idx]);
                //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

                ////GESTION DES ACCESSOIRS OU DES EMBALLAGES
                //DataSet = new clsPhamouvementStockdetailWSDAL().pvgEMBALLAGE(clsDonnee, clsPhamouvementStockdetails[Idx].AR_CODEARTICLE, clsPhamouvementStock.MS_DATEPIECE.ToShortDateString());

                //for (int Idx1 = 0; Idx1 <DataSet.Tables[0].Rows.Count; Idx1++)
                //{

                //if( clsPhamouvementStockdetails[Idx].MD_QUANTITEENTREE!=0)
                //{
                //clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                //clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREACHAT =double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                //}

                //if (clsPhamouvementStockdetails[Idx].MD_QUANTITESORTIE != 0)
                //{
                //    clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                //    clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREVENTE = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                //}
                //    //insertion dans mouvementStockdetail
                //new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
                //}

                //;

            }


        //if (NO_CODENATUREOPERATION == "00049")
        //    clsPhamouvementstockreglementWSDAL.pvgGenererTableauAmortissement( clsDonnee, AG_CODEAGENCE, TI_IDTIERSIMMOBILISATION);

            return MV_NUMPIECERETOUR;
        }



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgLettrage(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        {
            string MV_NUMPIECERETOUR = "";
            string TI_IDTIERSIMMOBILISATION = "";
            string AG_CODEAGENCE = "";
            string NO_CODENATUREOPERATION = "";


                
            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
	        {

                TI_IDTIERSIMMOBILISATION = clsPhamouvementstockreglements[0].TI_IDTIERSIMMOBILISATION;
                AG_CODEAGENCE = clsPhamouvementstockreglements[0].AG_CODEAGENCE;
                NO_CODENATUREOPERATION = clsPhamouvementstockreglements[0].NO_CODENATUREOPERATION;
                //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
                clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
               clsPhamouvementstockreglementWSDAL.pvgLettrage(clsDonnee,  clsPhamouvementstockreglements[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
	        }



           

            return "";
        }






            public string pvgComptabilisationImmo(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
            {
                string MV_NUMPIECERETOUR = "";
                MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));

                return MV_NUMPIECERETOUR;
            }



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter1(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsPhamouvementstockreglement.MV_NUMPIECE = string.Format("{0:000000000000000000000000000000}", double.Parse(clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
            clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));

            //Insertion des chèques
            for (int Idx = 0; Idx < clsPhamouvementstockreglementcheques.Count; Idx++)
            {
                
                new clsPhamouvementstockreglementchequeWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementcheques[Idx]);
                //
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementcheques[Idx].MS_NUMPIECE.ToString(), "A"));
            }


            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter2(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, clsObjetEnvoi clsObjetEnvoi)
        {
            string MV_NUMPIECERETOUR = "";
            string VlpNumPiece = (double.Parse(clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMaxNumPiece(clsDonnee)) + 1).ToString();
             for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            {
            clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece;
            MV_NUMPIECERETOUR= clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
            }
            //Insertion des chèques
            for (int Idx = 0; Idx < clsPhamouvementstockreglementcheques.Count; Idx++)
            {

                new clsPhamouvementstockreglementchequeWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementcheques[Idx]);
                //
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementcheques[Idx].MS_NUMPIECE.ToString(), "A"));
            }


            return MV_NUMPIECERETOUR;
        }



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        ///

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SR_DATEPIECE, SR_NUMPIECE, SR_NUMSEQUENCE ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsEc_inscriptionscolaritereglement">clsEc_inscriptionscolaritereglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgVerificatioSoldeCompteAvecChequeDiffere(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementstockreglementWSDAL.pvgVerificatioSoldeCompteAvecChequeDiffere(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi.OE_PARAM);
            return "";
        }



        public string pvgAjouterComptabilisation(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse, List<clsCtcontratchequephotoreglementcaisse> clsCtcontratchequephotoreglementcaisses, clsObjetEnvoi clsObjetEnvoi)
        {

            //clsCtcontratchequereglementcaisse clsCtcontratchequereglementcaisse, List< clsCtcontratchequephotoreglementcaisse > clsCtcontratchequephotoreglementcaisses,
            string MV_NUMPIECERETOUR = "";
            //string VlpNumPiece = (double.Parse(clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMaxNumPiece(clsDonnee)) + 1).ToString();
            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //{
                //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece;


            if (clsPhamouvementstockreglementcheques.Count == 0)
            {
                MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
                clsMobiledetailoperationtontine clsMobiledetailoperationtontine = new clsMobiledetailoperationtontine();
                if (MV_NUMPIECERETOUR != "" && clsPhamouvementstockreglement.DT_NUMEROTRANSACTION!="")
                {
                    clsMobiledetailoperationtontine.AG_CODEAGENCE = clsPhamouvementstockreglement.AG_CODEAGENCE;
                    clsMobiledetailoperationtontine.DT_DATEVALIDATION = clsPhamouvementstockreglement.MV_DATEPIECE.ToShortDateString();
                    clsMobiledetailoperationtontine.DT_NUMEROTRANSACTION = clsPhamouvementstockreglement.DT_NUMEROTRANSACTION;
                    clsPhamouvementstockreglementWSDAL.pvgUpdateStatutOperation(clsDonnee, clsMobiledetailoperationtontine, clsMobiledetailoperationtontine.AG_CODEAGENCE, clsMobiledetailoperationtontine.DT_NUMEROTRANSACTION);
                }
               

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
            }
            else
            {


                string VlpNumPiece = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglement(clsDonnee, clsPhamouvementstockreglement); 
                
                //Insertion des chèques
                for (int Idx = 0; Idx < clsPhamouvementstockreglementcheques.Count; Idx++)
                {
                    clsPhamouvementstockreglement.MV_NUMEROPIECE = VlpNumPiece;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsPhamouvementstockreglementcheques[Idx].RC_VALEURCHEQUE.ToString());
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementcheques[Idx].RC_NUMEROCHEQUE.ToString();
                    MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
                    //new clsPhamouvementstockreglementchequeWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementcheques[Idx]);
                    ////
                    //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementcheques[Idx].MS_NUMPIECE.ToString(), "A"));
                }

                if(clsCtcontratchequereglementcaisse!=null)
                {
                    clsCtcontratchequereglementcaisseWSDAL clsCtcontratchequereglementcaisseWSDAL = new clsCtcontratchequereglementcaisseWSDAL();
                    string vlpCHC_IDEXCHEQUERETOUR = "";
                    clsCtcontratchequereglementcaisse.MV_NUMPIECE = MV_NUMPIECERETOUR;
                    vlpCHC_IDEXCHEQUERETOUR =clsCtcontratchequereglementcaisseWSDAL.pvgMiseAJour(clsDonnee, clsCtcontratchequereglementcaisse);

                    //Insertion des photos chèques
                    // Sppression des données existantes avant insertion dans la base de données 
                    clsCtcontratchequephotoreglementcaisseWSDAL clsCtcontratchequephotoreglementcaisseWSDAL = new clsCtcontratchequephotoreglementcaisseWSDAL();
                    if(clsCtcontratchequephotoreglementcaisses.Count>0)
                    clsCtcontratchequephotoreglementcaisseWSDAL.pvgDeleteListe(clsDonnee, clsCtcontratchequephotoreglementcaisses[0].AG_CODEAGENCE, clsCtcontratchequephotoreglementcaisses[0].CHC_DATESAISIECHEQUE.ToShortDateString(), clsCtcontratchequephotoreglementcaisses[0].CHC_IDEXCHEQUE);
                    if (clsCtcontratchequephotoreglementcaisses != null)
                    {
                        for (int Idx = 0; Idx < clsCtcontratchequephotoreglementcaisses.Count; Idx++)
                        {
                            clsCtcontratchequephotoreglementcaisses[Idx].CHC_IDEXCHEQUE = vlpCHC_IDEXCHEQUERETOUR;
                            string vlpIndex = "";
                            string vlpFichier = clsCtcontratchequephotoreglementcaisses[Idx].CHC_CHEMINPHOTOCHEQUE;
                            clsCtcontratchequephotoreglementcaisses[Idx].CHC_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisses[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_IDEXCHEQUE;
                            clsCtcontratchequephotoreglementcaisses[Idx].TYPEOPERATION = 0;
                            vlpIndex = clsCtcontratchequephotoreglementcaisseWSDAL.pvgMiseAJour(clsDonnee, clsCtcontratchequephotoreglementcaisses[Idx]);

                            clsCtcontratchequephotoreglementcaisseWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, "CHEQ_" + clsCtcontratchequephotoreglementcaisses[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtcontratchequephotoreglementcaisses[Idx].CHC_IDEXCHEQUE + "_" + vlpIndex, "PHOT1");

                            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephotoreglementcaisses[Idx].AG_CODEAGENCE.ToString(), "A"));
                        }
                    }
                   

                }
                

                

                

            }


            return MV_NUMPIECERETOUR;
        }


        public string pvgAjouterComptabilisationAvecRepartition(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
        {
            string MV_NUMPIECERETOUR = "";
            //string VlpNumPiece = (double.Parse(clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMaxNumPiece(clsDonnee)) + 1).ToString();
            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //{
            //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece;


            if (clsPhamouvementstockreglementcheques.Count == 0)
            {
                MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
            }
            else
            {


                string VlpNumPiece = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglement(clsDonnee, clsPhamouvementstockreglement);

                //Insertion des chèques
                for (int Idx = 0; Idx < clsPhamouvementstockreglementcheques.Count; Idx++)
                {
                    clsPhamouvementstockreglement.MV_NUMEROPIECE = VlpNumPiece;
                    clsPhamouvementstockreglement.MONTANTVERSEMENT = double.Parse(clsPhamouvementstockreglementcheques[Idx].RC_VALEURCHEQUE.ToString());
                    clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementstockreglementcheques[Idx].RC_NUMEROCHEQUE.ToString();
                    MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
                    //new clsPhamouvementstockreglementchequeWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementcheques[Idx]);
                    ////
                    //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementcheques[Idx].MS_NUMPIECE.ToString(), "A"));
                }
            }


            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockreglementrepartitions.Count; Idx++)
            {
                clsPhamouvementstockreglementrepartitions[Idx].MV_NUMPIECE = MV_NUMPIECERETOUR;



                //clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                //clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                //clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockreglementrepartitionWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementrepartitions[Idx]);
                //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

                ////GESTION DES ACCESSOIRS OU DES EMBALLAGES
                //DataSet = new clsPhamouvementStockdetailWSDAL().pvgEMBALLAGE(clsDonnee, clsPhamouvementStockdetails[Idx].AR_CODEARTICLE, clsPhamouvementStock.MS_DATEPIECE.ToShortDateString());

                //for (int Idx1 = 0; Idx1 <DataSet.Tables[0].Rows.Count; Idx1++)
                //{

                //if( clsPhamouvementStockdetails[Idx].MD_QUANTITEENTREE!=0)
                //{
                //clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                //clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREACHAT =double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                //}

                //if (clsPhamouvementStockdetails[Idx].MD_QUANTITESORTIE != 0)
                //{
                //    clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                //    clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREVENTE = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                //}
                //    //insertion dans mouvementStockdetail
                //new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
                //}

                //;

            }


            return MV_NUMPIECERETOUR;
        }



        //public string pvgAjouterListeCharge(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    string MV_NUMPIECERETOUR = "";
        //    string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();
        //    for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
        //    {
        //        clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
        //        clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
        //        MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
        //        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
        //    }
        //    return MV_NUMPIECERETOUR;
        //}



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhamouvementstockreglements"> Liste d'objet clsPhamouvementstockreglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterComptabilisationReglementCommissionCommercial(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, List<clsPhamouvementstockreglementcheque> clsPhamouvementstockreglementcheques, List<clsPhamouvementstockreglementcommercial> clsPhamouvementstockreglementcommercials, clsObjetEnvoi clsObjetEnvoi)
        {
            string MV_NUMPIECERETOUR = "";


            string VlpNumPiece1 = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglement(clsDonnee, clsPhamouvementstockreglements[0]);
            if (clsPhamouvementstockreglementcheques.Count == 0)
            {
                for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
                {
                    clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
                    clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                    MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
                }
            }
            else
            {

                for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
                {
                    for (int i = 0; i < clsPhamouvementstockreglementcheques.Count; i++)
                    {
                        clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece1;
                        clsPhamouvementstockreglements[Idx].MV_MONTANTDEBIT =clsPhamouvementstockreglements[Idx].MV_MONTANTDEBIT==0? 0 : double.Parse(clsPhamouvementstockreglementcheques[i].RC_VALEURCHEQUE.ToString());
                        clsPhamouvementstockreglements[Idx].MV_MONTANTCREDIT = clsPhamouvementstockreglements[Idx].MV_MONTANTCREDIT == 0 ? 0 : double.Parse(clsPhamouvementstockreglementcheques[i].RC_VALEURCHEQUE.ToString());
                        clsPhamouvementstockreglements[Idx].MV_REFERENCEPIECE = clsPhamouvementstockreglementcheques[i].RC_NUMEROCHEQUE.ToString();
                        clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                        MV_NUMPIECERETOUR = clsPhamouvementstockreglementWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
                        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));

                    }
                }


            }






          
            ////Insertion des chèques
            //for (int Idx = 0; Idx < clsPhamouvementstockreglementcheques.Count; Idx++)
            //{

            //    new clsPhamouvementstockreglementchequeWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockreglementcheques[Idx]);
            //    //
            //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementcheques[Idx].MS_NUMPIECE.ToString(), "A"));
            //}
            for (int Idx = 0; Idx < clsPhamouvementstockreglementcommercials.Count; Idx++)
            {

                new clsPhamouvementstockreglementcommercialWSDAL().pvgInsert1(clsDonnee, clsPhamouvementstockreglementcommercials[Idx]);
                //
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglementcommercials[Idx].MS_NUMPIECE.ToString(), "A"));
            }

            return MV_NUMPIECERETOUR;
        }




		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementstockreglement">clsPhamouvementstockreglement</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockreglementWSDAL.pvgUpdate(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "M"));
			return "";
		}



        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SR_DATEPIECE, SR_NUMPIECE, SR_NUMSEQUENCE ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsEc_inscriptionscolaritereglement">clsEc_inscriptionscolaritereglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgExtourne(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementstockreglement.MV_NUMPIECE1 = clsPhamouvementstockreglementWSDAL.pvgIncrementmvtstockreglement(clsDonnee, clsPhamouvementstockreglement);
            clsPhamouvementstockreglementWSDAL.pvgExtourne(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.AG_CODEAGENCE.ToString(), "M"));
            return "";
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsEc_inscriptionscolaritereglements"> Liste d'objet clsEc_inscriptionscolaritereglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMajReferencePiece(clsDonnee clsDonnee, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
            //clsEc_inscriptionscolaritereglementWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            {
                //clsEc_inscriptionscolaritereglements[Idx].AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsEc_inscriptionscolaritereglementWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsPhamouvementstockreglementWSDAL.pvgMajReferencePiece(clsDonnee, clsPhamouvementstockreglements[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].AG_CODEAGENCE.ToString(), "A"));
            }


            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementstockreglementWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementstockreglement </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglement> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementstockreglement </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementstockreglement> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetListeReferencePiece(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetListeReferencePiece(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetSoldeCompteEcranOD(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetSoldeCompteEcranOD(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgMouvementResumeReglement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgMouvementResumeReglement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgEtatMouvementStockReglementTemp(clsDonnee clsDonnee, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgEtatMouvementStockReglementTemp(clsDonnee, clsPhamouvementstockreglement, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgMouvementResumeReglementGeneral(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgMouvementResumeReglementGeneral(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, SR_DATEPIECE, SR_NUMPIECE, SR_NUMSEQUENCE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public string pvgNumeroBordereau(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgNumeroBordereau(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRecudeCaisse(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetRecudeCaisse(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRecudeCaisseTemp(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetRecudeCaisseTemp(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : MV_NUMPIECE, AG_CODEAGENCE, MR_CODEMODEREGLEMENT, MS_NUMPIECE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRegmentGroupeListe(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetRegmentGroupeListe(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AG_CODEAGENCE, MC_DATEPIECE, MC_NUMPIECE, MC_NUMSEQUENCE, MR_CODEMODEREGLEMENT, JO_CODEJOURNAL, CO_CODECOMPTE, PL_CODENUMCOMPTE, PI_CODEPIECE, TS_CODETYPESCHEMACOMPTABLE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetRecherche(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgChargerDansDataSetRecherche(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public string pvgGenererTableauAmortissement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementstockreglementWSDAL.pvgGenererTableauAmortissement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SL_CODECOMPTEZenithMobile, AG_CODEAGENCE, CO_CODECOMPTE, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Une collection de clsMiccompteweb </returns>
        ///<author>Home Technology</author>
        public void pvgUpdateStatutOperation(clsDonnee clsDonnee, clsMobiledetailoperationtontine clsMobiledetailoperationtontine, params string[] vppCritere)
        {
            clsPhamouvementstockreglementWSDAL.pvgUpdateStatutOperation(clsDonnee, clsMobiledetailoperationtontine, vppCritere);
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
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAMOUVEMENTSTOCKREGLEMENT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
