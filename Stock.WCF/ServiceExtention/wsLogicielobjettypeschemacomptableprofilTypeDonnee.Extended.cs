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
	public partial class wsLogicielobjettypeschemacomptableprofil
	{
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> TestTypeDonnee(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil Objet)

        {


            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;


        }

    }
}