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
	public partial class wsLogicielobjettypeoperationoperateur
	{
        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> TestTypeDonnee(HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur Objet)

        {


            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            return clsLogicielobjettypeoperationoperateurs;


        }

    }
}