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
	public class clsPhamouvementStockWSBLL: IObjetWSBLL<clsPhamouvementStock>
	{
		private string vapCritere = "";
		private string vapRequete = "";
        private string  vlpNumPiece1 = "";
		private clsPhamouvementStockWSDAL clsPhamouvementStockWSDAL= new clsPhamouvementStockWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        public string pvgValueScalarRequeteCountCommande(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgValueScalarRequeteCountCommande(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        public string pvgValeurScalaireRequeteCountLivraison(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgValeurScalaireRequeteCountLivraison(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public string pvgValeurScalaireRequeteMaxNumSequence(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return (double.Parse(clsPhamouvementStockWSDAL.pvgNumsequenceMaxValue(clsDonnee, clsObjetEnvoi.OE_PARAM)) + 1).ToString();
        }

        public string pvgGetNumeroBordereau(clsDonnee clsDonnee, string vppNatureOperation, DateTime vppDate, double vppNumSequence, clsObjetEnvoi clsObjetEnvoi)
        {
            string NumeroBordereau = vppNatureOperation + string.Format("{0:0000}", vppDate.Year) + string.Format("{0:00}", vppDate.Month) + string.Format("{0:00}", vppDate.Day) + string.Format("{0:0000}", vppNumSequence);
            return NumeroBordereau;
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStock comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStock pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStock">clsPhamouvementStock</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStock.MS_NUMPIECE = ( double.Parse(clsPhamouvementStockWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            clsPhamouvementStock.MS_NUMSEQUENCE = double.Parse(clsPhamouvementStockWSDAL.pvgNumsequenceMaxValue(clsDonnee,clsObjetEnvoi.OE_A,clsObjetEnvoi.OE_J.ToShortDateString())) + 1;
			clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStocks"> Liste d'objet clsPhamouvementStock</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementStock> clsPhamouvementStocks , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementStockWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementStocks.Count; Idx++)
			{
                clsPhamouvementStocks[Idx].MS_NUMPIECE = (double.Parse(clsPhamouvementStockWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                clsPhamouvementStocks[Idx].MS_NUMSEQUENCE = double.Parse(clsPhamouvementStockWSDAL.pvgNumsequenceMaxValue(clsDonnee, clsObjetEnvoi.OE_A, clsObjetEnvoi.OE_J.ToShortDateString())) + 1;
                clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStocks[Idx]);

				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStocks[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsObjetEnvoi clsObjetEnvoi)
        {

            clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            clsPhamouvementStock.MS_NUMPIECE1 = vlpNumPiece1;
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            vlpNumPiece1 = vlpNumPiece;
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                //
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
            }

            return "";
        }

        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStock(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails,clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {

            double vlpCreditTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            double vlpDebitTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
            //clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
            }

            
            clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            clsPhamouvementstockreglement.TYPEOPERATION = 0;
            //-VENTE AVEC REGLEMENT
            if (vlpDebitTemp != 0 && clsPhamouvementStock.MS_MONTANTTOTALREMISE != 0)
            {
                double vlpTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = vlpTemp + clsPhamouvementStock.MS_MONTANTTOTALREMISE;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "03"; //montant de la vente 
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

                //clsPhamouvementstockreglement.MV_MONTANTDEBIT =  0;
                //clsPhamouvementstockreglement.MV_MONTANTCREDIT = vlpTemp;
                //clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "02";  //montant de la  remise
                //new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

            }
            //-APPRO AVEC REGLEMENT
            if (vlpCreditTemp != 0 && clsPhamouvementStock.MS_MONTANTTOTALREMISE != 0)
            {
                double vlpTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = vlpTemp + clsPhamouvementStock.MS_MONTANTTOTALREMISE;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "04"; //montant de la vente 
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

                //clsPhamouvementstockreglement.MV_MONTANTDEBIT =  0;
                //clsPhamouvementstockreglement.MV_MONTANTCREDIT = vlpTemp;
                //clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "02";  //montant de la  remise
                //new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

            }

            //-APPRO OU VENTE SANS REMISE NI VERSEMENT
            else
            {
                if ((vlpCreditTemp == 0 && vlpDebitTemp != 0) || (vlpCreditTemp != 0 && vlpDebitTemp == 0) && (clsPhamouvementStock.MS_MONTANTTOTALREMISE == 0 && clsPhamouvementStock.MS_MONTANTVERSE == 0))

                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
            }

            
            //-REMISE SUR ACHAT
            if (clsPhamouvementStock.MS_MONTANTTOTALREMISE != 0 && vlpCreditTemp != 0)
            {
                clsPhamouvementstockreglement.TYPEOPERATION = 0;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = clsPhamouvementStock.MS_MONTANTTOTALREMISE;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "02";//Montant réglement
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
            }


            //-REMISE SUR VENTE
            if (clsPhamouvementStock.MS_MONTANTTOTALREMISE != 0 && vlpDebitTemp != 0)
            {
                clsPhamouvementstockreglement.TYPEOPERATION = 0;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = clsPhamouvementStock.MS_MONTANTTOTALREMISE;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "02";//Montant réglement
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
            }

            //-MONTANT REGLE AU COURS DE L'APPRO

            if (clsPhamouvementStock.MS_MONTANTVERSE != 0 && vlpDebitTemp != 0)
            {
                clsPhamouvementstockreglement.TYPEOPERATION = 0;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT =0;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT =  clsPhamouvementStock.MS_MONTANTVERSE;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "01";//Montant réglement
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
            }

            //-MONTANT REGLE AU COURS DE LA VENTE
            if (clsPhamouvementStock.MS_MONTANTVERSE != 0 && vlpCreditTemp != 0)
            {
                clsPhamouvementstockreglement.TYPEOPERATION = 0;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = clsPhamouvementStock.MS_MONTANTVERSE;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "01";//Montant réglement
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
            }

            return vlpNumPiece ;
        }




        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStock(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        {
            DataSet DataSet = new DataSet();
            //double vlpCreditTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            //double vlpDebitTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
            //clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;

                

                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
                
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

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

            //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            {

                VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
                if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
                { VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString(); }
                else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
                VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;


                clsPhamouvementstockreglements[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
                clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
            }

            return vlpNumPiece;
        }




        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockFabrication(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStockMatiersPremiere, List<clsPhamouvementStockdetail> clsPhamouvementStockMatiersPremieredetails, clsPhamouvementStock clsPhamouvementStockProduitFini, List<clsPhamouvementStockdetail> clsPhamouvementStockProduitFinidetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {
            //DataSet DataSet = new DataSet();
            string vlpNumPiece1 = "";

            //-JE DEBIT  LES MATIERES PREMIERES
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStockMatiersPremiere);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockMatiersPremiere.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStockMatiersPremiere.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockMatiersPremieredetails.Count; Idx++)
            {
                clsPhamouvementStockMatiersPremieredetails[Idx].AG_CODEAGENCE = clsPhamouvementStockMatiersPremiere.AG_CODEAGENCE;



                clsPhamouvementStockMatiersPremieredetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockMatiersPremieredetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockMatiersPremieredetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockMatiersPremieredetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockMatiersPremieredetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

               

            }


            //-JE CREDIT  LES PRODUITS FINIS
            clsPhamouvementStockProduitFini.MS_NUMPIECE1 = vlpNumPiece;
             vlpNumPiece1 = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStockProduitFini);
            // mouchard
             clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockProduitFini.MS_NUMPIECE, "A"));

            string VlpNumPiece01 = "";

            VlpNumPiece01 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStockProduitFini.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockProduitFinidetails.Count; Idx++)
            {
                clsPhamouvementStockProduitFinidetails[Idx].AG_CODEAGENCE = clsPhamouvementStockProduitFini.AG_CODEAGENCE;



                clsPhamouvementStockProduitFinidetails[Idx].MD_NUMEROPIECE = VlpNumPiece01;
                clsPhamouvementStockProduitFinidetails[Idx].MS_NUMPIECE = vlpNumPiece1;
              
                clsPhamouvementStockProduitFinidetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockProduitFinidetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockProduitFinidetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));



            }





            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";
            clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            
            new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
            
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));

            return vlpNumPiece;
        }




        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockComptabilisation(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {

            //---GESTION DU CAS OU LE CLIENT DE VENTE A LA CAISSE N'EXISTE PAS DANS LA BASE DE DONNEES
                //--

            if (clsPhamouvementStock.TI_NUMTIERSNEW == "" && clsPhamouvementStock.TI_DENOMINATIONNEW != "" && clsPhamouvementStock.TI_IDTIERSNEW == "")
            {
                clsPhatiers clsPhatiers = new clsPhatiers();
                clsPhatiersWSDAL clsPhatiersWSDAL=new WSDAL.clsPhatiersWSDAL();
                clsPhatiers = clsPhatiersWSDAL.pvgTableLabelVENTECaisse(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, clsPhamouvementStock.TI_IDTIERS);
                clsPhatiers.TI_ADRESSEGEOGRAPHIQUE = clsPhamouvementStock.TI_ADRESSEGEOGRAPHIQUENEW;
                clsPhatiers.TI_DENOMINATION = clsPhamouvementStock.TI_DENOMINATIONNEW;
                clsPhatiers.TI_TELEPHONE = clsPhamouvementStock.TI_TELEPHONENEW;
                clsPhatiers.TI_DATESAISIE = clsPhamouvementStock.MS_DATEPIECE;
                clsPhatiers.TYPEOPERATION = "0";
                clsPhatiers.EN_CODEENTREPOT = clsPhamouvementstockreglement.EN_CODEENTREPOT;
                clsPhatiers.AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
               string vlpCodeTiers= clsPhatiersWSDAL.pvgMiseajour(clsDonnee, clsPhatiers);
               clsPhamouvementStock.TI_NUMTIERS = vlpCodeTiers;
                //clsPhamouvementStock.TI_NUMTIERS = clsPhatiersWSDAL.pvgTableLabelVENTECaisse(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpCodeTiers).TI_NUMTIERS;
               clsPhamouvementstockreglement.TI_NUMTIERS = clsPhamouvementStock.TI_NUMTIERS;

            }




            DataSet DataSet = new DataSet();
            //double vlpCreditTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            //double vlpDebitTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
            //clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            //clsPhamouvementStock.MS_LIBOPERA = "";
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

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

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

            //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

            ////les articles du mouvementstock
            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //{

            //    VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
            //    if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
            //    { VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString(); }
            //    else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
            //    VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;


                clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
                //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
                //clsPhamouvementstockreglement.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                if (clsPhamouvementStock.MS_REFPIECE != "") clsPhamouvementstockreglement.MV_REFERENCEPIECE = clsPhamouvementStock.MS_REFPIECE;
                new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
            //}

            return vlpNumPiece;
        }




        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockComptabilisationAvecRepartition(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
        {
            DataSet DataSet = new DataSet();
            //double vlpCreditTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            //double vlpDebitTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
            //clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            //clsPhamouvementStock.MS_LIBOPERA = "";
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

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

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

            //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

            ////les articles du mouvementstock
            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //{

            //    VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
            //    if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
            //    { VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString(); }
            //    else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
            //    VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;


            clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
            //clsPhamouvementstockreglement.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
            //insertion dans mouvementStockdetail
            String vlpMV_NUMPIECE = "";
            vlpMV_NUMPIECE=new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
            //



            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockreglementrepartitions.Count; Idx++)
            {
                clsPhamouvementstockreglementrepartitions[Idx].MV_NUMPIECE = vlpMV_NUMPIECE;



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




            //;
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
            //}

            return vlpNumPiece;
        }




        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockComptabilisationGarage(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPhaentrevehicule> clsPhaentrevehicules, clsObjetEnvoi clsObjetEnvoi)
        {
            DataSet DataSet = new DataSet();
            //double vlpCreditTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            //double vlpDebitTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
            //clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            //clsPhamouvementStock.MS_LIBOPERA = "";
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

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












            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

            //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

            ////les articles du mouvementstock
            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //{

            //    VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
            //    if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
            //    { VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString(); }
            //    else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
            //    VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;


            clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
            //clsPhamouvementstockreglement.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
            //insertion dans mouvementStockdetail
            new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
            //

            //;
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));



            //les véhicules du mouvementstock
            for (int Idx = 0; Idx < clsPhaentrevehicules.Count; Idx++)
            {
                //clsPhaentrevehicules[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                //clsPhaentrevehicules[Idx].MS_NUMPIECE = VlpNumPiece0;
                clsPhaentrevehicules[Idx].MS_NUMPIECE = vlpNumPiece;
                //clsPhaentrevehicules[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhaentrevehiculeWSDAL().pvgInsert(clsDonnee, clsPhaentrevehicules[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaentrevehicules[Idx].RV_IDENTREE.ToString(), "A"));

               

            }




            //}

            return vlpNumPiece;
        }


        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockComptabilisationHotel(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPha_attributionchambre> clsPha_attributionchambres, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
        {

            DataSet DataSet = new DataSet();
            
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

                

            }

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

           

            clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            String vlpMV_NUMPIECE = "";
            vlpMV_NUMPIECE = new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
            //

            //;
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
            //}


            

                //les articles du mouvementstock
                for (int Idx = 0; Idx < clsPha_attributionchambres.Count; Idx++)
                {
                    //clsPha_attributionchambres[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                    //clsPha_attributionchambres[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                    //clsPha_attributionchambres[Idx].MS_NUMPIECE = vlpNumPiece;
                    //clsPha_attributionchambres[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                    //insertion dans mouvementStockdetail
                    clsPha_attributionchambres[Idx].MS_NUMPIECE = vlpNumPiece;
                    clsPha_attributionchambres[Idx].TYPEOPERATION = 0;
                    new clsPha_attributionchambreWSDAL().pvgMiseAjours(clsDonnee, clsPha_attributionchambres[Idx]);

                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambres[Idx].TI_IDATTRIBUTION.ToString(), "A"));



                
            }

            //--

                //les articles du mouvementstock
                for (int Idx = 0; Idx < clsPhamouvementstockreglementrepartitions.Count; Idx++)
                {
                    clsPhamouvementstockreglementrepartitions[Idx].MV_NUMPIECE =   vlpMV_NUMPIECE ;



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
            //--



            return vlpNumPiece;
        }


        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockComptabilisationHotelDepartAnticipe(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, List<clsPha_attributionchambre> clsPha_attributionchambres, List<clsPha_attributionchambre> clsPha_attributionchambres1, clsPhamouvementStock clsPhamouvementStock1, clsPhamouvementStockdetail clsPhamouvementStockdetail1, List<clsPhamouvementstockreglementrepartition> clsPhamouvementstockreglementrepartitions, clsObjetEnvoi clsObjetEnvoi)
        {

            if(clsPha_attributionchambres1.Count>0)
            {
                clsPhamouvementStockWSDAL.pvgAnnulationApprovisionnementVente(clsDonnee, clsPha_attributionchambres1[0].AG_CODEAGENCE, clsPha_attributionchambres1[0].MS_NUMPIECE,clsPhamouvementStock.MS_DATEPIECE.ToShortDateString(), clsPha_attributionchambres1[0].AT_DATESAISIE.ToShortDateString(), "D", clsPhamouvementStock.OP_CODEOPERATEUR);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, "", "M"));
            }
            


            //if (clsPha_attributionchambres1[0].ECRANAPPELANT != "MDIStock")
            //{

            //    for (int Idx = 0; Idx < clsPha_attributionchambres1.Count; Idx++)
            //    {
            //        clsPha_attributionchambreWSDAL clsPha_attributionchambreWSDAL = new clsPha_attributionchambreWSDAL();
            //        clsPhamouvementStockdetail clsPhamouvementStockdetail = new clsPhamouvementStockdetail();
            //        clsPha_attributionchambreWSDAL.pvgUpdate(clsDonnee, clsPha_attributionchambres1[Idx], clsObjetEnvoi.OE_PARAM);
            //        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambres1[Idx].TI_IDATTRIBUTION.ToString(), "M"));


            //        string vlpNumPiece1 = new clsPhamouvementStockWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStock1);
            //        // mouchard
            //        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));
            //        //}

            //        string VlpNumPiece01 = "";

            //        VlpNumPiece01 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock1.AG_CODEAGENCE, vlpNumPiece1)) + 1).ToString();
            //        clsPhamouvementStockdetail1.AR_CODEARTICLE = clsPha_attributionchambres1[Idx].AR_CODEARTICLE;
            //        clsPhamouvementStockdetail1.MS_NUMPIECE = vlpNumPiece1;
            //        clsPhamouvementStockdetail1.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
            //        clsPhamouvementStockdetail1.MD_NUMEROPIECE = VlpNumPiece01;
            //        new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetail1);
            //        clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetail1.MD_NUMSEQUENCE.ToString(), "A"));


            //    }
            //}



            DataSet DataSet = new DataSet();

            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));



            }

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";



            clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            clsPhamouvementstockreglement.MS_NUMPIECEANNULER = clsPha_attributionchambres1[0].MS_NUMPIECE;
            String vlpMV_NUMPIECE = "";
            vlpMV_NUMPIECE = new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
            //

            //;
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
            //}


            //if (clsPha_attributionchambres[0].ECRANAPPELANT == "MDIStock")
            //{

                //les articles du mouvementstock
                for (int Idx = 0; Idx < clsPha_attributionchambres.Count; Idx++)
                {
                    //clsPha_attributionchambres[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                    //clsPha_attributionchambres[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                    //clsPha_attributionchambres[Idx].MS_NUMPIECE = vlpNumPiece;
                    //clsPha_attributionchambres[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                    //insertion dans mouvementStockdetail
                    clsPha_attributionchambres[Idx].MS_NUMPIECE = vlpNumPiece;
                    clsPha_attributionchambres[Idx].TYPEOPERATION = 0;
                   string TI_IDATTRIBUTION= new clsPha_attributionchambreWSDAL().pvgMiseAjours(clsDonnee, clsPha_attributionchambres[Idx]);



                    //clsJourneetravailWSDAL clsJourneetravailWSDAL = new clsJourneetravailWSDAL();
                    //--clôture de la facture quand la date de clôture est passées
                    clsPha_attributionchambre clsPha_attributionchambre = new clsPha_attributionchambre();
                    clsPha_attributionchambreWSDAL clsPha_attributionchambreWSDAL = new clsPha_attributionchambreWSDAL();
                    //if (clsPha_attributionchambres[Idx].AT_DATEFINEFFECTIVE <= DateTime.Parse(clsJourneetravailWSDAL.pvgValueScalarRequeteMaxDateActive(clsDonnee, clsPha_attributionchambres[Idx].AG_CODEAGENCE, "O")))
                    //{
                        //clsPha_attributionchambre = (clsPha_attributionchambre) = clsPha_attributionchambreWSDAL.pvgTableLabel(clsDonnee, vlpNumPiece);
                        clsPha_attributionchambres[Idx].TI_IDATTRIBUTION = TI_IDATTRIBUTION;
                        //clsPha_attributionchambres[Idx].AT_DATECLOTURE = clsPha_attributionchambres1[0].AT_DATEFINEFFECTIVE;
                        clsPha_attributionchambres[Idx].TYPEOPERATION = 3;
                        clsPha_attributionchambreWSDAL.pvgMiseAjours(clsDonnee, clsPha_attributionchambres[Idx]);
                    //}

                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPha_attributionchambres[Idx].TI_IDATTRIBUTION.ToString(), "A"));



                }




                //--

                //les articles du mouvementstock
                for (int Idx = 0; Idx < clsPhamouvementstockreglementrepartitions.Count; Idx++)
                {
                    clsPhamouvementstockreglementrepartitions[Idx].MV_NUMPIECE = vlpMV_NUMPIECE ;



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
                //--



            //}

            return vlpNumPiece;
        }







        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockMigration(clsDonnee clsDonnee, List<clsPhaclient>  clsPhaclients , clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        {
            DataSet DataSet = new DataSet();
            //double vlpCreditTemp = clsPhamouvementstockreglement.MV_MONTANTCREDIT;
            //double vlpDebitTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
            //clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            //mise à jour de la table mouvement stock et recuperation du numero de piece
            string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;



                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

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

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";

            //string VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            {

                VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
                if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
                { VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString(); }
                else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
                VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;


                clsPhamouvementstockreglements[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
                clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
            }

            return vlpNumPiece;
        }







        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockRetoursMarchandise(clsDonnee clsDonnee,  List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {

            ////clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            ////mise à jour de la table mouvement stock et recuperation du numero de piece
            //string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            //// mouchard
            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));


            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                //clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                //clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
            }

            //reglement effectué lors de l'opération
            //clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
            clsPhamouvementstockreglement.TYPEOPERATION = 0;
            if (clsPhamouvementstockreglement.MV_MONTANTCREDIT != 0 && clsPhamouvementstockreglement.MV_MONTANTDEBIT != 0)
            {
                double vlpTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = clsPhamouvementstockreglement.MV_MONTANTCREDIT + clsPhamouvementstockreglement.MV_MONTANTDEBIT;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "01";
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

                clsPhamouvementstockreglement.MV_MONTANTDEBIT = vlpTemp;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "02";
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

            }
            else
            {
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
            }

            return "";
        }




        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockRetoursMarchandise1(clsDonnee clsDonnee, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, List<clsPhamouvementstockreglement> clsPhamouvementstockreglements, clsObjetEnvoi clsObjetEnvoi)
        {

            ////clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            ////mise à jour de la table mouvement stock et recuperation du numero de piece
            //string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            //// mouchard
            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStockdetails[0].AG_CODEAGENCE, clsPhamouvementStockdetails[0].MS_NUMPIECE)) + 1).ToString();
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                //clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
            }

            string VlpNumPiece1 = "";
            string VlpNumPiece2 = "";
            string VlpNatureOperation = "";
            //if (clsPhamouvementstockreglements.Count>0)
            // VlpNumPiece1 =   (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();
            for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
             {
                 VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
                 if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
                 {VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString();}
                 else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
                 VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;
            //reglement effectué lors de l'opération
            //clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
                 clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
                 clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0;
            new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglements[Idx]);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglements[Idx].MV_NUMPIECE.ToString(), "A"));
             }

            

            return "";
        }


        /// <summary>
        /// cette procedure est utilisé 
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <param name="clsPhamouvementStockaccessoires"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere">avec des critères(Ordre critere:TP_CODETYPECLIENT ou TF_CODETYPEFOURNISSEUR)</param>
        /// <returns></returns>
        public string pvgAjouterMouvementStockRetoursMarchandiseAvecComptabilisation(clsDonnee clsDonnee, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {

            ////clsPhamouvementStock.TYPEOPERATION = 0; //indique qu'il s'agit d'une modification du mouvementstock
            ////mise à jour de la table mouvement stock et recuperation du numero de piece
            //string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            //// mouchard
            //clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStockdetails[0].AG_CODEAGENCE, clsPhamouvementStockdetails[0].MS_NUMPIECE)) + 1).ToString();
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                //clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
            }

            //string VlpNumPiece1 = "";
            //string VlpNumPiece2 = "";
            //string VlpNatureOperation = "";
            //if (clsPhamouvementstockreglements.Count>0)
            // VlpNumPiece1 =   (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString())) + 1).ToString();
            //for (int Idx = 0; Idx < clsPhamouvementstockreglements.Count; Idx++)
            //    {
                    //VlpNumPiece1 = (double.Parse(new clsPhamouvementstockreglementWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementstockreglements[0].AG_CODEAGENCE, clsPhamouvementstockreglements[0].MV_DATEPIECE.ToShortDateString()))).ToString();
                    //if (VlpNatureOperation != clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION)
                    //{VlpNumPiece2 = (double.Parse(VlpNumPiece1) + 1).ToString();}
                    //else { VlpNumPiece2 = (double.Parse(VlpNumPiece1)).ToString(); }
                    //VlpNatureOperation = clsPhamouvementstockreglements[Idx].NO_CODENATUREOPERATION;
            //reglement effectué lors de l'opération
            //clsPhamouvementstockreglement.MS_NUMPIECE = vlpNumPiece;
                    //clsPhamouvementstockreglements[Idx].MV_NUMEROPIECE = VlpNumPiece2;
                    //clsPhamouvementstockreglements[Idx].TYPEOPERATION = 0;
            new clsPhamouvementstockreglementWSDAL().pvgComptabilisation(clsDonnee, clsPhamouvementstockreglement);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockreglement.MV_NUMPIECE.ToString(), "A"));
                //}

            

            return "";
        }




        /// <summary>
        /// Cette fonction de faire un transfert d'articles entre deux agences
        /// </summary>
        /// <param name="clsPhamouvementStockEmetteur">Mouvement de l'emetteur</param>
        /// <param name="clsPhamouvementStockdetailEmetteurs">articles transferes</param>
        /// <param name="clsPhamouvementStockRecepteur">Mouvement du recepteur</param>
        /// <param name="clsPhamouvementStockdetailRecepteurs">articles recus</param>
        /// <param name="clsMouchard">trace</param>
        /// <returns></returns>
        public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStockEmetteur, List<clsPhamouvementStockdetail> clsPhamouvementStockdetailEmetteurs, clsPhamouvementStock clsPhamouvementStockRecepteur, List<clsPhamouvementStockdetail> clsPhamouvementStockdetailRecepteurs, clsObjetEnvoi clsObjetEnvoi)
        {
                //Emetteur  

            pvgAjouter(clsDonnee, clsPhamouvementStockEmetteur, clsPhamouvementStockdetailEmetteurs, clsObjetEnvoi);

                //Recepteur
            pvgAjouter(clsDonnee, clsPhamouvementStockRecepteur, clsPhamouvementStockdetailRecepteurs, clsObjetEnvoi);
            vlpNumPiece1 = "";
            
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStock">clsPhamouvementStock</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock,clsObjetEnvoi clsObjetEnvoi)
		{
            clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE.ToString(), "M"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:MS_NUMPIECE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<author>Home Technologie</author>
        public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "M"));

            //lors de la modification, la suppression des articles dans mouvementStockdetail se fait dans la procedure stockée 
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = clsPhamouvementStock.MS_NUMPIECE;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "M"));
            }


            return "";
        }


        ///<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:MS_NUMPIECE)</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<author>Home Technologie</author>
        public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails,clsPhamouvementstockreglement clsPhamouvementstockreglement, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementstockreglementWSDAL clsPhamouvementstockreglementWSDAL=new clsPhamouvementstockreglementWSDAL();
            clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "M"));

            //lors de la modification, la suppression des articles dans mouvementStockdetail se fait dans la procedure stockée 
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = clsPhamouvementStock.MS_NUMPIECE;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "M"));
            }

 
            //reglement effectué lors de l'opération
            clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementStock.MS_NUMPIECE;
            clsPhamouvementstockreglement.TYPEOPERATION =1;
            if (clsPhamouvementstockreglement.MV_MONTANTCREDIT != 0 && clsPhamouvementstockreglement.MV_MONTANTDEBIT != 0)
            {
                double vlpTemp = clsPhamouvementstockreglement.MV_MONTANTDEBIT;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = clsPhamouvementstockreglement.MV_MONTANTCREDIT + clsPhamouvementstockreglement.MV_MONTANTDEBIT;
                clsPhamouvementstockreglement.MV_MONTANTDEBIT = 0;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "01";
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

                string vlpTest = clsPhamouvementstockreglementWSDAL.pvgValueScalarRequeteMaxTestContreinte(clsDonnee, clsPhamouvementstockreglement.AG_CODEAGENCE, clsPhamouvementstockreglement.MS_NUMPIECE, "02");
                if (vlpTest != "0")
                {
                    clsPhamouvementstockreglement.TYPEOPERATION = 1;   
                }
                else { clsPhamouvementstockreglement.TYPEOPERATION = 0; }

                clsPhamouvementstockreglement.MV_MONTANTDEBIT = vlpTemp;
                clsPhamouvementstockreglement.MV_MONTANTCREDIT = 0;
                clsPhamouvementstockreglement.NO_CODENATUREOPERATION = "02";
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);

                

            }
            else
            {
                clsPhamouvementstockreglement.MS_NUMPIECE = clsPhamouvementStock.MS_NUMPIECE;
                clsPhamouvementstockreglement.TYPEOPERATION = 1;
                new clsPhamouvementstockreglementWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementstockreglement);
            }




            return "";
        }



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsEc_inscriptionscolaritereglements"> Liste d'objet clsEc_inscriptionscolaritereglement</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgLiaisonFactureConsultation(clsDonnee clsDonnee, List<clsPhamouvementStock> clsPhamouvementStocks, clsObjetEnvoi clsObjetEnvoi)
        {
            for (int Idx = 0; Idx < clsPhamouvementStocks.Count; Idx++)
            {
                if((clsPhamouvementStocks[Idx].COCHER=="O" && clsPhamouvementStocks[Idx].TYPEOPERATION==0)||(clsPhamouvementStocks[Idx].TYPEOPERATION==1))
                {
                    clsPhamouvementStockWSDAL.pvgLiaisonFactureConsultation(clsDonnee, clsPhamouvementStocks[Idx]);
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStocks[Idx].AG_CODEAGENCE.ToString(), "A"));
                }
              
            }


            return "";
        }



        /// <summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees(Ordre critere:MS_NUMPIECE)/// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere"></param>
        /// <returns></returns>
        public string pvgLivrer(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, clsObjetEnvoi clsObjetEnvoi)
        {
                clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "M"));
                return "";
        }

        /// <summary>
        /// Cette procedure permet d'enregistrer une facture (Ordre critere:MS_NUMPIECE)
        /// </summary>
        /// <param name="clsPhamouvementStock"></param>
        /// <param name="clsMouchard"></param>
        /// <param name="vppCritere"></param>
        /// <returns>Bool</returns>
        public string pvgFacturer(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, clsObjetEnvoi clsObjetEnvoi)
        {
                //clsPhamouvementStockWSDAL.pvgFacturer(clsDonnee, clsPhamouvementStock, clsObjetEnvoi.OE_PARAM);
                string vlpNumPiece = clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "M"));
                return "";
        }

        /// <summary> Cette procedure permet d'annuler une vente ou restaurer une vente annulee  </summary>
        /// <param name="vppNouvelleValeur">valeur du statut (O ou N) </param>
        /// <param name="vppCritere">critere:MS_NUMPIECE (numero de la vente)</param>
        /// <param name="clsMouchard"> trace </param>
        /// <returns> Bool </returns>
        public string pvgAnnulerVente(clsDonnee clsDonnee, clsPhamouvementStock clsPhamouvementStock, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementStock.TYPEOPERATION = 3; //indique qu'il s'agit d'une Annulation du mouvementstock
            clsPhamouvementStockWSDAL.pvgMiseajour(clsDonnee, clsPhamouvementStock);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, "", "M"));
            return "";
        }


        /// <summary> Cette procedure permet d'annuler une vente ou restaurer une vente annulee  </summary>
        /// <param name="vppNouvelleValeur">valeur du statut (O ou N) </param>
        /// <param name="vppCritere">critere:MS_NUMPIECE (numero de la vente)</param>
        /// <param name="clsMouchard"> trace </param>
        /// <returns> Bool </returns>
        public string pvgAnnulationApprovisionnementVente(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {

            //clsPha_attributionchambreWSBLL clsPha_attributionchambreWSBLL = new WSBLL.clsPha_attributionchambreWSBLL();
            //List<clsPha_attributionchambre> clsPha_attributionchambres = new List<clsPha_attributionchambre>();
            //clsPhamouvementStockWSBLL clsPhamouvementStockWSBLL = new clsPhamouvementStockWSBLL();
            //clsPhamouvementStockdetailWSDAL clsPhamouvementStockdetailWSDAL = new clsPhamouvementStockdetailWSDAL();
            //clsPhamouvementStock clsPhamouvementStock = new clsPhamouvementStock();
            //clsPhamouvementStockdetail clsPhamouvementStockdetail = new clsPhamouvementStockdetail();

            //clsPha_attributionchambres = clsPha_attributionchambreWSBLL.pvgTableLabelListe(clsDonnee, clsObjetEnvoi.OE_PARAM[0],clsObjetEnvoi.OE_PARAM[1]);
            
            //clsPhamouvementStock = clsPhamouvementStockWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM[0],clsObjetEnvoi.OE_PARAM[1]);
            //clsPhamouvementStockdetail = clsPhamouvementStockdetailWSDAL.pvgTableLabel(clsDonnee,  clsObjetEnvoi.OE_PARAM[0],clsObjetEnvoi.OE_PARAM[1]);

            clsPhamouvementStockWSDAL.pvgAnnulationApprovisionnementVente(clsDonnee, clsObjetEnvoi.OE_PARAM);
            //clsPha_attributionchambreWSBLL.pvgModifierListe(clsDonnee, clsPha_attributionchambres, clsPhamouvementStock, clsPhamouvementStockdetail, clsObjetEnvoi);
           


            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, "", "M"));
            return "";
        }

        /// <summary> Cette procedure permet d'annuler une vente ou restaurer une vente annulee  </summary>
        /// <param name="vppNouvelleValeur">valeur du statut (O ou N) </param>
        /// <param name="vppCritere">critere:MS_NUMPIECE (numero de la vente)</param>
        /// <param name="clsMouchard"> trace </param>
        /// <returns> Bool </returns>
        public string pvgClotureFactureApprovisionnementVente(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementStockWSDAL.pvgClotureFactureApprovisionnementVente(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, "", "M"));
            return "";
        }

        /// <summary> Cette procedure permet d'annuler une vente ou restaurer une vente annulee  </summary>
        /// <param name="vppNouvelleValeur">valeur du statut (O ou N) </param>
        /// <param name="vppCritere">critere:MS_NUMPIECE (numero de la vente)</param>
        /// <param name="clsMouchard"> trace </param>
        /// <returns> Bool </returns>
        public string pvgClotureExecice(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementStockWSDAL.pvgClotureExecice(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, "", "M"));
            return "";
        }



		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementStock </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStock> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}
        public List<clsPhamouvementStock> pvgChargerVentesEnCours(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgSelectVentesEnCours(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStock </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStock> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        /// <summary>Cette fonction permet selectionner les ventes d'une periode</summary>
        /// <param name="vppDateDebut"></param>
        /// <param name="vppDateFin"></param>
        /// <param name="vppCritere"></param>
        /// <returns>DataSet</returns>
        public DataSet pvgInsertIntoDatasetVentes(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgInsertIntoDatasetVentes(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetAppro(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgInsertIntoDatasetAppro(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetTransfertFabrication(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgInsertIntoDatasetTransfertFabrication(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public DataSet pvgInsertIntoDatasetTransfert(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgInsertIntoDatasetTransfert(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMvt1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgChargerDansDataSetMvt1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMVT(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgChargerDansDataSetMVT(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMouvementStock(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockWSDAL.pvgChargerDansDataSetMouvementStock(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MS_NUMPIECE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION, OP_CODEOPERATEUR ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetTiersPourReglement(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsPhamouvementStockWSDAL.pvgChargerDansDataSetTiersPourReglement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }




        public string  pvpChargerAccessoires(clsDonnee clsDonnee, clsPhamouvementStockdetail clsPhamouvementStockdetail, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsObjetEnvoi clsObjetEnvoi)
        {
            string vppCodeTypeClient = "";
            string vppCodeTypeFournisseur = "";
            if (clsObjetEnvoi.OE_PARAM.Length > 0)
            {
                vppCodeTypeFournisseur = clsObjetEnvoi.OE_PARAM[2];
                if (clsObjetEnvoi.OE_PARAM.Length > 1)
                    vppCodeTypeClient = clsObjetEnvoi.OE_PARAM[3];
            }

            List<clsPhapararticleaccessoire> clsPhapararticleaccessoires = new List<clsPhapararticleaccessoire>();
            clsPhapararticleaccessoires = new clsPhapararticleaccessoireWSDAL().pvgSelectEmballage(clsDonnee, clsPhamouvementStockdetail.AR_CODEARTICLE);
            for (int i = 0; i < clsPhapararticleaccessoires.Count; i++)
            {
                clsPhapararticle clsPhapararticle = new clsPhapararticle();
                clsPhamouvementStockdetail clsPhamouvementStockdetailAccessoire = new clsPhamouvementStockdetail();
                clsPhapararticle = new clsPhapararticleWSDAL().pvgTableLabel(clsDonnee, clsPhapararticleaccessoires[i].AR_CODEARTICLE2);

                clsPhamouvementStockdetailAccessoire.AR_CODEARTICLE = clsPhapararticleaccessoires[i].AR_CODEARTICLE2;
                clsPhamouvementStockdetailAccessoire.MD_QUANTITEENTREE = clsPhapararticleaccessoires[i].AR_QUANTITE * clsPhamouvementStockdetail.MD_QUANTITEENTREE;
                clsPhamouvementStockdetailAccessoire.MD_QUANTITESORTIE = clsPhapararticleaccessoires[i].AR_QUANTITE * clsPhamouvementStockdetail.MD_QUANTITESORTIE;
                int vppIndex = pvpAjouterAccessoire(clsPhamouvementStockdetailAccessoire, clsPhamouvementStockdetails);
                if (vppIndex == 0)
                {
                    clsPhamouvementStockdetailAccessoire.MD_ANNULATIONPIECE = "N";
                    clsPhamouvementStockdetailAccessoire.MD_ASDI = clsPhapararticle.AR_ASDI == "O" ? double.Parse(new clsParametreWSDAL().pvgTableLabel(clsDonnee, "AIRSI").PP_TAUX.ToString()) : 0;
                    clsPhamouvementStockdetailAccessoire.MD_TVA = clsPhapararticle.AR_TVA == "O" ? double.Parse(new clsParametreWSDAL().pvgTableLabel(clsDonnee, "TVA").PP_TAUX.ToString()) : 0;
                    clsPhamouvementStockdetailAccessoire.MD_STATUTACCESSOIRE = "C";
                    clsPhamouvementStockdetailAccessoire.MD_PRIXUNITAIREACHAT = new clsPhapararticleWSDAL().pvgSelectArticleAvecPrixFournisseur(clsDonnee, clsPhapararticle.AR_CODEARTICLE, vppCodeTypeFournisseur, clsObjetEnvoi.OE_J.ToShortDateString()).PRIXARTICLE;
                    if (vppCodeTypeClient != "")
                        clsPhamouvementStockdetailAccessoire.MD_PRIXUNITAIREVENTE = new clsPhapararticleWSDAL().pvgSelectArticleAvecPrixClient(clsDonnee, clsPhapararticle.AR_CODEARTICLE, vppCodeTypeClient, clsObjetEnvoi.OE_J.ToShortDateString()).PRIXARTICLE;
                    clsPhamouvementStockdetailAccessoire.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
                    clsPhamouvementStockdetails.Add(clsPhamouvementStockdetailAccessoire);
                }
                else
                {
                    clsPhamouvementStockdetails[vppIndex].MD_QUANTITESORTIE += clsPhamouvementStockdetailAccessoire.MD_QUANTITESORTIE;
                    clsPhamouvementStockdetails[vppIndex].MD_QUANTITEENTREE += clsPhamouvementStockdetailAccessoire.MD_QUANTITEENTREE;
                }

            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPhamouvementStockdetail"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <returns></returns>
        public  int pvpAjouterAccessoire( clsPhamouvementStockdetail clsPhamouvementStockdetail, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails)
        {
            int vppIndex = 0;
            for (int i = 0; i < clsPhamouvementStockdetails.Count; i++)
            {
                if (clsPhamouvementStockdetail.AR_CODEARTICLE == clsPhamouvementStockdetails[i].AR_CODEARTICLE)
                {
                    vppIndex = i;
                    break;
                }
            }
            return vppIndex;
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
					clsMouchard.MO_ACTION = "PhamouvementStock  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PhamouvementStock  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PhamouvementStock  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PhamouvementStock  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
