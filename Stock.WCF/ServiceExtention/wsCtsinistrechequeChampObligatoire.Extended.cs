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
	public partial class wsCtsinistrecheque
	{

        public List<HT_Stock.BOJ.clsCtsinistrecheque> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinistrecheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }
            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }
            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrecheques.Add(clsCtsinistrecheque);
            //    return clsCtsinistrecheques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrecheques.Add(clsCtsinistrecheque);
            //    return clsCtsinistrecheques;

            //}


            else
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrecheque> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinistrecheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();

           

            if (string.IsNullOrEmpty(Objet.CH_REFCHEQUE))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_REFCHEQUE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }

            else
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrecheque> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinistrecheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();

            if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }

        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }

            if (string.IsNullOrEmpty(Objet.CH_DATESAISIECHEQUE))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATESAISIECHEQUE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }



            if (string.IsNullOrEmpty(Objet.CH_REFCHEQUE) && Objet.TYPEOPERATION!="3")
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_REFCHEQUE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrecheques.Add(clsCtsinistrecheque);
            //    return clsCtsinistrecheques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrecheques.Add(clsCtsinistrecheque);
            //    return clsCtsinistrecheques;

            //}


            else
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
            return clsCtsinistrecheques;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrecheque> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinistrecheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();

            if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
            {
                clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
                clsCtsinistrecheques.Add(clsCtsinistrecheque);
                return clsCtsinistrecheques;

            }
            else
            {
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
            return clsCtsinistrecheques;

            }


        }


    }
}