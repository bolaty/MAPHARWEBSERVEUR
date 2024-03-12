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
	public class clsPhainventaireWSBLL: IObjetWSBLL<clsPhainventaire>
	{
		private clsPhainventaireWSDAL clsPhainventaireWSDAL= new clsPhainventaireWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhainventaire comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhainventaire pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhainventaire">clsPhainventaire</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhainventaire clsPhainventaire , clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhainventaire.INV_CODEINVENTAIRE = double.Parse(string.Format( "{0:0000000000000000000000000}" , double.Parse(clsPhainventaireWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1));
			clsPhainventaireWSDAL.pvgInsert(clsDonnee, clsPhainventaire);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhainventaire.INV_CODEINVENTAIRE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhainventaires"> Liste d'objet clsPhainventaire</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhainventaire> clsPhainventaires , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhainventaireWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhainventaires.Count; Idx++)
			{
				clsPhainventaires[Idx].INV_CODEINVENTAIRE = double.Parse(string.Format( "{0:0000000000000000000000000}" , double.Parse(clsPhainventaireWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1));
				clsPhainventaireWSDAL.pvgInsert(clsDonnee, clsPhainventaires[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhainventaires[Idx].INV_CODEINVENTAIRE.ToString(), "A"));
			}
			return "";
		}


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhainventaire">clsPhainventaire</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterInventaire(clsDonnee clsDonnee, clsPhainventaire clsPhainventaire, List<clsPhainventairedetail> clsPhainventairedetails, clsPhamouvementStock clsPhamouvementStock, List<clsPhamouvementStockdetail> clsPhamouvementStockdetails, clsObjetEnvoi clsObjetEnvoi)//clsPhainventairedetail
        {
            //clsPhainventaire.INV_CODEINVENTAIRE = double.Parse(string.Format("{0:0000000000000000000000000}", double.Parse(clsPhainventaireWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsPhainventaire.AG_CODEAGENCE)) + 1));

            string vlpNumPiece1 = clsPhainventaireWSDAL.pvgInsert1(clsDonnee, clsPhainventaire);
            //clsPhainventaireWSDAL.pvgInsert(clsDonnee, clsPhainventaire);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhainventaire.INV_CODEINVENTAIRE.ToString(), "A"));


            ////les articles du mouvementstock
            //for (int Idx = 0; Idx < clsPhainventairedetails.Count; Idx++)
            //{

            //    clsPhainventairedetails[Idx].INV_CODEINVENTAIRE = vlpNumPiece1;//clsPhainventaire.INV_CODEINVENTAIRE.ToString();
            //    //clsPhainventairedetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
            //    //insertion dans mouvementStockdetail
            //    new clsPhainventairedetailWSDAL().pvgInsert(clsDonnee, clsPhainventairedetails[Idx]);
            //    //
            //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhainventairedetails[Idx].INV_CODEINVENTAIRE.ToString(), "A"));
            //}



            DataSet DataSet = new DataSet();

            string vlpNumPiece = new clsPhamouvementStockWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));


            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();



            //les articles du mouvementstock
            for (int Idx = 0; Idx < clsPhamouvementStockdetails.Count; Idx++)
            {
                string VlpNumPieceDetail = "";
                
                clsPhamouvementStockdetails[Idx].AG_CODEAGENCE = clsPhamouvementStock.AG_CODEAGENCE;
                clsPhamouvementStockdetails[Idx].MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                clsPhamouvementStockdetails[Idx].MD_NUMEROPIECE = VlpNumPiece0;
                //insertion dans mouvementStockdetail
                VlpNumPieceDetail=new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));

               

                clsPhainventairedetails[Idx].INV_CODEINVENTAIRE = vlpNumPiece1;//clsPhainventaire.INV_CODEINVENTAIRE.ToString();
                clsPhainventairedetails[Idx].MD_NUMSEQUENCE = VlpNumPieceDetail;//clsPhainventaire.INV_CODEINVENTAIRE.ToString();
                //clsPhainventairedetails[Idx].TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                //insertion dans mouvementStockdetail
                new clsPhainventairedetailWSDAL().pvgInsert(clsDonnee, clsPhainventairedetails[Idx]);
                //
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhainventairedetails[Idx].INV_CODEINVENTAIRE.ToString(), "A"));
                
                ////GESTION DES ACCESSOIRS OU DES EMBALLAGES
                //DataSet = new clsPhamouvementStockdetailWSDAL().pvgEMBALLAGE(clsDonnee, clsPhamouvementStockdetails[Idx].AR_CODEARTICLE, clsPhamouvementStock.MS_DATEPIECE.ToShortDateString());

                //for (int Idx1 = 0; Idx1 < DataSet.Tables[0].Rows.Count; Idx1++)
                //{

                //    if (clsPhamouvementStockdetails[Idx].MD_QUANTITEENTREE != 0)
                //    {
                //        clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                //        clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREACHAT = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                //    }

                //    if (clsPhamouvementStockdetails[Idx].MD_QUANTITESORTIE != 0)
                //    {
                //        clsPhamouvementStockdetails[Idx].AR_CODEARTICLE = DataSet.Tables["TABLE"].Rows[Idx1]["AR_CODEARTICLE2"].ToString();
                //        clsPhamouvementStockdetails[Idx].MD_PRIXUNITAIREVENTE = double.Parse(DataSet.Tables["TABLE"].Rows[Idx1]["AR_MONTANT"].ToString());
                //    }
                //    //insertion dans mouvementStockdetail
                //    new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetails[Idx]);
                //    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetails[Idx].MD_NUMSEQUENCE.ToString(), "A"));
                //}

                //;

            }
            
            
            return "";
        }



		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhainventaire">clsPhainventaire</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhainventaire clsPhainventaire,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhainventaireWSDAL.pvgUpdate(clsDonnee, clsPhainventaire, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhainventaire.INV_CODEINVENTAIRE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhainventaireWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhainventaire </returns>
		///<author>Home Technology</author>
		public List<clsPhainventaire> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhainventaire </returns>
		///<author>Home Technology</author>
		public List<clsPhainventaire> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : INV_CODEINVENTAIRE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhainventaireWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHAINVENTAIRE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAINVENTAIRE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAINVENTAIRE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAINVENTAIRE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
