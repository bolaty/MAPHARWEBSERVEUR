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
	public partial class wsCompteAmortissement
	{
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestTypeDonnee(HT_Stock.BOJ.clsBienimmobilisefamille Objet)

        {


            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            return clsBienimmobilisefamilles;


        }

    }
}