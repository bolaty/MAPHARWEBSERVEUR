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
	public partial class wsMiccomptewebmotpasseoublie
	{
        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestContrainte(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)

        {
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;
        }



        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestTestContrainteListe(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {
            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;
        }
    }
}
