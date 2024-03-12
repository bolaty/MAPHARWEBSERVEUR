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
	public class clsPhamouvementStockcommandeWSBLL: IObjetWSBLL<clsPhamouvementStockcommande>
	{
		private clsPhamouvementStockcommandeWSDAL clsPhamouvementStockcommandeWSDAL= new clsPhamouvementStockcommandeWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhamouvementStockcommande comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhamouvementStockcommande pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockcommande">clsPhamouvementStockcommande</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande , clsObjetEnvoi clsObjetEnvoi)
		{
            clsPhamouvementStockcommande.MK_NUMPIECE =  (double.Parse(clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            clsPhamouvementStockcommande.MK_NUMSEQUENCE = double.Parse(clsPhamouvementStockcommandeWSDAL.pvgNumsequenceMaxValue(clsDonnee, clsPhamouvementStockcommande.AG_CODEAGENCE, clsPhamouvementStockcommande.MK_DATEPIECE.ToShortDateString())) + 1;
            clsPhamouvementStockcommandeWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockcommande);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

        public string pvgAnnulerCommande(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande, clsObjetEnvoi clsObjetEnvoi)
		{
            clsPhamouvementStockcommandeWSDAL.pvgAnnulerCommande(clsDonnee, clsPhamouvementStockcommande, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<author>Home Technologie</author>
        public string pvgAjouter(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, clsObjetEnvoi clsObjetEnvoi)
        {
            //generer le numero de piece de la commande
            clsPhamouvementStockcommande.MK_NUMPIECE = (double.Parse(clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //generer le numero de sequence de la commande
            clsPhamouvementStockcommande.MK_NUMSEQUENCE = double.Parse(clsPhamouvementStockcommandeWSDAL.pvgNumsequenceMaxValue(clsDonnee, clsPhamouvementStockcommande.AG_CODEAGENCE, clsPhamouvementStockcommande.MK_DATEPIECE.ToShortDateString())) + 1;
            //enregistrement de la commande
            clsPhamouvementStockcommandeWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockcommande);
            //mouchard pour la commande
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "M"));
            for (int Idx = 0; Idx < clsPhamouvementStockdetailcommandes.Count; Idx++)
            {
                clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;

                //clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE = clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee);
                clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = (double.Parse(new clsPhamouvementStockdetailcommandeWSDAL().pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                new clsPhamouvementStockdetailcommandeWSDAL().pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "A"));
            }
            return "";
        }





        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees</summary>
        ///<param name="vppCritere">BusinessObject</param>
        ///<author>Home Technologie</author>
        public string pvgAjouter1(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, List<clsPhamouvementstockcommandefacture> clsPhamouvementstockcommandefactures, clsObjetEnvoi clsObjetEnvoi)
        {
            DataSet DataSet = new DataSet();
            ////generer le numero de piece de la commande
            //clsPhamouvementStockcommande.MK_NUMPIECE = (double.Parse(clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //generer le numero de sequence de la commande
            clsPhamouvementStockcommande.MK_NUMSEQUENCE = double.Parse(clsPhamouvementStockcommandeWSDAL.pvgNumsequenceMaxValue(clsDonnee, clsPhamouvementStockcommande.AG_CODEAGENCE, clsPhamouvementStockcommande.MK_DATEPIECE.ToShortDateString())) + 1;
            //enregistrement de la commande
           clsPhamouvementStockcommande.MK_NUMPIECE= clsPhamouvementStockcommandeWSDAL.pvgInsert1(clsDonnee, clsPhamouvementStockcommande);
            //mouchard pour la commande
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "M"));
            for (int Idx = 0; Idx < clsPhamouvementStockdetailcommandes.Count; Idx++)
            {
                clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;

                //clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE = clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee);
                clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = "0";
                new clsPhamouvementStockdetailcommandeWSDAL().pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "A"));




            //    //GESTION DES ACCESSOIRS OU DES EMBALLAGES
            //    DataSet = new clsPhamouvementStockdetailWSDAL().pvgEMBALLAGE(clsDonnee, clsPhamouvementStockdetailcommandes[Idx].AR_CODEARTICLE, clsPhamouvementStockcommande.MK_DATEPIECE.ToShortDateString());




            //     for (int Idx1 = 0; Idx1 <DataSet.Tables[0].Rows.Count; Idx1++)
            //    {
                
            //    if( clsPhamouvementStockdetailcommandes[Idx].MM_QUANTITEENTREE!=0)
            //    {
            //    clsPhamouvementStockdetailcommandes[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
            //    clsPhamouvementStockdetailcommandes[Idx].MM_PRIXUNITAIREACHAT =double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
            //    }

            //    if (clsPhamouvementStockdetailcommandes[Idx].MM_QUANTITESORTIE != 0)
            //    {
            //        clsPhamouvementStockdetailcommandes[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
            //        clsPhamouvementStockdetailcommandes[Idx].MM_PRIXUNITAIREVENTE = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
            //    }
            //        //insertion dans mouvementStockdetail
            //    clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = (double.Parse(new clsPhamouvementStockdetailcommandeWSDAL().pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //    new clsPhamouvementStockdetailcommandeWSDAL().pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
            //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "A"));


            //}

            }

            string vlpNumeroPiece = (double.Parse(new clsPhamouvementstockcommandefactureWSDAL().pvgValueScalarRequeteMaxNumeroPiece(clsDonnee, clsPhamouvementstockcommandefactures[0].AG_CODEAGENCE, clsPhamouvementstockcommandefactures[0].MC_DATEPIECE.ToShortDateString())) + 1).ToString();
            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockcommandefactures.Count; Idx++)
            {
                //clsPhamouvementstockreglements[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementstockcommandefactures[Idx].MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;
                clsPhamouvementstockcommandefactures[Idx].MC_NUMEROPIECE = vlpNumeroPiece;
                clsPhamouvementstockcommandefactures[Idx].TYPEOPERATION ="0"; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockcommandefactureWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockcommandefactures[Idx]);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockcommandefactures[Idx].MK_NUMPIECE.ToString(), "A"));
            }












            return "";
        }











        public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhamouvementStockcommandeWSDAL.pvgUpdate(clsDonnee,clsPhamouvementStockcommande, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "M"));
            clsObjetEnvoi.OE_PARAM = new string[] {clsObjetEnvoi.OE_A, clsPhamouvementStockcommande.MK_NUMPIECE };
            //new clsPhamouvementStockdetailcommandeWSBLL().pvgAjouterListe(clsDonnee, clsPhamouvementStockdetailcommandes, clsObjetEnvoi);
            for (int Idx = 0; Idx < clsPhamouvementStockdetailcommandes.Count; Idx++)
            {
                if (Idx == 0)
                {
                    new clsPhamouvementStockdetailcommandeWSDAL().pvgDelete(clsDonnee, clsPhamouvementStockdetailcommandes[Idx].AG_CODEAGENCE, clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE);
                }
                clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;
                clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = (double.Parse(new clsPhamouvementStockdetailcommandeWSDAL().pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                new clsPhamouvementStockdetailcommandeWSDAL().pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "A"));




            }

            return "";
        }






        public string pvgModifier1(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, List<clsPhamouvementstockcommandefacture> clsPhamouvementstockcommandefactures, clsObjetEnvoi clsObjetEnvoi)
        {

            DataSet DataSet = new DataSet();

            clsPhamouvementStockcommandeWSDAL.pvgUpdate(clsDonnee, clsPhamouvementStockcommande, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "M"));
            clsObjetEnvoi.OE_PARAM = new string[] { clsObjetEnvoi.OE_A, clsPhamouvementStockcommande.MK_NUMPIECE };
            //new clsPhamouvementStockdetailcommandeWSBLL().pvgAjouterListe(clsDonnee, clsPhamouvementStockdetailcommandes, clsObjetEnvoi);
            for (int Idx = 0; Idx < clsPhamouvementStockdetailcommandes.Count; Idx++)
            {
                if (Idx == 0)
                {
                    new clsPhamouvementStockdetailcommandeWSDAL().pvgDelete(clsDonnee, clsPhamouvementStockdetailcommandes[Idx].AG_CODEAGENCE, clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE);
                }
                clsPhamouvementStockdetailcommandes[Idx].MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;
                clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = (double.Parse(new clsPhamouvementStockdetailcommandeWSDAL().pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                new clsPhamouvementStockdetailcommandeWSDAL().pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "A"));


                //GESTION DES ACCESSOIRS OU DES EMBALLAGES
                DataSet = new clsPhamouvementStockdetailWSDAL().pvgEMBALLAGE(clsDonnee, clsPhamouvementStockdetailcommandes[Idx].AR_CODEARTICLE, clsPhamouvementStockcommande.MK_DATEPIECE.ToShortDateString());

                for (int Idx1 = 0; Idx1 < DataSet.Tables[0].Rows.Count; Idx1++)
                {

                if (clsPhamouvementStockdetailcommandes[Idx].MM_QUANTITEENTREE != 0)
                {
                    clsPhamouvementStockdetailcommandes[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                    clsPhamouvementStockdetailcommandes[Idx].MM_PRIXUNITAIREACHAT = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                }

                if (clsPhamouvementStockdetailcommandes[Idx].MM_QUANTITESORTIE != 0)
                {
                    clsPhamouvementStockdetailcommandes[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                    clsPhamouvementStockdetailcommandes[Idx].MM_PRIXUNITAIREVENTE = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                }
                //insertion dans mouvementStockdetail
                clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE = (double.Parse(new clsPhamouvementStockdetailcommandeWSDAL().pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
                new clsPhamouvementStockdetailcommandeWSDAL().pvgInsert(clsDonnee, clsPhamouvementStockdetailcommandes[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetailcommandes[Idx].MM_NUMSEQUENCE.ToString(), "M"));


                }


            }

            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementstockcommandefactures.Count; Idx++)
            {
                //clsPhamouvementstockreglements[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementstockcommandefactures[Idx].MK_NUMPIECE = clsPhamouvementStockcommande.MK_NUMPIECE;
                clsPhamouvementstockcommandefactures[Idx].TYPEOPERATION = "1"; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhamouvementstockcommandefactureWSDAL().pvgInsert(clsDonnee, clsPhamouvementstockcommandefactures[Idx]);
                //

                //;
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementstockcommandefactures[Idx].MK_NUMPIECE.ToString(), "M"));
            }




            return "";
        }



		
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockcommandes"> Liste d'objet clsPhamouvementStockcommande</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhamouvementStockcommande> clsPhamouvementStockcommandes , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhamouvementStockcommandeWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhamouvementStockcommandes.Count; Idx++)
			{
				clsPhamouvementStockcommandes[Idx].AG_CODEAGENCE = string.Format( "{0:000}" , double.Parse(clsPhamouvementStockcommandeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhamouvementStockcommandeWSDAL.pvgInsert(clsDonnee, clsPhamouvementStockcommandes[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommandes[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhamouvementStockcommande">clsPhamouvementStockcommande</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhamouvementStockcommande clsPhamouvementStockcommande,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockcommandeWSDAL.pvgUpdate(clsDonnee, clsPhamouvementStockcommande, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockcommande.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhamouvementStockcommandeWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhamouvementStockcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockcommande> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public List<clsPhamouvementStockcommande> pvgChargerCommandeFournisseur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockcommandeWSDAL.pvgSelectCommandeFournisseur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public List<clsPhamouvementStockcommande> pvgChargerCommandeClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockcommandeWSDAL.pvgSelectCommandeClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhamouvementStockcommande </returns>
		///<author>Home Technology</author>
		public List<clsPhamouvementStockcommande> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public DataSet pvgChargerDataSetCommandeClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockcommandeWSDAL.pvgInsertIntoDatasetCommandeClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgChargerDataSetCommandeFournisseur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhamouvementStockcommandeWSDAL.pvgInsertIntoDatasetCommandeFournisseur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, MK_NUMPIECE, EN_CODEENTREPOT, CH_IDCHAUFFEUR, FR_CODEFOURNISSEUR, CL_IDCLIENT, CO_IDCOMMERCIAL, NO_CODENATUREOPERATION ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhamouvementStockcommandeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public List<clsPhapararticleaccessoire> pvpChargerAccessoires(clsDonnee clsDonnee, clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, clsObjetEnvoi clsObjetEnvoi)
        {
            string vppCodeTypeClient = "";
            string vppCodeTypeFournisseur = "";
            if (clsObjetEnvoi.OE_PARAM.Length > 0)
            {
                vppCodeTypeFournisseur = clsObjetEnvoi.OE_PARAM[0];
                if (clsObjetEnvoi.OE_PARAM.Length > 1)
                    vppCodeTypeClient = clsObjetEnvoi.OE_PARAM[1];
            }

            List<clsPhapararticleaccessoire> clsPhapararticleaccessoires = new List<clsPhapararticleaccessoire>();
            clsPhapararticleaccessoires = new clsPhapararticleaccessoireWSDAL().pvgSelectEmballage(clsDonnee,clsPhamouvementStockdetailcommande.AR_CODEARTICLE);
            for (int i = 0; i < clsPhapararticleaccessoires.Count; i++)
            {
                clsPhapararticle clsPhapararticle = new clsPhapararticle();
                clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommandeAccessoire = new clsPhamouvementStockdetailcommande();
                clsPhapararticle = new clsPhapararticleWSDAL().pvgTableLabel(clsDonnee, clsPhapararticleaccessoires[i].AR_CODEARTICLE2);

                clsPhamouvementStockdetailcommandeAccessoire.AR_CODEARTICLE = clsPhapararticleaccessoires[i].AR_CODEARTICLE2;
                clsPhamouvementStockdetailcommandeAccessoire.MM_QUANTITEENTREE = clsPhapararticleaccessoires[i].AR_QUANTITE * clsPhamouvementStockdetailcommande.MM_QUANTITEENTREE;
                clsPhamouvementStockdetailcommandeAccessoire.MM_QUANTITESORTIE = clsPhapararticleaccessoires[i].AR_QUANTITE * clsPhamouvementStockdetailcommande.MM_QUANTITESORTIE;
                int vppIndex = pvpAjouterAccessoire(clsPhamouvementStockdetailcommandeAccessoire, clsPhamouvementStockdetailcommandes);
                if (vppIndex == 0)
                {
                    clsPhamouvementStockdetailcommandeAccessoire.MM_ANNULATIONPIECE = "N";
                    clsPhamouvementStockdetailcommandeAccessoire.MM_ASDI = clsPhapararticle.AR_ASDI == "O" ? double.Parse(new clsParametreWSDAL().pvgTableLabel(clsDonnee, "AIRSI").PP_TAUX.ToString()) : 0;
                    clsPhamouvementStockdetailcommandeAccessoire.MM_TVA = clsPhapararticle.AR_TVA == "O" ? double.Parse(new clsParametreWSDAL().pvgTableLabel(clsDonnee, "TVA").PP_TAUX.ToString()) : 0;
                    clsPhamouvementStockdetailcommandeAccessoire.MM_STATUTACCESSOIRE = "C";
                    clsPhamouvementStockdetailcommandeAccessoire.MM_PRIXUNITAIREACHAT = new clsPhapararticleWSDAL().pvgSelectArticleAvecPrixFournisseur(clsDonnee, clsPhapararticleaccessoires[i].AR_CODEARTICLE2, vppCodeTypeFournisseur, clsObjetEnvoi.OE_J.ToShortDateString()).PRIXARTICLE;
                    if (vppCodeTypeClient != "")
                        clsPhamouvementStockdetailcommandeAccessoire.MM_PRIXUNITAIREVENTE = new clsPhapararticleWSDAL().pvgSelectArticleAvecPrixClient(clsDonnee, clsPhapararticleaccessoires[i].AR_CODEARTICLE2, vppCodeTypeClient, clsObjetEnvoi.OE_J.ToShortDateString()).PRIXARTICLE;
                    clsPhamouvementStockdetailcommandeAccessoire.AG_CODEAGENCE = clsObjetEnvoi.OE_A;
                    clsPhamouvementStockdetailcommandes.Add(clsPhamouvementStockdetailcommandeAccessoire);
                }
                else
                {
                    clsPhamouvementStockdetailcommandes[vppIndex].MM_QUANTITESORTIE += clsPhamouvementStockdetailcommandeAccessoire.MM_QUANTITESORTIE;
                    clsPhamouvementStockdetailcommandes[vppIndex].MM_QUANTITEENTREE += clsPhamouvementStockdetailcommandeAccessoire.MM_QUANTITEENTREE;
                }
            }
            return clsPhapararticleaccessoires;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clsPhamouvementStockdetail"></param>
        /// <param name="clsPhamouvementStockdetails"></param>
        /// <returns></returns>
        private int pvpAjouterAccessoire(clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes)
        {
            int vppIndex = 0;
            for (int i = 0; i < clsPhamouvementStockdetailcommandes.Count; i++)
            {
                if (clsPhamouvementStockdetailcommande.AR_CODEARTICLE == clsPhamouvementStockdetailcommandes[i].AR_CODEARTICLE)
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
					clsMouchard.MO_ACTION = "PhamouvementStockCOMMANDE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PhamouvementStockCOMMANDE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PhamouvementStockCOMMANDE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PhamouvementStockCOMMANDE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			
            }
			return clsMouchard;
		}
	}
}
