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
	public partial class wsLieuFacturation
	{

        public List<HT_Stock.BOJ.clsCliparlieufacturation> TestChampObligatoireListe(HT_Stock.BOJ.clsCliparlieufacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparlieufacturation> clsCliparlieufacturations = new List<HT_Stock.BOJ.clsCliparlieufacturation>();
            HT_Stock.BOJ.clsCliparlieufacturation clsCliparlieufacturation = new HT_Stock.BOJ.clsCliparlieufacturation();

            //if (string.IsNullOrEmpty(Objet.LF_CODELIEUFACTURATION))
            //{
            //    clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LF_CODELIEUFACTURATION";
            //    clsCliparlieufacturations.Add(clsCliparlieufacturation);
            //    return clsCliparlieufacturations;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparlieufacturations.Add(clsCliparlieufacturation);
            //    return clsCliparlieufacturations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparlieufacturations.Add(clsCliparlieufacturation);
            //    return clsCliparlieufacturations;

            //}


            //else
            //{
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "";
                clsCliparlieufacturations.Add(clsCliparlieufacturation);
                return clsCliparlieufacturations;

            //}


        }

        public List<HT_Stock.BOJ.clsCliparlieufacturation> TestChampObligatoireInsert(HT_Stock.BOJ.clsCliparlieufacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparlieufacturation> clsCliparlieufacturations = new List<HT_Stock.BOJ.clsCliparlieufacturation>();
            HT_Stock.BOJ.clsCliparlieufacturation clsCliparlieufacturation = new HT_Stock.BOJ.clsCliparlieufacturation();

           

            if (string.IsNullOrEmpty(Objet.LF_LIBELLELIEUFACTURATION))
            {
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LF_LIBELLELIEUFACTURATION";
                clsCliparlieufacturations.Add(clsCliparlieufacturation);
                return clsCliparlieufacturations;

            }

            else
            {
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "";
                clsCliparlieufacturations.Add(clsCliparlieufacturation);
                return clsCliparlieufacturations;

            }


        }

        public List<HT_Stock.BOJ.clsCliparlieufacturation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCliparlieufacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparlieufacturation> clsCliparlieufacturations = new List<HT_Stock.BOJ.clsCliparlieufacturation>();
            HT_Stock.BOJ.clsCliparlieufacturation clsCliparlieufacturation = new HT_Stock.BOJ.clsCliparlieufacturation();

            if (string.IsNullOrEmpty(Objet.LF_CODELIEUFACTURATION))
            {
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LF_CODELIEUFACTURATION";
                clsCliparlieufacturations.Add(clsCliparlieufacturation);
                return clsCliparlieufacturations;

            }

            if (string.IsNullOrEmpty(Objet.LF_LIBELLELIEUFACTURATION))
            {
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LF_LIBELLELIEUFACTURATION";
                clsCliparlieufacturations.Add(clsCliparlieufacturation);
                return clsCliparlieufacturations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparlieufacturations.Add(clsCliparlieufacturation);
            //    return clsCliparlieufacturations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparlieufacturations.Add(clsCliparlieufacturation);
            //    return clsCliparlieufacturations;

            //}


            else
            {
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "";
            clsCliparlieufacturations.Add(clsCliparlieufacturation);
            return clsCliparlieufacturations;

            }


        }

        public List<HT_Stock.BOJ.clsCliparlieufacturation> TestChampObligatoireDelete(HT_Stock.BOJ.clsCliparlieufacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparlieufacturation> clsCliparlieufacturations = new List<HT_Stock.BOJ.clsCliparlieufacturation>();
            HT_Stock.BOJ.clsCliparlieufacturation clsCliparlieufacturation = new HT_Stock.BOJ.clsCliparlieufacturation();

            if (string.IsNullOrEmpty(Objet.LF_CODELIEUFACTURATION))
            {
                clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LF_CODELIEUFACTURATION";
                clsCliparlieufacturations.Add(clsCliparlieufacturation);
                return clsCliparlieufacturations;

            }
            else
            {
            clsCliparlieufacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparlieufacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparlieufacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparlieufacturation.clsObjetRetour.SL_MESSAGE = "";
            clsCliparlieufacturations.Add(clsCliparlieufacturation);
            return clsCliparlieufacturations;

            }


        }


    }
}