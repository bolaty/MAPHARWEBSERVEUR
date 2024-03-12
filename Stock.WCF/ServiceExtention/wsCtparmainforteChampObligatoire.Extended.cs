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
	public partial class wsCtparmainforte
	{

        public List<HT_Stock.BOJ.clsCtparmainforte> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparmainforte Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();

            //if (string.IsNullOrEmpty(Objet.MF_CODEMAINFORTE))
            //{
            //    clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_CODEMAINFORTE";
            //    clsCtparmainfortes.Add(clsCtparmainforte);
            //    return clsCtparmainfortes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparmainfortes.Add(clsCtparmainforte);
            //    return clsCtparmainfortes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparmainfortes.Add(clsCtparmainforte);
            //    return clsCtparmainfortes;

            //}


            //else
            //{
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "";
                clsCtparmainfortes.Add(clsCtparmainforte);
                return clsCtparmainfortes;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparmainforte> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparmainforte Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();

           

            if (string.IsNullOrEmpty(Objet.MF_LIBLLEMAINFORTE))
            {
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_LIBLLEMAINFORTE";
                clsCtparmainfortes.Add(clsCtparmainforte);
                return clsCtparmainfortes;

            }

            else
            {
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "";
                clsCtparmainfortes.Add(clsCtparmainforte);
                return clsCtparmainfortes;

            }


        }

        public List<HT_Stock.BOJ.clsCtparmainforte> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparmainforte Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();

            if (string.IsNullOrEmpty(Objet.MF_CODEMAINFORTE))
            {
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_CODEMAINFORTE";
                clsCtparmainfortes.Add(clsCtparmainforte);
                return clsCtparmainfortes;

            }

            if (string.IsNullOrEmpty(Objet.MF_LIBLLEMAINFORTE))
            {
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_LIBLLEMAINFORTE";
                clsCtparmainfortes.Add(clsCtparmainforte);
                return clsCtparmainfortes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparmainfortes.Add(clsCtparmainforte);
            //    return clsCtparmainfortes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparmainfortes.Add(clsCtparmainforte);
            //    return clsCtparmainfortes;

            //}


            else
            {
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "";
            clsCtparmainfortes.Add(clsCtparmainforte);
            return clsCtparmainfortes;

            }


        }

        public List<HT_Stock.BOJ.clsCtparmainforte> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparmainforte Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();

            if (string.IsNullOrEmpty(Objet.MF_CODEMAINFORTE))
            {
                clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparmainforte.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparmainforte.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_CODEMAINFORTE";
                clsCtparmainfortes.Add(clsCtparmainforte);
                return clsCtparmainfortes;

            }
            else
            {
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "";
            clsCtparmainfortes.Add(clsCtparmainforte);
            return clsCtparmainfortes;

            }


        }


    }
}