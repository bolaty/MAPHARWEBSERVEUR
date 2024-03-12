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
	public partial class wsCtparenergieauto
	{
        public List<HT_Stock.BOJ.clsCtparenergieauto> TestTypeDonnee(HT_Stock.BOJ.clsCtparenergieauto Objet)

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