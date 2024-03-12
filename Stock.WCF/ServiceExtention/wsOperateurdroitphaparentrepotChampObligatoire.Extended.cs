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
	public partial class wsOperateurdroitphaparentrepot
	{

        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> TestChampObligatoireListe(HT_Stock.BOJ.clsOperateurdroitphaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            //    return clsOperateurdroitphaparentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            //    return clsOperateurdroitphaparentrepots;

            //}


            else
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> TestChampObligatoireInsert(HT_Stock.BOJ.clsOperateurdroitphaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();

           

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }

            else
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOperateurdroitphaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            //    return clsOperateurdroitphaparentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            //    return clsOperateurdroitphaparentrepots;

            //}


            else
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            return clsOperateurdroitphaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> TestChampObligatoireDelete(HT_Stock.BOJ.clsOperateurdroitphaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot> clsOperateurdroitphaparentrepots = new List<HT_Stock.BOJ.clsOperateurdroitphaparentrepot>();
            HT_Stock.BOJ.clsOperateurdroitphaparentrepot clsOperateurdroitphaparentrepot = new HT_Stock.BOJ.clsOperateurdroitphaparentrepot();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
                return clsOperateurdroitphaparentrepots;

            }
            else
            {
            clsOperateurdroitphaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitphaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitphaparentrepots.Add(clsOperateurdroitphaparentrepot);
            return clsOperateurdroitphaparentrepots;

            }


        }


    }
}