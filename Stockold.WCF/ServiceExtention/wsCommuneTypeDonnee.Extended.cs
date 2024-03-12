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
	public partial class wsCommune
	{
        public List<HT_Stock.BOJ.clsCommune> TestTypeDonnee(HT_Stock.BOJ.clsCommune Objet)

        {


            List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCommune.clsObjetRetour.SL_MESSAGE = "";
            clsCommunes.Add(clsCommune);
            return clsCommunes;


        }

    }
}