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
	public partial class wsCtpargarentieprimerisque
	{

        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpargarentieprimerisque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            //    return clsCtpargarentieprimerisques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            //    return clsCtpargarentieprimerisques;

            //}


            //else
            //{
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            //}


        }

        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpargarentieprimerisque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();

           

            if (string.IsNullOrEmpty(Objet.GR_CODEGARENTIEPRIME))
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GR_CODEGARENTIEPRIME";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            }

            else
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            }


        }

        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpargarentieprimerisque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            }

            if (string.IsNullOrEmpty(Objet.GR_CODEGARENTIEPRIME))
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GR_CODEGARENTIEPRIME";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            //    return clsCtpargarentieprimerisques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            //    return clsCtpargarentieprimerisques;

            //}


            else
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            return clsCtpargarentieprimerisques;

            }


        }

        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpargarentieprimerisque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
                return clsCtpargarentieprimerisques;

            }
            else
            {
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            return clsCtpargarentieprimerisques;

            }


        }


    }
}