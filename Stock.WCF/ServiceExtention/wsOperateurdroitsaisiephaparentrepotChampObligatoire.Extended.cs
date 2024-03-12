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
	public partial class wsOperateurdroitsaisiephaparentrepot
	{

        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> TestChampObligatoireListe(HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            //    return clsOperateurdroitsaisiephaparentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            //    return clsOperateurdroitsaisiephaparentrepots;

            //}


            else
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> TestChampObligatoireInsert(HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();

           

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }

            else
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            //    return clsOperateurdroitsaisiephaparentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            //    return clsOperateurdroitsaisiephaparentrepots;

            //}


            else
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            return clsOperateurdroitsaisiephaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> TestChampObligatoireDelete(HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot> clsOperateurdroitsaisiephaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot clsOperateurdroitsaisiephaparentrepot = new HT_Stock.BOJ.clsOperateurdroitsaisiephaparentrepot();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
                return clsOperateurdroitsaisiephaparentrepots;

            }
            else
            {
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitsaisiephaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitsaisiephaparentrepots.Add(clsOperateurdroitsaisiephaparentrepot);
            return clsOperateurdroitsaisiephaparentrepots;

            }


        }


    }
}