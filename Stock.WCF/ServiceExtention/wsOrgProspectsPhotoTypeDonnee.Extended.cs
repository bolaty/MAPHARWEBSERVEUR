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
	public partial class wsOrgProspectsPhoto
	{
        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> TestTypeDonnee(HT_Stock.BOJ.clsOrgProspectsPhoto Objet)

        {


            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();
            clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            return clsOrgProspectsPhotos;


        }

    }
}