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
	public class clsPhaclientWSBLL: IObjetWSBLL<clsPhaclient>
	{
		private string vapCritere = "";
		private string vapRequete = "";
		private clsPhaclientWSDAL clsPhaclientWSDAL= new clsPhaclientWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsPhaclient comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsPhaclient pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete:(Ordre critere:CL_IDCLIENT)</summary>
        ///<param name="vppCritere">Critère de la requète SELECT</param>
        ///<returns>Un DataSet</returns>
        ///<author>Home Technologie</author>
        //public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        //{
        //    return clsPhaclientWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
        //}

        public DataSet pvgInsertIntoDatasetRecherche(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhaclientWSDAL.pvgChargerDansDataSetRecherche(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

        public DataSet pvgInsertIntoDatasetParSexe(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhaclientWSDAL.pvgChargerDansDataSetParSexe(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhaclient">clsPhaclient</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsPhaclient clsPhaclient , clsObjetEnvoi clsObjetEnvoi)
		{
            //clsPhaclient.CL_IDCLIENT = (double.Parse(clsPhaclientWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1).ToString();
            //if (clsPhaclient.CL_IDCLIENT == "1") clsPhaclient.CL_IDCLIENT = clsObjetEnvoi.OE_A + "00000001";
            //clsPhaclient.CL_NUMCLIENT = string.Format("{0:0000000}", double.Parse(clsPhaclientWSDAL.pvgValueScalarRequeteMax1(clsDonnee, clsObjetEnvoi.OE_A)) + 1);

            clsPhaclientWSDAL.pvgMiseajour(clsDonnee, clsPhaclient);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclient.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhaclient">clsPhaclient</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgMiseajourNumero(clsDonnee clsDonnee, clsPhaclient clsPhaclient, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhaclientWSDAL.pvgMiseajourNumero(clsDonnee, clsPhaclient);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclient.AG_CODEAGENCE.ToString(), "M"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhaclients"> Liste d'objet clsPhaclient</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsPhaclient> clsPhaclients , clsObjetEnvoi clsObjetEnvoi)
		{
			// Sppression des données existantes avant insertion dans la base de données 
            //clsPhaclientWSDAL.pvgDelete(clsDonnee , clsObjetEnvoi.OE_PARAM);
			for (int Idx = 0; Idx < clsPhaclients.Count; Idx++)
			{
                //clsPhaclients[Idx].AG_CODEAGENCE = string.Format( "{0:000}" , double.Parse(clsPhaclientWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
                clsPhaclientWSDAL.pvgMiseajour(clsDonnee, clsPhaclients[Idx]);
				clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclients[Idx].AG_CODEAGENCE.ToString(), "A"));
			}
			return "";
		}

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhaclients"> Liste d'objet clsPhaclient</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgAjouterClient(clsDonnee clsDonnee, clsPhaclient clsPhaclient, clsObjetEnvoi clsObjetEnvoi)
        {
            //clsPhaclient.TYPEOPERATION = "0";//definition de l'action a mener
            //
            clsPhaclientWSDAL.pvgMiseajour(clsDonnee, clsPhaclient);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclient.CL_IDCLIENT.ToString(), "A"));
            return clsPhaclient.CL_IDCLIENT;
        }

        ///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="clsPhaclients"> Liste d'objet clsPhaclient</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>string</returns>
        ///<author>Home Technology</author>
        public string pvgModifierClient(clsDonnee clsDonnee, clsPhaclient clsPhaclient, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhaclient.TYPEOPERATION = "1";//definition de l'action a mener
            clsPhaclientWSDAL.pvgMiseajour(clsDonnee, clsPhaclient);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclient.CL_IDCLIENT.ToString(), "M"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsPhaclient">clsPhaclient</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsPhaclient clsPhaclient,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhaclientWSDAL.pvgUpdate(clsDonnee, clsPhaclient, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclient.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}


        //<summary>Cette fonction permet de d'executer une requete DML de modification dans la base de donnees,avec ou sans critères(Ordre critere:EJ_IDEPARGNANTJOURNALIER)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param> 
        ///<param name="clsStockepargnantjournalier">clsStockepargnantjournalier</param>
        ///<param name="clsObjetEnvoi.OE_PARAM">Les critères de Modification</param>
        ///<returns>Un string comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public string pvgSupprimerClient(clsDonnee clsDonnee, clsPhaclient clsPhaclient, clsObjetEnvoi clsObjetEnvoi)
        {
            clsPhaclient.TYPEOPERATION = "2";//definition de l'action a mener
            clsPhaclientWSDAL.pvgMiseajour(clsDonnee, clsPhaclient);
            clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsPhaclient.CL_IDCLIENT.ToString(), "S"));
            return "";
        }

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsPhaclientWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsPhaclient </returns>
		///<author>Home Technology</author>
		public List<clsPhaclient> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsPhaclient </returns>
		///<author>Home Technology</author>
		public List<clsPhaclient> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerRechercheClientparNom(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            return clsPhaclientWSDAL.pvgChargerRechercheClientparNom(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }	

		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, CL_IDCLIENT, TP_CODETYPECLIENT ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsPhaclientWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "PHACLIENT  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "PHACLIENT  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "PHACLIENT  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "PHACLIENT  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
