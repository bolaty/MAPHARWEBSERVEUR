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
	public partial class wsOperateurdroitagence
	{
        public List<HT_Stock.BOJ.clsOperateurdroitagence> TestTypeDonnee(HT_Stock.BOJ.clsOperateurdroitagence Objet)

        {


            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();
            clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
            return clsOperateurdroitagences;


        }

    }
}