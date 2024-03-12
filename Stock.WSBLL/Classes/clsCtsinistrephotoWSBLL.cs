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
	public class clsCtsinistrephotoWSBLL: IObjetWSBLL<clsCtsinistrephoto>
	{
		private clsCtsinistrephotoWSDAL clsCtsinistrephotoWSDAL= new clsCtsinistrephotoWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsCtsinistrephoto comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsCtsinistrephoto pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsCtsinistrephoto">clsCtsinistrephoto</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsCtsinistrephoto clsCtsinistrephoto , clsObjetEnvoi clsObjetEnvoi)
		{
			//clsCtsinistrephoto.SI_CODESINISTRE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsCtsinistrephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsCtsinistrephotoWSDAL.pvgInsert(clsDonnee, clsCtsinistrephoto);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrephoto.SI_CODESINISTRE.ToString(), "A"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtsinistrephotos"> Liste d'objet clsCtsinistrephoto</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsCtsinistrephoto> clsCtsinistrephotos, clsObjetEnvoi clsObjetEnvoi)
        {
            string vlpMessage = "";
            // Sppression des données existantes avant insertion dans la base de données 
            clsCtsinistrephotoWSDAL.pvgDelete1(clsDonnee, clsObjetEnvoi.OE_PARAM);
            for (int Idx = 0; Idx < clsCtsinistrephotos.Count; Idx++)
            {
                string vlpSI_NUMSEQUENCEPHOTORETOUR = "";
                //clsCtsinistrephotos[Idx].SI_CODESINISTRE = string.Format( "{0:00000000000000000000000000000000000000000000000000}" , double.Parse(clsCtsinistrephotoWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                //
                clsCtsinistrephotos[Idx].TYPEOPERATION = "0";
                vlpSI_NUMSEQUENCEPHOTORETOUR = clsCtsinistrephotoWSDAL.pvgMiseAJour(clsDonnee, clsCtsinistrephotos[Idx]);

                string vlpFichier = clsCtsinistrephotos[Idx].SI_CHEMINPHOTO;
                bool test = true;
                test = clsCtsinistrephotoWSDAL.pvgUploadPhotoSignature(clsDonnee, vlpFichier, vlpSI_NUMSEQUENCEPHOTORETOUR, "PHOT3");

                if (test == false)
                {
                    vlpMessage = "Le chemin des images de sinistre doit être correctement configuré sur le serveur !!!";
                    throw new Exception(vlpMessage);
                }

                clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrephotos[Idx].SI_CODESINISTRE.ToString(), "A"));
            }
            return vlpMessage;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsCtsinistrephoto">clsCtsinistrephoto</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifier(clsDonnee clsDonnee, clsCtsinistrephoto clsCtsinistrephoto,clsObjetEnvoi clsObjetEnvoi)
		{
			clsCtsinistrephotoWSDAL.pvgUpdate(clsDonnee, clsCtsinistrephoto, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsCtsinistrephoto.SI_CODESINISTRE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{

            DataSet DataSet = new DataSet();
            DataSet = clsCtsinistrephotoWSDAL.pvgChargerDansDataSet1(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsCtsinistrephotoWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
            clsCtsinistrephotoWSDAL.pvgDeletePhoto(clsDonnee, DataSet);
            string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsCtsinistrephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrephoto> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsCtsinistrephoto </returns>
		///<author>Home Technology</author>
		public List<clsCtsinistrephoto> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : SI_CODESINISTRE, SI_NUMSEQUENCEPHOTO ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsCtsinistrephotoWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CTSINISTREPHOTO  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CTSINISTREPHOTO  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CTSINISTREPHOTO  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CTSINISTREPHOTO  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
