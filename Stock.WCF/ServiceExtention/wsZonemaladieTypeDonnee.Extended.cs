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
	public partial class wsZonemaladie
	{
        public List<HT_Stock.BOJ.clsZonemaladie> TestTypeDonnee(HT_Stock.BOJ.clsZonemaladie Objet)

        {


            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();
            clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = "";
            clsZonemaladies.Add(clsZonemaladie);
            return clsZonemaladies;


        }

    }
}