using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.Common;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsCtpartypecontratauto
	{

        public List<HT_Stock.BOJ.clsCtpartypecontratauto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartypecontratauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypecontratauto> clsCtpartypecontratautos = new List<HT_Stock.BOJ.clsCtpartypecontratauto>();
            HT_Stock.BOJ.clsCtpartypecontratauto clsCtpartypecontratauto = new HT_Stock.BOJ.clsCtpartypecontratauto();

            if (string.IsNullOrEmpty(Objet.AU_CODETYPECONTRATAUTO))
            {
                clsCtpartypecontratauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypecontratauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypecontratauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypecontratauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PY_CODEPAYS";
                clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
                return clsCtpartypecontratautos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypecontratauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypecontratauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
            //    return clsCtpartypecontratautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypecontratauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypecontratauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
            //    return clsCtpartypecontratautos;

            //}


            else
            {
                clsCtpartypecontratauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypecontratauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypecontratauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
                return clsCtpartypecontratautos;

            }


        }


    }
}