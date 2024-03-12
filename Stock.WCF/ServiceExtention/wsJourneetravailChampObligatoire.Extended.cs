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
	public partial class wsJourneetravail
	{

        public List<HT_Stock.BOJ.clsJourneetravail> TestChampObligatoireListe(HT_Stock.BOJ.clsJourneetravail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();

            if (string.IsNullOrEmpty(Objet.EX_EXERCICE))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EX_EXERCICE";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }
            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsJourneetravails.Add(clsJourneetravail);
            //    return clsJourneetravails;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsJourneetravail.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsJourneetravail.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsJourneetravails.Add(clsJourneetravail);
            //    return clsJourneetravails;

            //}


            else
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "";
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = "";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }


        }

        public List<HT_Stock.BOJ.clsJourneetravail> TestChampObligatoireInsert(HT_Stock.BOJ.clsJourneetravail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();

           

            if (string.IsNullOrEmpty(Objet.JT_DATEJOURNEETRAVAIL))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JT_DATEJOURNEETRAVAIL";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }
            if (string.IsNullOrEmpty(Objet.JT_STATUT))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JT_STATUT";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }
            //AG_CODEAGENCE,JT_DATEJOURNEETRAVAIL,JT_STATUT,OP_CODEOPERATEUR

            else
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "";
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = "";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }


        }

        public List<HT_Stock.BOJ.clsJourneetravail> TestChampObligatoireUpdate(HT_Stock.BOJ.clsJourneetravail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();

            if (string.IsNullOrEmpty(Objet.JT_DATEJOURNEETRAVAIL))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JT_DATEJOURNEETRAVAIL";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }
            if (string.IsNullOrEmpty(Objet.JT_STATUT))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JT_STATUT";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }


            else
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = "";
            clsJourneetravails.Add(clsJourneetravail);
            return clsJourneetravails;

            }


        }

        public List<HT_Stock.BOJ.clsJourneetravail> TestChampObligatoireDelete(HT_Stock.BOJ.clsJourneetravail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }

            if (string.IsNullOrEmpty(Objet.JT_DATEJOURNEETRAVAIL))
            {
                clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsJourneetravail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsJourneetravail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JT_DATEJOURNEETRAVAIL";
                clsJourneetravails.Add(clsJourneetravail);
                return clsJourneetravails;

            }

            else
            {
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = "";
            clsJourneetravails.Add(clsJourneetravail);
            return clsJourneetravails;

            }


        }


    }
}