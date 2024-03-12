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
	public partial class wsCtcontratecheancier
	{
        public List<HT_Stock.BOJ.clsCtcontratecheancier> TestContrainte(HT_Stock.BOJ.clsCtcontratecheancier Objet)

        {
            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            return clsCtcontratecheanciers;
        }



        public List<HT_Stock.BOJ.clsCtcontratecheancier> TestTestContrainteListe(HT_Stock.BOJ.clsCtcontratecheancier Objet)
        {
            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            return clsCtcontratecheanciers;
        }
    }
}
