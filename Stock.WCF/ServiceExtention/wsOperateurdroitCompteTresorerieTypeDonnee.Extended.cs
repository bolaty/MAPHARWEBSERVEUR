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
	public partial class wsOperateurdroitCompteTresorerie
	{
        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> TestTypeDonnee(HT_Stock.BOJ.clsOperateurdroitCompteTresorerie Objet)

        {


            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            return clsOperateurdroitCompteTresoreries;


        }

    }
}