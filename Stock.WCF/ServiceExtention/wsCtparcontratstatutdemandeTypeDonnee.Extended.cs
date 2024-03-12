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
	public partial class wsCtparcontratstatutdemande
	{
        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> TestTypeDonnee(HT_Stock.BOJ.clsCtparcontratstatutdemande Objet)

        {


            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();
            clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            return clsCtparcontratstatutdemandes;


        }

    }
}