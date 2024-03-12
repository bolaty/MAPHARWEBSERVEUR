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
	public class clsCtsinistrechequephotoWSBLL: IObjetWSBLL<clsCtsinistrechequephoto>
	{
		private clsCtsinistrechequephotoWSDAL clsCtsinistrechequephotoWSDAL= new clsCtsinistrechequephotoWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistrechequephoto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistrechequephoto pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtsinistrechequephoto">clsCtsinistrechequephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtsinistrechequephoto clsCtsinistrechequephoto , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtsinistrechequephoto.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsCtsinistrechequephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtsinistrechequephotoWSDAL.pvgInsert(clsDonnee, clsCtsinistrechequephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrechequephoto.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}
		public string pvgMiseAJour(clsDonnee clsDonnee, clsCtsinistrechequephoto clsCtsinistrechequephoto , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtsinistrechequephoto.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsCtsinistrechequephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtsinistrechequephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtsinistrechequephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrechequephoto.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}


		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtsinistrechequephotos"> Liste d'objet clsCtsinistrechequephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtsinistrechequephoto> clsCtsinistrechequephotos , clsObjetEnvoi clsObjetEnvoi)
		{
            // Sppression des données existantes avant insertion dans la base de données 
           
            clsCtsinistrechequephotoWSDAL.pvgDeleteListe(clsDonnee , clsCtsinistrechequephotos[0].AG_CODEAGENCE, clsCtsinistrechequephotos[0].CH_DATESAISIECHEQUE.ToShortDateString(), clsCtsinistrechequephotos[0].CH_IDEXCHEQUE);
			for (int Idx = 0; Idx < clsCtsinistrechequephotos.Count; Idx++)
			{
                string vlpIndex = "";
                string vlpFichier = clsCtsinistrechequephotos[Idx].CH_CHEMINPHOTOCHEQUE;
                clsCtsinistrechequephotos[Idx].CH_CHEMINPHOTOCHEQUE = clsCtsinistrechequephotos[Idx].AG_CODEAGENCE + "_" + clsCtsinistrechequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtsinistrechequephotos[Idx].CH_IDEXCHEQUE;
                if(clsCtsinistrechequephotos[Idx].TYPEOPERATION == 0)
                {
                    clsCtsinistrechequephotos[Idx].TYPEOPERATION = 0;
                    vlpIndex = clsCtsinistrechequephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtsinistrechequephotos[Idx]);
                    clsCtsinistrechequephotoWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, "CHEQ_" + clsCtsinistrechequephotos[Idx].AG_CODEAGENCE + "_" + clsCtsinistrechequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/","") + "_" + clsCtsinistrechequephotos[Idx].CH_IDEXCHEQUE + "_" + vlpIndex);
                }

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrechequephotos[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}
        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtsinistrechequephotos"> Liste d'objet clsCtsinistrechequephoto</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListeSansSuppression(clsDonnee clsDonnee, List<clsCtsinistrechequephoto> clsCtsinistrechequephotos , clsObjetEnvoi clsObjetEnvoi)
        {
            // Sppression des données existantes avant insertion dans la base de données 
           
            //clsCtsinistrechequephotoWSDAL.pvgDeleteListe(clsDonnee , clsCtsinistrechequephotos[0].AG_CODEAGENCE, clsCtsinistrechequephotos[0].CH_DATESAISIECHEQUE.ToShortDateString(), clsCtsinistrechequephotos[0].CH_IDEXCHEQUE);
	        for (int Idx = 0; Idx < clsCtsinistrechequephotos.Count; Idx++)
	        {
                string vlpIndex = "";
                string vlpFichier = clsCtsinistrechequephotos[Idx].CH_CHEMINPHOTOCHEQUE;
                clsCtsinistrechequephotos[Idx].CH_CHEMINPHOTOCHEQUE = clsCtsinistrechequephotos[Idx].AG_CODEAGENCE + "_" + clsCtsinistrechequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/", "") + "_" + clsCtsinistrechequephotos[Idx].CH_IDEXCHEQUE;
                if(clsCtsinistrechequephotos[Idx].TYPEOPERATION == 0)
                {
                    clsCtsinistrechequephotos[Idx].TYPEOPERATION = 0;
                    vlpIndex = clsCtsinistrechequephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtsinistrechequephotos[Idx]);
                    clsCtsinistrechequephotoWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, "CHEQ_" + clsCtsinistrechequephotos[Idx].AG_CODEAGENCE + "_" + clsCtsinistrechequephotos[Idx].CH_DATESAISIECHEQUE.ToShortDateString().Replace("/","") + "_" + clsCtsinistrechequephotos[Idx].CH_IDEXCHEQUE + "_" + vlpIndex);
                }

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrechequephotos[Idx].AG_CODEAGENCE.ToString(), "A"));
	        }
	        return "";
        }
		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtsinistrechequephoto">clsCtsinistrechequephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsCtsinistrechequephoto clsCtsinistrechequephoto,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtsinistrechequephotoWSDAL.pvgUpdate(clsDonnee, clsCtsinistrechequephoto, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrechequephoto.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            DataSet DataSet = new DataSet();
            DataSet = clsCtsinistrechequephotoWSDAL.pvgChargerDansDataSetDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsCtsinistrechequephotoWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			clsCtsinistrechequephotoWSDAL.pvgDeletePhoto(clsDonnee,  DataSet);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtsinistrechequephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrechequephoto> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistrechequephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrechequephoto> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
            return clsCtsinistrechequephotoWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetPhotoAfficher(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
            return clsCtsinistrechequephotoWSDAL.pvgChargerDansDataSetPhotoAfficher(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CH_DATESAISIECHEQUE, CH_IDEXCHEQUE, CH_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrechequephotoWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "Ctsinistrechequephoto  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "Ctsinistrechequephoto  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "Ctsinistrechequephoto  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "Ctsinistrechequephoto  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
