using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;
using System.IO;

namespace Stock.WSBLL
{
	public class clsCtcontratchequephotoWSBLL: IObjetWSBLL<clsCtcontratchequephoto>
	{
		private clsCtcontratchequephotoWSDAL clsCtcontratchequephotoWSDAL= new clsCtcontratchequephotoWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtcontratchequephoto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtcontratchequephoto pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratchequephoto">clsCtcontratchequephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtcontratchequephoto clsCtcontratchequephoto , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtcontratchequephoto.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsCtcontratchequephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtcontratchequephotoWSDAL.pvgInsert(clsDonnee, clsCtcontratchequephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephoto.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}
		public string pvgMiseAJour(clsDonnee clsDonnee, clsCtcontratchequephoto clsCtcontratchequephoto , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtcontratchequephoto.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsCtcontratchequephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtcontratchequephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtcontratchequephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephoto.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratchequephotos"> Liste d'objet clsCtcontratchequephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtcontratchequephoto> clsCtcontratchequephotos , clsObjetEnvoi clsObjetEnvoi)
		{
            // Sppression des données existantes avant insertion dans la base de données 
           
            clsCtcontratchequephotoWSDAL.pvgDeleteListe(clsDonnee , clsCtcontratchequephotos[0].AG_CODEAGENCE, clsCtcontratchequephotos[0].CH_DATESAISIECHEQUE.ToShortDateString(), clsCtcontratchequephotos[0].CH_IDEXCHEQUE);
			for (int Idx = 0; Idx < clsCtcontratchequephotos.Count; Idx++)
			{
                string vlpIndex = "";
                string vlpFichier = clsCtcontratchequephotos[Idx].CH_CHEMINPHOTOCHEQUE;
                clsCtcontratchequephotos[Idx].CH_CHEMINPHOTOCHEQUE = clsCtcontratchequephotos[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtcontratchequephotos[Idx].CH_IDEXCHEQUE;
                if(clsCtcontratchequephotos[Idx].TYPEOPERATION == 0)
                {
                    clsCtcontratchequephotos[Idx].TYPEOPERATION = 0;
                    vlpIndex = clsCtcontratchequephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtcontratchequephotos[Idx]);
                    clsCtcontratchequephotoWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, "CHEQ_" + clsCtcontratchequephotos[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/","") + "_" + clsCtcontratchequephotos[Idx].CH_IDEXCHEQUE + "_" + vlpIndex);
                }

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephotos[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtcontratchequephotos"> Liste d'objet clsCtcontratchequephoto</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeSansSuppression(clsDonnee clsDonnee, List<clsCtcontratchequephoto> clsCtcontratchequephotos , clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
           
            //clsCtcontratchequephotoWSDAL.pvgDeleteListe(clsDonnee , clsCtcontratchequephotos[0].AG_CODEAGENCE, clsCtcontratchequephotos[0].CH_DATESAISIECHEQUE.ToShortDateString(), clsCtcontratchequephotos[0].CH_IDEXCHEQUE);
	        for (int Idx = 0; Idx < clsCtcontratchequephotos.Count; Idx++)
	        {
                string vlpIndex = "";
                string vlpFichier = clsCtcontratchequephotos[Idx].CH_CHEMINPHOTOCHEQUE;
                clsCtcontratchequephotos[Idx].CH_CHEMINPHOTOCHEQUE = clsCtcontratchequephotos[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtcontratchequephotos[Idx].CH_IDEXCHEQUE;
                if(clsCtcontratchequephotos[Idx].TYPEOPERATION == 0)
                {
                    clsCtcontratchequephotos[Idx].TYPEOPERATION = 0;
                    vlpIndex = clsCtcontratchequephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtcontratchequephotos[Idx]);
                    clsCtcontratchequephotoWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, "CHEQ_" + clsCtcontratchequephotos[Idx].AG_CODEAGENCE + "_" + clsCtcontratchequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/","") + "_" + clsCtcontratchequephotos[Idx].CH_IDEXCHEQUE + "_" + vlpIndex);
                }

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephotos[Idx].AG_CODEAGENCE.ToString(), "A"));
	        }
	        return "";
        }
		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtcontratchequephoto">clsCtcontratchequephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCtcontratchequephoto clsCtcontratchequephoto,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtcontratchequephotoWSDAL.pvgUpdate(clsDonnee, clsCtcontratchequephoto, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtcontratchequephoto.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            DataSet DataSet = new DataSet();
            DataSet = clsCtcontratchequephotoWSDAL.pvgChargerDansDataSetDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsCtcontratchequephotoWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsCtcontratchequephotoWSDAL.pvgDeletePhoto(clsDonnee, DataSet);
            string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtcontratchequephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephoto> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtcontratchequephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtcontratchequephoto> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            return clsCtcontratchequephotoWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPhotoAfficher(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
            return clsCtcontratchequephotoWSDAL.pvgChargerDansDataSetPhotoAfficher(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetContratCheque(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
            return clsCtcontratchequephotoWSDAL.pvgChargerDansDataSetContratCheque(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtcontratchequephotoWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CTCONTRATCHEQUEPHOTO  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
