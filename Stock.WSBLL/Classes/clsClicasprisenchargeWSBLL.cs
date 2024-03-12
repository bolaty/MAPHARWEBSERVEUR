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
	public class clsClicasprisenchargeWSBLL: IObjetWSBLL<clsClicasprisencharge>
	{
		private clsClicasprisenchargeWSDAL clsClicasprisenchargeWSDAL= new clsClicasprisenchargeWSDAL();
		private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Count (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgValueScalarRequeteCount(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Min (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgValueScalarRequeteMin(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max (sur un champs de la base) avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un string comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgValueScalarRequeteMax(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Un clsClicasprisencharge comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public clsClicasprisencharge pvgTableLibelle(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgTableLabel(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsClicasprisencharge">clsClicasprisencharge</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouter(clsDonnee clsDonnee, clsClicasprisencharge clsClicasprisencharge , clsObjetEnvoi clsObjetEnvoi)
		{
			clsClicasprisencharge.AG_CODEAGENCE = string.Format( "{0:0000000000000000000000000}" , double.Parse(clsClicasprisenchargeWSDAL.pvgValueScalarRequeteMax(clsDonnee)) + 1);
			clsClicasprisenchargeWSDAL.pvgInsert(clsDonnee, clsClicasprisencharge);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsClicasprisencharge.AG_CODEAGENCE.ToString(), "A"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsClicasprisencharges"> Liste d'objet clsClicasprisencharge</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgAjouterListe(clsDonnee clsDonnee, List<clsClicasprisencharge> clsClicasprisencharges , clsObjetEnvoi clsObjetEnvoi)
		{
            List<clsCliadherantsassurancecasprisencharge> clsCliadherantsassurancecasprisencharges = new List<clsCliadherantsassurancecasprisencharge>();
            clsCliadherantsassurancecasprisenchargeWSBLL clsCliadherantsassurancecasprisenchargeWSBLL = new clsCliadherantsassurancecasprisenchargeWSBLL();
            DataSet vlpDataSet = new DataSet();

           if(clsClicasprisencharges[0].COCHER == "O" && clsClicasprisencharges[0].APPLIQUERAUXADHERANTS == "O")
            {
                //-1-Récupération des adhérants
                string vlpTYPEOPERATION = "";
                clsCliadherantsassuranceWSBLL clsCliadherantsassuranceWSBLL = new clsCliadherantsassuranceWSBLL();
                clsObjetEnvoi.OE_PARAM = new string[] { clsClicasprisencharges[0].AG_CODEAGENCE, clsClicasprisencharges[0].EN_CODEENTREPOT, clsClicasprisencharges[0].AP_CODEPRODUIT, clsClicasprisencharges[0].AS_DATESAISIE1.ToShortDateString(), clsClicasprisencharges[0].AS_DATESAISIE2.ToShortDateString(), vlpTYPEOPERATION };
                vlpDataSet = clsCliadherantsassuranceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi);
            }
            

            for (int Idx = 0; Idx < clsClicasprisencharges.Count; Idx++)
			{
                if (clsClicasprisencharges[Idx].COCHER == "O")
                {
                    // Sppression des données existantes avant insertion dans la base de données 
                    clsClicasprisenchargeWSDAL.pvgDelete(clsDonnee,  clsClicasprisencharges[Idx].AG_CODEAGENCE, clsClicasprisencharges[Idx].AP_CODEPRODUIT, clsClicasprisencharges[Idx].AR_CODEARTICLE);
                    //
                    clsClicasprisenchargeWSDAL.pvgInsert(clsDonnee, clsClicasprisencharges[Idx]);
                    //
                    if (clsClicasprisencharges[Idx].APPLIQUERAUXADHERANTS == "O")
                    {
                        //-2-Constitution de la liste des cas de prise en charge des adhérants
                        foreach (DataRow row in vlpDataSet.Tables[0].Rows)
                        {
                            clsCliadherantsassurancecasprisencharge clsCliadherantsassurancecasprisencharge = new clsCliadherantsassurancecasprisencharge();
                            clsCliadherantsassurancecasprisencharge.AG_CODEAGENCE = clsClicasprisencharges[Idx].AG_CODEAGENCE;
                            clsCliadherantsassurancecasprisencharge.AP_CODEPRODUIT = clsClicasprisencharges[Idx].AP_CODEPRODUIT;
                            clsCliadherantsassurancecasprisencharge.AR_CODEARTICLE = clsClicasprisencharges[Idx].AR_CODEARTICLE;
                            clsCliadherantsassurancecasprisencharge.CP_MONTANT = clsClicasprisencharges[Idx].CP_MONTANT;
                            clsCliadherantsassurancecasprisencharge.CP_TAUXREMBOURSEMENT = clsClicasprisencharges[Idx].CP_TAUXREMBOURSEMENT;
                            clsCliadherantsassurancecasprisencharge.PE_CODEPERIODICITE = clsClicasprisencharges[Idx].PE_CODEPERIODICITE;
                            clsCliadherantsassurancecasprisencharge.CP_PLAFOND = clsClicasprisencharges[Idx].CP_PLAFOND;
                            clsCliadherantsassurancecasprisencharge.TI_IDTIERSADHERANT = row["TI_IDTIERSADHERANT"].ToString();
                            clsCliadherantsassurancecasprisencharge.CP_NOMBRE = clsClicasprisencharges[Idx].CP_NOMBRE;
                            clsCliadherantsassurancecasprisencharge.COCHER = clsClicasprisencharges[Idx].COCHER;
                            clsCliadherantsassurancecasprisencharges.Add(clsCliadherantsassurancecasprisencharge);
                        }
                        //-3-Application des cas aux adhérants
                        clsCliadherantsassurancecasprisenchargeWSBLL.pvgAjouterListe(clsDonnee, clsCliadherantsassurancecasprisencharges, clsObjetEnvoi);
                    }
                    
                    clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsClicasprisencharges[Idx].AG_CODEAGENCE.ToString(), "A"));
                }

			}
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de mise à jour dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="clsClicasprisencharge">clsClicasprisencharge</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>string</returns>
		///<author>Home Technology</author>
		public string pvgModifier(clsDonnee clsDonnee, clsClicasprisencharge clsClicasprisencharge,clsObjetEnvoi clsObjetEnvoi)
		{
			clsClicasprisenchargeWSDAL.pvgUpdate(clsDonnee, clsClicasprisencharge, clsObjetEnvoi.OE_PARAM);
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, clsClicasprisencharge.AG_CODEAGENCE.ToString(), "M"));
			return "";
		}

		///<summary>Cette fonction permet de d'executer une requete DML de suppression dans la base de donnees avec ou sans critères (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<author>Home Technology</author>
		public string pvgSupprimer(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			clsClicasprisenchargeWSDAL.pvgDelete(clsDonnee, clsObjetEnvoi.OE_PARAM);
			string vppValeurMouchard =  clsObjetEnvoi.OE_PARAM.Length>0?clsObjetEnvoi.OE_PARAM[0] : "Table entièrement vidée";
			clsMouchardWSDAL.pvgInsert(clsDonnee, pvpGenererMouchard(clsObjetEnvoi, vppValeurMouchard, "S"));
			return "";
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Une collection de clsClicasprisencharge </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisencharge> pvgCharger(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgSelect(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="vppCritere">critères de la requête scalaire</param>
		///<returns>Une collection de clsClicasprisencharge </returns>
		///<author>Home Technology</author>
		public List<clsClicasprisencharge> pvgChargerAPartirDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgSelectDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}

		///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi.OE_PARAM);
		}


        ///<summary>Cette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
        ///<param name=clsDonnee>Classe d'acces aux donnees</param>
        ///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
        ///<returns>Un DataSet comme valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public DataSet pvgChargerDansDataSetConfiguration(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
        {
	        return clsClicasprisenchargeWSDAL.pvgChargerDansDataSetConfiguration(clsDonnee, clsObjetEnvoi.OE_PARAM);
        }



		///<summaryCette fonction permet d'executer une requete select dans la base de donnees et de remplir un Dataset avec le resultat de la requete  (Ordre Critères : AG_CODEAGENCE, AR_CODEARTICLE ) </summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="clsObjetEnvoi">clsObjetEnvoi</param>
		///<returns>Un DataSet comme valeur du résultat de la requete</returns>
		///<author>Home Technology</author>
		public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee,clsObjetEnvoi clsObjetEnvoi)
		{
			return clsClicasprisenchargeWSDAL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi.OE_PARAM);
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
					clsMouchard.MO_ACTION = "CLICASPRISENCHARGE  (Ajout)  : "+ vppAction;
					break;
				case "M":clsMouchard.MO_ACTION = "CLICASPRISENCHARGE  (Modification)  : "+ vppAction;
					break;
				case "S":
					clsMouchard.MO_ACTION = "CLICASPRISENCHARGE  (Suppression)  : "+ vppAction;
					break;
				case "E":
					clsMouchard.MO_ACTION = "CLICASPRISENCHARGE  (Edition de l'etatEdition de l'etat)  : "+ vppAction;
					break;			}
			return clsMouchard;
		}
	}
}
