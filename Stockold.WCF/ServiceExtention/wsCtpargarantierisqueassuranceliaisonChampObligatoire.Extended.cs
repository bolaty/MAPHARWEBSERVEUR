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
	public partial class wsCtpargarantierisqueassuranceliaison
	{

        public List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> clsCtpargarantierisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison = new HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
                return clsCtpargarantierisqueassuranceliaisons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
            //    return clsCtpargarantierisqueassuranceliaisons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
            //    return clsCtpargarantierisqueassuranceliaisons;

            //}


            else
            {
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
                clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
                return clsCtpargarantierisqueassuranceliaisons;

            }


        }


    }
}