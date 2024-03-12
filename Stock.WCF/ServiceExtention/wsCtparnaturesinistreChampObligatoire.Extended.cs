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
	public partial class wsCtparnaturesinistre
	{

        public List<HT_Stock.BOJ.clsCtparnaturesinistre> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparnaturesinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();

            //if (string.IsNullOrEmpty(Objet.NS_CODENATURESINISTRE))
            //{
            //    clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NS_CODENATURESINISTRE";
            //    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            //    return clsCtparnaturesinistres;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            //    return clsCtparnaturesinistres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            //    return clsCtparnaturesinistres;

            //}


            //else
            //{
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                return clsCtparnaturesinistres;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparnaturesinistre> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparnaturesinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();

           

            if (string.IsNullOrEmpty(Objet.NS_LIBELLENATURESINISTRE))
            {
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NS_LIBELLENATURESINISTRE";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                return clsCtparnaturesinistres;

            }

            else
            {
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                return clsCtparnaturesinistres;

            }


        }

        public List<HT_Stock.BOJ.clsCtparnaturesinistre> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparnaturesinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();

            if (string.IsNullOrEmpty(Objet.NS_CODENATURESINISTRE))
            {
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NS_CODENATURESINISTRE";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                return clsCtparnaturesinistres;

            }

            if (string.IsNullOrEmpty(Objet.NS_LIBELLENATURESINISTRE))
            {
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NS_LIBELLENATURESINISTRE";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                return clsCtparnaturesinistres;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            //    return clsCtparnaturesinistres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            //    return clsCtparnaturesinistres;

            //}


            else
            {
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "";
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            return clsCtparnaturesinistres;

            }


        }

        public List<HT_Stock.BOJ.clsCtparnaturesinistre> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparnaturesinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();

            if (string.IsNullOrEmpty(Objet.NS_CODENATURESINISTRE))
            {
                clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NS_CODENATURESINISTRE";
                clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
                return clsCtparnaturesinistres;

            }
            else
            {
            clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "";
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            return clsCtparnaturesinistres;

            }


        }


    }
}