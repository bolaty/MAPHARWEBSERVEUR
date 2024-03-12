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
	public class clsPhapararticleWSBLL: IObjetWSBLL<clsPhapararticle>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsPhapararticleWSDAL clsPhapararticleWSDAL= new clsPhapararticleWSDAL();
        private clsPhapararticlephotoWSDAL clsPhapararticlephotoWSDAL = new clsPhapararticlephotoWSDAL();
        private clsPhapartypequantitedetailWSDAL clsPhapartypequantitedetailWSDAL = new clsPhapartypequantitedetailWSDAL();
        private clsPhapartyperemisedetailWSDAL clsPhapartyperemisedetailWSDAL = new clsPhapartyperemisedetailWSDAL();
        private clsPhapararticlecompteplancomptableWSDAL clsPhapararticlecompteplancomptableWSDAL = new clsPhapararticlecompteplancomptableWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

        private clsPhamouvementStockdetailWSDAL clsPhamouvementStockdetailWSDAL = new clsPhamouvementStockdetailWSDAL();
        private clsPhamouvementStockWSDAL clsPhamouvementStockWSDAL = new clsPhamouvementStockWSDAL();
		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        /// <summary>
        /// CETTE FONCTION PERMET DE VERIFIER L'UNICITE DU CODE BARRE
        /// </summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValueScalarRequeteCountCodeBarre(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgValueScalarRequeteCountCodeBarre(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        /// <summary>
        /// CETTE FONCTION PERMET DE VERIFIER L'UNICITE DU CODE CIP
        /// </summary>
        ///<param name="vppCritere">critères de la requète scalaire</param>
        ///<returns>Un BOOLEEN comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgValueScalarRequeteCountCodeCIP(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgValueScalarRequeteCountCodeCIP(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        //public string pvgStockActuel(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsPhapararticleWSDAL.pvgStockActuel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapararticle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapararticle pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhapararticle comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhapararticle pvgTableLabelSelonLeRisque(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgTableLabelSelonLeRisque(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<returns>Un clsPhapararticle comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public clsPhapararticle pvgTableLabel1(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgTableLabel1(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        public clsPhapararticle pvgTableLabelAvecCodeCIP(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapararticle">clsPhapararticle</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle , clsObjetEnvoi clsObjetEnvoi)
		{
            clsPhapararticlephoto clsPhapararticlephoto = new clsPhapararticlephoto();
            if (clsPhapararticle.TYPEOPERATION=="0")
			clsPhapararticle.AR_CODEARTICLE = string.Format( "{0:0000000}" , double.Parse(clsPhapararticleWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsPhapararticleWSDAL.pvgInsert(clsDonnee, clsPhapararticle);
            clsPhapararticlephoto.AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
            clsPhapararticlephoto.PH_PHOTO = clsPhapararticle.PH_PHOTO;
            clsPhapararticlephotoWSDAL.pvgDelete(clsDonnee, clsPhapararticlephoto.AR_CODEARTICLE);
            if (clsPhapararticlephoto.AR_CODEARTICLE != "" && clsPhapararticle.PH_PHOTO != null)
            clsPhapararticlephotoWSDAL.pvgInsert(clsDonnee, clsPhapararticlephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapararticle.AR_CODEARTICLE.ToString(), "A"));
			return "";
		}



        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhapararticle">clsPhapararticle</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter1(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle, List<clsPhapartypequantitedetail> clsPhapartypequantitedetails, List<clsPhapartyperemisedetail> clsPhapartyperemisedetails, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhapararticlephoto clsPhapararticlephoto = new clsPhapararticlephoto();
            if (clsPhapararticle.TYPEOPERATION == "0")
                clsPhapararticle.AR_CODEARTICLE = string.Format("{0:0000000}", double.Parse(clsPhapararticleWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
            clsPhapararticleWSDAL.pvgInsert(clsDonnee, clsPhapararticle);

            clsPhapararticlephoto.AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
            clsPhapararticlephoto.PH_PHOTO = clsPhapararticle.PH_PHOTO;
            clsPhapararticlephotoWSDAL.pvgDelete(clsDonnee, clsPhapararticlephoto.AR_CODEARTICLE);
            if (clsPhapararticlephoto.AR_CODEARTICLE != "" && clsPhapararticle.PH_PHOTO != null)
                clsPhapararticlephotoWSDAL.pvgInsert(clsDonnee, clsPhapararticlephoto);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapararticle.AR_CODEARTICLE.ToString(), "A"));



            for (int Idx = 0; Idx < clsPhapartypequantitedetails.Count; Idx++)
			{
                // Sppression des données existantes avant insertion dans la base de données 
                clsPhapartypequantitedetailWSDAL.pvgDelete(clsDonnee, clsPhapartypequantitedetails[Idx].TQ_CODETYPEQUANTITE, clsPhapararticle.AR_CODEARTICLE);
                clsPhapartypequantitedetails[Idx].AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
				clsPhapartypequantitedetailWSDAL.pvgInsert(clsDonnee, clsPhapartypequantitedetails[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartypequantitedetails[Idx].AR_CODEARTICLE.ToString(), "A"));
			}

            for (int Idx = 0; Idx < clsPhapartyperemisedetails.Count; Idx++)
            {
                // Sppression des données existantes avant insertion dans la base de données 
                clsPhapartyperemisedetailWSDAL.pvgDelete(clsDonnee, clsPhapartyperemisedetails[Idx].TR_CODETYPEQUANTITE, clsPhapararticle.AR_CODEARTICLE);
                clsPhapartyperemisedetails[Idx].AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
                clsPhapartyperemisedetailWSDAL.pvgInsert(clsDonnee, clsPhapartyperemisedetails[Idx]);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapartyperemisedetails[Idx].AR_CODEARTICLE.ToString(), "A"));
            }



            return clsPhapararticle.AR_CODEARTICLE;
        }


        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhapararticle">clsPhapararticle</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouter2(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle, clsPhamouvementStock clsPhamouvementStock, clsPhamouvementStockdetail clsPhamouvementStockdetail, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhapararticlephoto clsPhapararticlephoto = new clsPhapararticlephoto();
            if (clsPhapararticle.TYPEOPERATION == "0")
                clsPhapararticle.AR_CODEARTICLE = string.Format("{0:0000000}", double.Parse(clsPhapararticleWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
            clsPhapararticleWSDAL.pvgInsert(clsDonnee, clsPhapararticle);

            clsPhapararticlephoto.AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
            clsPhapararticlephoto.PH_PHOTO = clsPhapararticle.PH_PHOTO;
            clsPhapararticlephotoWSDAL.pvgDelete(clsDonnee, clsPhapararticlephoto.AR_CODEARTICLE);
            if (clsPhapararticlephoto.AR_CODEARTICLE != "" && clsPhapararticle.PH_PHOTO != null)
                clsPhapararticlephotoWSDAL.pvgInsert(clsDonnee, clsPhapararticlephoto);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapararticle.AR_CODEARTICLE.ToString(), "A"));
        //    private clsPhamouvementStockdetailWSDAL clsPhamouvementStockdetailWSDAL = new clsPhamouvementStockdetailWSDAL();
        //private clsPhamouvementStockWSDAL clsPhamouvementStockdetailWSDAL = new clsPhamouvementStockWSDAL();


            //for (int Idx = 0; Idx < clsPhapartypequantitedetails.Count; Idx++)
            //{
                // Sppression des données existantes avant insertion dans la base de données 
                //clsPhapartypequantitedetailWSDAL.pvgDelete(clsDonnee, clsPhapartypequantitedetails[Idx].TQ_CODETYPEQUANTITE, clsPhapararticle.AR_CODEARTICLE);
                //clsPhapartypequantitedetails[Idx].AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
            string vlpNumPiece = new clsPhamouvementStockWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStock);
            // mouchard
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStock.MS_NUMPIECE, "A"));
            //}

            string VlpNumPiece0 = "";

            VlpNumPiece0 = (double.Parse(new clsPhamouvementStockdetailWSDAL().pvgValueScalarRequeteMaxNumPiece(clsDonnee, clsPhamouvementStock.AG_CODEAGENCE, vlpNumPiece)) + 1).ToString();
                clsPhamouvementStockdetail.AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
                clsPhamouvementStockdetail.MS_NUMPIECE = vlpNumPiece;
                clsPhamouvementStockdetail.TYPEOPERATION = 0; //indique qu'il s'agit d'une insertion à jour du mouvementstockdetail
                clsPhamouvementStockdetail.MD_NUMEROPIECE = VlpNumPiece0;
                new clsPhamouvementStockdetailWSDAL().pvgMiseajour(clsDonnee, clsPhamouvementStockdetail);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhamouvementStockdetail.MD_NUMSEQUENCE.ToString(), "A"));
            //}



            return "";
        }






        public string pvgAjouter(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle, clsPhapararticlephoto clsPhapararticlephoto, clsObjetEnvoi clsObjetEnvoi)
        {
                clsPhapararticleWSDAL.pvgInsert(clsDonnee, clsPhapararticle);
                //if (clsPhapararticlephoto.PH_PHOTO != null)
                    //clsPhapararticlephotoWSDAL.pvgInsert(clsDonnee,clsPhapararticlephoto);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapararticle.AR_CODEARTICLE.ToString(), "A"));
                return "";
        }
		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapararticles"> Liste d'objet clsPhapararticle</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhapararticle> clsPhapararticles , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
			clsPhapararticleWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhapararticles.Count; Idx++)
			{
				clsPhapararticles[Idx].AR_CODEARTICLE = string.Format( "{0:0000000}" , double.Parse(clsPhapararticleWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
				clsPhapararticleWSDAL.pvgInsert(clsDonnee, clsPhapararticles[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapararticles[Idx].AR_CODEARTICLE.ToString(), "A"));
			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhapararticle">clsPhapararticle</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhapararticle clsPhapararticle,clsObjetEnvoi clsObjetEnvoi)
		{
            clsPhapararticlephoto clsPhapararticlephoto = new clsPhapararticlephoto();
			clsPhapararticleWSDAL.pvgUpdate(clsDonnee, clsPhapararticle, clsObjetEnvoi.OE_PARAM);
            clsPhapararticlephoto.AR_CODEARTICLE = clsPhapararticle.AR_CODEARTICLE;
            clsPhapararticlephoto.PH_PHOTO = clsPhapararticle.PH_PHOTO;
            clsPhapararticlephotoWSDAL.pvgDelete(clsDonnee, clsPhapararticlephoto.AR_CODEARTICLE);
            if (clsPhapararticlephoto.AR_CODEARTICLE != "" && clsPhapararticle.PH_PHOTO != null)
            clsPhapararticlephotoWSDAL.pvgInsert(clsDonnee, clsPhapararticlephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhapararticle.AR_CODEARTICLE.ToString(), "M"));
			return "";
		}


        public string pvgModifierCodeCIP(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhapararticleWSDAL.pvgUpdateCodeCIP(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsObjetEnvoi.OE_PARAM[0].ToString(), "M"));
            return "";
        }


        public string pvgModifierCodeBarre(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
                clsPhapararticleWSDAL.pvgUpdateCodeBare(clsDonnee, clsObjetEnvoi.OE_PARAM);
                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsObjetEnvoi.OE_PARAM[0].ToString(), "M"));
                return "";
        }

        public string pvgModifierTauxRemise(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhapararticleWSDAL.pvgUpdateTauxRemise(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsObjetEnvoi.OE_PARAM[0].ToString(), "M"));
            return "";
        }
		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            // Sppression des données existantes avant insertion dans la base de données 
            clsPhapartypequantitedetailWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM[0]);
            // Sppression des données existantes avant insertion dans la base de données 
            clsPhapartyperemisedetailWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM[0]);

            // Sppression des données existantes avant insertion dans la base de données 
            clsPhapararticlecompteplancomptableWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM[0]);

			clsPhapararticleWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="vppCritere">critères de la requête scalaire</param>
        ///<author>Home Technology</author>
        public string pvgSupprimer1(clsDonnee clsDonnee, List<clsPhapartypequantitedetail> clsPhapartypequantitedetails, List<clsPhapartyperemisedetail> clsPhapartyperemisedetails, clsObjetEnvoi clsObjetEnvoi)
        {


            for (int Idx = 0; Idx < clsPhapartypequantitedetails.Count; Idx++)
            {
                // Sppression des données existantes avant insertion dans la base de données 
                clsPhapartypequantitedetailWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM[0]);
            }

            for (int Idx = 0; Idx < clsPhapartyperemisedetails.Count; Idx++)
            {
                // Sppression des données existantes avant insertion dans la base de données 
                clsPhapartyperemisedetailWSDAL.pvgDelete1(clsDonnee,  clsObjetEnvoi.OE_PARAM[0]);
            }
            clsPhapararticleWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            string vppValeurMouchard = clsObjetEnvoi.OE_PARAM.Length > 0 ? clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
            return "";
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhapararticle </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticle> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		public DataSet pvgChargerArticle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            return clsPhapararticleWSDAL.pvgChargerArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        public DataSet pvgChargerArticlesRecherche(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgSelectArticleRecherche(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete </summary>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        public DataSet pvgInsertIntoDatasetArticleQuantite(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgInsertIntoDatasetArticleQuantite(clsDonnee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCodeTypeClient"></param>
        /// <param name="vppDate"></param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetFactureDDH(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgInsertIntoDatasetFactureDDH(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vppCodeTypeFournisseur">Type Fournisseur</param>
        /// <param name="vppDate">date</param>
        /// <returns></returns>
        public DataSet pvgInsertIntoDatasetFactureApproDDH(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgInsertIntoDatasetFactureApproDDH(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhapararticle </returns>
		///<author>Home Technology</author>
		public List<clsPhapararticle> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAvecStock(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsPhapararticleWSDAL.pvgChargerDansDataSetAvecStock(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPgarage(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetPgarage(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboPgarage(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetPourComboPgarage(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
       
        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetACCESSOIRS(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetACCESSOIRS(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetVenteAlaCaisse(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetVenteAlaCaisse(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetPrestation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgInsertIntoDatasetPrestation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetGestionPromotinnelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgInsertIntoDatasetGestionPromotinnelle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public DataSet pvgInsertIntoDatasetRetoursAccessoir(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgInsertIntoDatasetRetoursAccessoir(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        /// <summary>
        /// cette fonction permet d'avoir la quantite en Stock d'un article
        /// </summary>
        /// <param name="vppCritere">Code de l'article</param>
        /// <returns> retourne le Stock actuel </returns>
        public string pvgStockActuel(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgStockActuel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        /// <summary>
        /// cette fonction permet d'avoir le prix d'un article
        /// </summary>
        /// <param name="vppCritere">Code de l'article</param>
        /// <returns> retourne le  prix  actuel de l'article en fonction du type de client </returns>
        public string pvgPrixActuel(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgPrixActuel(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public clsPhapararticle pvgSelectArticleAvecPrixFournisseur(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgSelectArticleAvecPrixFournisseur(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public clsPhapararticle pvgSelectArticleAvecPrixClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgSelectArticleAvecPrixClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourComboSelonType(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhapararticleWSDAL.pvgChargerDansDataSetPourComboSelonType(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboProduitFini(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetPourComboProduitFini(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }
        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMatierePremiere(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetMatierePremiere(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPourComboArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetPourComboArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMatierePremiereFabrication(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetMatierePremiereFabrication(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetMatierePremiereChargement(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetMatierePremiereChargement(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetAevcPrix(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgChargerDansDataSetAevcPrix(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        public List<clsPhapararticle> pvgSelectArticleAccessoireAvecPrixClient(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhapararticleWSDAL.pvgSelectArticleAccessoireAvecPrixClient(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }


        /// <summary> Cette procedure permet d'annuler une vente ou restaurer une vente annulee  </summary>
        /// <param name="vppNouvelleValeur">valeur du statut (O ou N) </param>
        /// <param name="vppCritere">critere:MS_NUMPIECE (numero de la vente)</param>
        /// <param name="clsMouchard"> trace </param>
        /// <returns> Bool </returns>
        public string pvgClotureArticle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhapararticleWSDAL.pvgClotureArticle(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, "", "M"));
            return "";
        }

        /////<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AR_CODEARTICLE, RY_CODERAYON, FO_CODEFORME, TB_CODETABLEAU, TA_CODETYPEARTICLE, FA_CODEFABRICANT, MO_CODEMODEL, MA_CODEMARQUE, DA_CODEDESTINATION, UN_CODEUNITE, AR_RATTACHE ) </summary>
        /////<param name=clsDonnee>Classe d'acces aux donnees</param>
        /////<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        /////<returns>Un DataSet comme valeur du résultat de la requete</returns>
        /////<author>Home Technology</author>
        //public DataSet pvgChargerDansDataSetRechercheparNom(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsPhapararticleWSDAL.pvgChargerDansDataSetRechercheparNom(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

        /////<author>Home Technology</author>
        //public DataSet pvgChargerDansDataSetConsultation(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsPhapararticleWSDAL.pvgChargerDansDataSetConsultation(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

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
					clsMouchard.MO_ACTION = "PHAPARARTICLE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHAPARARTICLE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHAPARARTICLE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHAPARARTICLE  (Edition de l'etatEdition de l'etat)  : "+ vppAction; 
					break;			}
			return clsMouchard;
		}
	}
}
