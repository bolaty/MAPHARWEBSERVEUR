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
	public partial class wsLogicielobjet
	{
        public List<HT_Stock.BOJ.clsLogicielobjet> TestTypeDonnee(HT_Stock.BOJ.clsLogicielobjet Objet)

        {


            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjets.Add(clsLogicielobjet);
            return clsLogicielobjets;


        }

    }
}