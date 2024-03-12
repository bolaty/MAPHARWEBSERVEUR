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
	public partial class wsCliparmodeadmission
	{
        public List<HT_Stock.BOJ.clsCliparmodeadmission> TestTypeDonnee(HT_Stock.BOJ.clsCliparmodeadmission Objet)

        {


            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();
            clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            return clsCliparmodeadmissions;


        }

    }
}