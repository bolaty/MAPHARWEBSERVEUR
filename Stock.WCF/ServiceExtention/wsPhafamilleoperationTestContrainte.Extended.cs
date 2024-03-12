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
	public partial class wsPhafamilleoperation
	{
        public List<HT_Stock.BOJ.clsPhafamilleoperation> TestContrainte(HT_Stock.BOJ.clsPhafamilleoperation Objet)

        {
            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            return clsPhafamilleoperations;
        }



        public List<HT_Stock.BOJ.clsPhafamilleoperation> TestTestContrainteListe(HT_Stock.BOJ.clsPhafamilleoperation Objet)
        {
            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            return clsPhafamilleoperations;
        }
    }
}
