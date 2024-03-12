using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using Stock.Common;
namespace Stock.WCF
{
	public partial class wsOperateur
	{
        public List<HT_Stock.BOJ.clsOperateur> TestTypeDonnee(HT_Stock.BOJ.clsOperateur Objet)

        {


            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateur.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurs.Add(clsOperateur);
            return clsOperateurs;


        }

    }
}