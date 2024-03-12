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
	public partial class wsPhaparentrepot
	{

        public List<HT_Stock.BOJ.clsPhaparentrepot> TestChampObligatoireListe(HT_Stock.BOJ.clsPhaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparentrepots.Add(clsPhaparentrepot);
            //    return clsPhaparentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparentrepots.Add(clsPhaparentrepot);
            //    return clsPhaparentrepots;

            //}


            else
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparentrepot> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();

           

            if (string.IsNullOrEmpty(Objet.EN_DENOMINATION))
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_DENOMINATION";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }

            else
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparentrepot> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }

            if (string.IsNullOrEmpty(Objet.EN_DENOMINATION))
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_DENOMINATION";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparentrepots.Add(clsPhaparentrepot);
            //    return clsPhaparentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparentrepots.Add(clsPhaparentrepot);
            //    return clsPhaparentrepots;

            //}


            else
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparentrepots.Add(clsPhaparentrepot);
            return clsPhaparentrepots;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparentrepot> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhaparentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhaparentrepots.Add(clsPhaparentrepot);
                return clsPhaparentrepots;

            }
            else
            {
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparentrepots.Add(clsPhaparentrepot);
            return clsPhaparentrepots;

            }


        }

      

    }
}