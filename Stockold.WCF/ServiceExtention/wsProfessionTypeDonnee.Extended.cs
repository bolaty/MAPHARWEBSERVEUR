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
	public partial class wsProfession
	{
        public List<HT_Stock.BOJ.clsProfession> TestTypeDonnee(HT_Stock.BOJ.clsProfession Objet)

        {


            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfession.clsObjetRetour.SL_MESSAGE = "";
            clsProfessions.Add(clsProfession);
            return clsProfessions;


        }

    }
}