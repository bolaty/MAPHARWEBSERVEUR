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
	public partial class wsLieuFacturation
	{
        public List<HT_Stock.BOJ.clsCliparlieufacturation> TestContrainte(HT_Stock.BOJ.clsCliparlieufacturation Objet)

        {
            List<HT_Stock.BOJ.clsCliparlieufacturation> clsCliparlieufacturations = new List<HT_Stock.BOJ.clsCliparlieufacturation>();
            HT_Stock.BOJ.clsCliparlieufacturation clsCliparlieufacturation = new HT_Stock.BOJ.clsCliparlieufacturation();
            clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "";
            clsCliparlieufacturations.Add(clsCliparlieufacturation);
            return clsCliparlieufacturations;
        }



        public List<HT_Stock.BOJ.clsCliparlieufacturation> TestTestContrainteListe(HT_Stock.BOJ.clsCliparlieufacturation Objet)
        {
            List<HT_Stock.BOJ.clsCliparlieufacturation> clsCliparlieufacturations = new List<HT_Stock.BOJ.clsCliparlieufacturation>();
            HT_Stock.BOJ.clsCliparlieufacturation clsCliparlieufacturation = new HT_Stock.BOJ.clsCliparlieufacturation();
            clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "";
            clsCliparlieufacturations.Add(clsCliparlieufacturation);
            return clsCliparlieufacturations;
        }
    }
}