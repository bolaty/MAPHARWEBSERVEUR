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
	public partial class wsTypejournal
	{

        public List<HT_Stock.BOJ.clsTypejournal> TestChampObligatoireListe(HT_Stock.BOJ.clsTypejournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();

            //if (string.IsNullOrEmpty(Objet.TJ_CODETYPEJOURNAL))
            //{
            //    clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypejournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsTypejournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TJ_CODETYPEJOURNAL";
            //    clsTypejournals.Add(clsTypejournal);
            //    return clsTypejournals;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypejournal.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypejournals.Add(clsTypejournal);
            //    return clsTypejournals;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypejournals.Add(clsTypejournal);
            //    return clsTypejournals;

            //}


            //else
            //{
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "";
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = "";
                clsTypejournals.Add(clsTypejournal);
                return clsTypejournals;

            //}


        }

        public List<HT_Stock.BOJ.clsTypejournal> TestChampObligatoireInsert(HT_Stock.BOJ.clsTypejournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();

           

            if (string.IsNullOrEmpty(Objet.TJ_LIBELLE))
            {
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypejournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TJ_LIBELLE";
                clsTypejournals.Add(clsTypejournal);
                return clsTypejournals;

            }

            else
            {
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "";
                clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsTypejournal.clsObjetRetour.SL_MESSAGE = "";
                clsTypejournals.Add(clsTypejournal);
                return clsTypejournals;

            }


        }

        public List<HT_Stock.BOJ.clsTypejournal> TestChampObligatoireUpdate(HT_Stock.BOJ.clsTypejournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();

            if (string.IsNullOrEmpty(Objet.TJ_CODETYPEJOURNAL))
            {
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypejournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TJ_CODETYPEJOURNAL";
                clsTypejournals.Add(clsTypejournal);
                return clsTypejournals;

            }

            if (string.IsNullOrEmpty(Objet.TJ_LIBELLE))
            {
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypejournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TJ_LIBELLE";
                clsTypejournals.Add(clsTypejournal);
                return clsTypejournals;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypejournal.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypejournals.Add(clsTypejournal);
            //    return clsTypejournals;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypejournal.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypejournal.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypejournals.Add(clsTypejournal);
            //    return clsTypejournals;

            //}


            else
            {
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = "";
            clsTypejournals.Add(clsTypejournal);
            return clsTypejournals;

            }


        }

        public List<HT_Stock.BOJ.clsTypejournal> TestChampObligatoireDelete(HT_Stock.BOJ.clsTypejournal Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();

            if (string.IsNullOrEmpty(Objet.TJ_CODETYPEJOURNAL))
            {
                clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypejournal.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypejournal.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TJ_CODETYPEJOURNAL";
                clsTypejournals.Add(clsTypejournal);
                return clsTypejournals;

            }
            else
            {
            clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = "";
            clsTypejournals.Add(clsTypejournal);
            return clsTypejournals;

            }


        }


    }
}