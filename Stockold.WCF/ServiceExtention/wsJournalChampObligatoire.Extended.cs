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
	public partial class wsJournal
	{

        public List<HT_Stock.BOJ.clsJournal> TestChampObligatoireListe(HT_Stock.BOJ.clsJournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();

            //if (string.IsNullOrEmpty(Objet.JO_CODEJOURNAL))
            //{
            //    clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsJournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JO_CODEJOURNAL";
            //    clsJournals.Add(clsJournal);
            //    return clsJournals;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsJournal.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsJournals.Add(clsJournal);
            //    return clsJournals;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsJournal.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsJournals.Add(clsJournal);
            //    return clsJournals;

            //}


            //else
            //{
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "";
                clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsJournal.clsObjetRetour.SL_MESSAGE = "";
                clsJournals.Add(clsJournal);
                return clsJournals;

            //}


        }

        public List<HT_Stock.BOJ.clsJournal> TestChampObligatoireInsert(HT_Stock.BOJ.clsJournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();

           

            if (string.IsNullOrEmpty(Objet.JO_LIBELLE))
            {
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JO_LIBELLE";
                clsJournals.Add(clsJournal);
                return clsJournals;

            }

            else
            {
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = "";
                clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsJournal.clsObjetRetour.SL_MESSAGE = "";
                clsJournals.Add(clsJournal);
                return clsJournals;

            }


        }

        public List<HT_Stock.BOJ.clsJournal> TestChampObligatoireUpdate(HT_Stock.BOJ.clsJournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();

            if (string.IsNullOrEmpty(Objet.JO_CODEJOURNAL))
            {
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JO_CODEJOURNAL";
                clsJournals.Add(clsJournal);
                return clsJournals;

            }

            if (string.IsNullOrEmpty(Objet.JO_LIBELLE))
            {
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JO_LIBELLE";
                clsJournals.Add(clsJournal);
                return clsJournals;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsJournal.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsJournals.Add(clsJournal);
            //    return clsJournals;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsJournal.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsJournals.Add(clsJournal);
            //    return clsJournals;

            //}


            else
            {
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJournal.clsObjetRetour.SL_MESSAGE = "";
            clsJournals.Add(clsJournal);
            return clsJournals;

            }


        }

        public List<HT_Stock.BOJ.clsJournal> TestChampObligatoireDelete(HT_Stock.BOJ.clsJournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();

            if (string.IsNullOrEmpty(Objet.JO_CODEJOURNAL))
            {
                clsJournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JO_CODEJOURNAL";
                clsJournals.Add(clsJournal);
                return clsJournals;

            }
            else
            {
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJournal.clsObjetRetour.SL_MESSAGE = "";
            clsJournals.Add(clsJournal);
            return clsJournals;

            }


        }


    }
}