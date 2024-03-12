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
	public partial class wsOperateurdroitphaparentrepot
	{
        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> TestTypeDonnee(HT_Stock.BOJ.clsOperateurdroitphaparentrepot Objet)

        {


            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();
            clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            return clsOperateurdroitphaparentrepots;


        }

    }
}