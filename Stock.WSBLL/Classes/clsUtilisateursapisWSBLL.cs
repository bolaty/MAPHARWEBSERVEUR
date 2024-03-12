using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSDAL;

namespace Stock.WSBLL
{
	public class clsUtilisateursapisWSBLL: IObjetWSBLL<clsUtilisateursapis>
	{
        private clsUtilisateursapisWSDAL clsUtilisateursapisWSDAL = new clsUtilisateursapisWSDAL();
        private clsMouchardWSDAL clsMouchardWSDAL = new clsMouchardWSDAL();
        private clsUtilisateursapis clsUtilisateursapis = new clsUtilisateursapis();
        private List<clsUtilisateursapis> clsUtilisateursapisss = new List<clsUtilisateursapis>();


        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max,COUNT,MIN(sur un champs de la base)</summary>
        ///<summary>Cette fonction permet de d'executer une requête scalaire de type Max,COUNT,MIN(sur un champs de la base)</summary>
        ///<param name="clsDonnee">Classe d'acces aux donnees</param>
        ///<param name="List<clsUtilisateursapis>">Collection de clsUtilisateursapis</param>
        ///<param name="List<clsUtilisateursapis>">Collection de clsUtilisateursapis</param>
        ///<returns>Une collection de clsUtilisateursapis valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<clsUtilisateursapis> pvgValeurScalaireRequete(clsDonnee clsDonnee, List<clsUtilisateursapis> clsUtilisateursapiss)
		{
			for (int Idx = 0; Idx < clsUtilisateursapiss.Count; Idx++) 
			{
				clsUtilisateursapisss = clsUtilisateursapisWSDAL.pvgValueScalarRequete(clsDonnee, clsUtilisateursapiss[Idx]);
			}
			 return clsUtilisateursapisss;
		}

		///<summary>Cette fonction permet de d'executer une requete DML d'insertion ou de modification ou de suppression d'un ou plusieurs enregistrements  dans la base de donnees  </summary>
		///<param name="clsDonnee">Classe d'acces aux donnees</param>
		///<param name="List<clsUtilisateursapis>">Collection de clsUtilisateursapis</param>
		///<returns>Une collection de clsUtilisateursapis valeur du résultat de la requete</returns>
		///<author>Home Technology</author>

		public List<clsUtilisateursapis> pvgMiseAJour(clsDonnee clsDonnee, List<clsUtilisateursapis> clsUtilisateursapiss)
		{

			for (int Idx = 0; Idx < clsUtilisateursapiss.Count; Idx++)
			{
                if (clsUtilisateursapiss[Idx].TYPEOPERATION.Equals(((int)Stock.BOJ.TypeOperation.INSERT).ToString()))
				{
					clsUtilisateursapis.TYPEOPERATION = ((int)Stock.BOJ.TypeOperation.MAX).ToString();
					clsUtilisateursapisss = clsUtilisateursapisWSDAL.pvgValueScalarRequete(clsDonnee, clsUtilisateursapis);
					clsUtilisateursapiss[Idx].UT_IDUTILISATEUR = string.Format("{0:0000} ", double.Parse(clsUtilisateursapisss[0].SL_VALEURRETOURS) + 1);
					clsUtilisateursapisss[Idx].TYPEOPERATION = ((int)Stock.BOJ.TypeOperation.INSERT).ToString(); 
				}

                clsUtilisateursapisss = clsUtilisateursapisWSDAL.pvgMiseAjour(clsDonnee, clsUtilisateursapiss[Idx]);
               
                
			}
			return clsUtilisateursapisss; 
		}

		///<summary>Cette fonction permet de d'executer une requête scalaire de type Max,COUNT,MIN(sur un champs de la base)</summary>
		///<param name=clsDonnee>Classe d'acces aux donnees</param>
		///<param name="List<clsUtilisateursapis>">Collection de clsUtilisateursapis</param>
		///<returns>Une collection de clsUtilisateursapis valeur du résultat de la requete</returns>
		///<author>Home Technology</author>

		public List<clsUtilisateursapis> pvgSelectListe(clsDonnee clsDonnee, List<clsUtilisateursapis> clsUtilisateursapiss)
		{            
			for (int Idx = 0; Idx < clsUtilisateursapiss.Count; Idx++) 
			{
				clsUtilisateursapisss = clsUtilisateursapisWSDAL.pvgSelectListe(clsDonnee, clsUtilisateursapiss[Idx]);
			}
			return clsUtilisateursapisss;
		}

        ///<summary>Cette fonction permet de generer le mouchard</summary>
        ///<param name="clsUtilisateursapis">Objet</param>
        ///<returns>clsMouchard</returns>
        ///<author>Home Technologie</author>

        public clsMouchard pvpGenererMouchard(clsUtilisateursapis clsUtilisateursapis)
		{
            clsMouchard clsMouchard = new clsMouchard();
            
			clsMouchard.AG_CODEAGENCE = clsUtilisateursapis.clsObjetEnvoi.OE_A;
			clsMouchard.OP_CODEOPERATEUR = clsUtilisateursapis.clsObjetEnvoi.OE_Y;
			clsMouchard.MO_LIBELLEECRAN = clsUtilisateursapis.SL_LIBELLEECRAN;
			clsMouchard.MO_ACTION = clsUtilisateursapis.SL_LIBELLEMOUCHARD;
			  
            return clsMouchard;
        }

        public string pvgValeurScalaireRequeteCount(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public string pvgValeurScalaireRequeteMin(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public string pvgValeurScalaireRequeteMax(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public clsUtilisateursapis pvgTableLibelle(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public string pvgAjouter(clsDonnee clsDonnee, clsUtilisateursapis vppObjet1, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public string pvgAjouterListe(clsDonnee clsDonnee, List<clsUtilisateursapis> vppObjet1, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public string pvgModifier(clsDonnee clsDonnee, clsUtilisateursapis vppObjet1, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public string pvgSupprimer(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public List<clsUtilisateursapis> pvgCharger(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public List<clsUtilisateursapis> pvgChargerAPartirDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public DataSet pvgChargerDansDataSet(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public DataSet pvgChargerDansDataSet1(clsDonnee clsDonnee, List<clsUtilisateursapis> clsUtilisateursapiss)
        {
            DataSet vlpDataSet = new DataSet();
            for (int Idx = 0; Idx < clsUtilisateursapiss.Count; Idx++)
            {
                vlpDataSet= clsUtilisateursapisWSDAL.pvgChargerDansDataSet1(clsDonnee, clsUtilisateursapiss[Idx]); 
            }
            return vlpDataSet;
        }


        public DataSet pvgChargerDansDataSetPourCombo(clsDonnee clsDonnee, clsObjetEnvoi clsObjetEnvoi)
        {
            throw new NotImplementedException();
        }

        public clsMouchard pvpGenererMouchard(clsObjetEnvoi clsObjetEnvoi, string vppAction, string vppTypeAction)
        {
            throw new NotImplementedException();
        }
    }
}
