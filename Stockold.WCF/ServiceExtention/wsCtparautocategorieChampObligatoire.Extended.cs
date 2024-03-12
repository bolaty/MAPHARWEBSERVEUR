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
	public partial class wsCtparautocategorie
	{

        public List<HT_Stock.BOJ.clsCtparautocategorie> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparautocategorie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();

            //if (string.IsNullOrEmpty(Objet.AU_CODECATEGORIE))
            //{
            //    clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_CODECATEGORIE";
            //    clsCtparautocategories.Add(clsCtparautocategorie);
            //    return clsCtparautocategories;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparautocategories.Add(clsCtparautocategorie);
            //    return clsCtparautocategories;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparautocategories.Add(clsCtparautocategorie);
            //    return clsCtparautocategories;

            //}


            //else
            //{
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "";
                clsCtparautocategories.Add(clsCtparautocategorie);
                return clsCtparautocategories;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparautocategorie> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparautocategorie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();

           

            if (string.IsNullOrEmpty(Objet.AU_LIBELLECATEGORIE))
            {
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_LIBELLECATEGORIE";
                clsCtparautocategories.Add(clsCtparautocategorie);
                return clsCtparautocategories;

            }

            else
            {
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "";
                clsCtparautocategories.Add(clsCtparautocategorie);
                return clsCtparautocategories;

            }


        }

        public List<HT_Stock.BOJ.clsCtparautocategorie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparautocategorie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();

            if (string.IsNullOrEmpty(Objet.AU_CODECATEGORIE))
            {
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_CODECATEGORIE";
                clsCtparautocategories.Add(clsCtparautocategorie);
                return clsCtparautocategories;

            }

            if (string.IsNullOrEmpty(Objet.AU_LIBELLECATEGORIE))
            {
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_LIBELLECATEGORIE";
                clsCtparautocategories.Add(clsCtparautocategorie);
                return clsCtparautocategories;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparautocategories.Add(clsCtparautocategorie);
            //    return clsCtparautocategories;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparautocategories.Add(clsCtparautocategorie);
            //    return clsCtparautocategories;

            //}


            else
            {
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "";
            clsCtparautocategories.Add(clsCtparautocategorie);
            return clsCtparautocategories;

            }


        }

        public List<HT_Stock.BOJ.clsCtparautocategorie> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparautocategorie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();

            if (string.IsNullOrEmpty(Objet.AU_CODECATEGORIE))
            {
                clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_CODECATEGORIE";
                clsCtparautocategories.Add(clsCtparautocategorie);
                return clsCtparautocategories;

            }
            else
            {
            clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "";
            clsCtparautocategories.Add(clsCtparautocategorie);
            return clsCtparautocategories;

            }


        }


    }
}