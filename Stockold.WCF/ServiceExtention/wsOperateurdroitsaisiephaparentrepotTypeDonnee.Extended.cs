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
	public partial class wsOperateurdroitsaisiephaparentrepot
	{
        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> TestTypeDonnee(HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot Objet)

        {


            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            return clsOperateurdroitsaisiephaparentrepots;


        }

    }
}