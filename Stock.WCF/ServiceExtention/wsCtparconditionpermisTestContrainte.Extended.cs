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
	public partial class wsCtparconditionpermis
	{
        public List<HT_Stock.BOJ.clsCtparconditionpermis> TestContrainte(HT_Stock.BOJ.clsCtparconditionpermis Objet)

        {
            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "";
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            return clsCtparconditionpermiss;
        }



        public List<HT_Stock.BOJ.clsCtparconditionpermis> TestTestContrainteListe(HT_Stock.BOJ.clsCtparconditionpermis Objet)
        {
            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "";
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            return clsCtparconditionpermiss;
        }
    }
}
