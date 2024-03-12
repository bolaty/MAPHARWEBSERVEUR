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
	public partial class wsPhamouvementstockreglementnatureoperationtype
	{
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> TestContrainte(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype Objet)

        {
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            return clsPhamouvementstockreglementnatureoperationtypes;
        }



        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> TestTestContrainteListe(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype Objet)
        {
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            return clsPhamouvementstockreglementnatureoperationtypes;
        }
    }
}
