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
	public partial class wsOperateurdroit
	{
        public List<HT_Stock.BOJ.clsOperateurdroit> TestContrainte(HT_Stock.BOJ.clsOperateurdroit Objet)

        {
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroits.Add(clsOperateurdroit);
            return clsOperateurdroits;
        }



        public List<HT_Stock.BOJ.clsOperateurdroit> TestTestContrainteListe(HT_Stock.BOJ.clsOperateurdroit Objet)
        {
            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroits.Add(clsOperateurdroit);
            return clsOperateurdroits;
        }
    }
}
