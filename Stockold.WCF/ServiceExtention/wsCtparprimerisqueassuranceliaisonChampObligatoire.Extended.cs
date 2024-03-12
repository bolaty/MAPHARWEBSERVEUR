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
	public partial class wsCtparprimerisqueassuranceliaison
	{

        public List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
                return clsCtparprimerisqueassuranceliaisons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
            //    return clsCtparprimerisqueassuranceliaisons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
            //    return clsCtparprimerisqueassuranceliaisons;

            //}


            else
            {
                clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
                clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
                return clsCtparprimerisqueassuranceliaisons;

            }


        }


    }
}