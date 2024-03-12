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
	public partial class wsPhamouvementstockreglementnatureoperation
	{
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestContrainte(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)

        {
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            return clsPhamouvementstockreglementnatureoperations;
        }



        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestTestContrainteListe(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)
        {
            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            return clsPhamouvementstockreglementnatureoperations;
        }
    }
}
