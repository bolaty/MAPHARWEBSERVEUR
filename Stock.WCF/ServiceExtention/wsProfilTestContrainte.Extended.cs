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
	public partial class wsProfil
	{
        public List<HT_Stock.BOJ.clsProfil> TestContrainte(HT_Stock.BOJ.clsProfil Objet)

        {
            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfil.clsObjetRetour.SL_MESSAGE = "";
            clsProfils.Add(clsProfil);
            return clsProfils;
        }



        public List<HT_Stock.BOJ.clsProfil> TestTestContrainteListe(HT_Stock.BOJ.clsProfil Objet)
        {
            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfil.clsObjetRetour.SL_MESSAGE = "";
            clsProfils.Add(clsProfil);
            return clsProfils;
        }
    }
}
