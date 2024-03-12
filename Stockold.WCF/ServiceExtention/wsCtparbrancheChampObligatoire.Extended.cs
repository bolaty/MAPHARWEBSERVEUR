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
	public partial class wsCtparbranche
	{

        public List<HT_Stock.BOJ.clsCtparbranche> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparbranche Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();

            //if (string.IsNullOrEmpty(Objet.CB_IDBRANCHE))
            //{
            //    clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranche.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparbranche.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CB_IDBRANCHE";
            //    clsCtparbranches.Add(clsCtparbranche);
            //    return clsCtparbranches;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranches.Add(clsCtparbranche);
            //    return clsCtparbranches;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranches.Add(clsCtparbranche);
            //    return clsCtparbranches;

            //}


            //else
            //{
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = "";
                clsCtparbranches.Add(clsCtparbranche);
                return clsCtparbranches;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparbranche> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparbranche Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();

           

            if (string.IsNullOrEmpty(Objet.CB_LIBELLEBRANCHE))
            {
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CB_LIBELLEBRANCHE";
                clsCtparbranches.Add(clsCtparbranche);
                return clsCtparbranches;

            }

            else
            {
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = "";
                clsCtparbranches.Add(clsCtparbranche);
                return clsCtparbranches;

            }


        }

        public List<HT_Stock.BOJ.clsCtparbranche> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparbranche Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();

            if (string.IsNullOrEmpty(Objet.CB_IDBRANCHE))
            {
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CB_IDBRANCHE";
                clsCtparbranches.Add(clsCtparbranche);
                return clsCtparbranches;

            }

            if (string.IsNullOrEmpty(Objet.CB_LIBELLEBRANCHE))
            {
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CB_LIBELLEBRANCHE";
                clsCtparbranches.Add(clsCtparbranche);
                return clsCtparbranches;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranches.Add(clsCtparbranche);
            //    return clsCtparbranches;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranche.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranche.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranches.Add(clsCtparbranche);
            //    return clsCtparbranches;

            //}


            else
            {
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranches.Add(clsCtparbranche);
            return clsCtparbranches;

            }


        }

        public List<HT_Stock.BOJ.clsCtparbranche> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparbranche Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();

            if (string.IsNullOrEmpty(Objet.CB_IDBRANCHE))
            {
                clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranche.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranche.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CB_IDBRANCHE";
                clsCtparbranches.Add(clsCtparbranche);
                return clsCtparbranches;

            }
            else
            {
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranches.Add(clsCtparbranche);
            return clsCtparbranches;

            }


        }


    }
}