using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsCtparenergieauto
	{
        public List<HT_Stock.BOJ.clsCtparenergieauto> TestContrainte(HT_Stock.BOJ.clsCtparenergieauto Objet)

        {
            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparenergieautos.Add(clsCtparenergieauto);
            return clsCtparenergieautos;
        }



        public List<HT_Stock.BOJ.clsCtparenergieauto> TestTestContrainteListe(HT_Stock.BOJ.clsCtparenergieauto Objet)
        {
            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparenergieautos.Add(clsCtparenergieauto);
            return clsCtparenergieautos;
        }
    }
}
