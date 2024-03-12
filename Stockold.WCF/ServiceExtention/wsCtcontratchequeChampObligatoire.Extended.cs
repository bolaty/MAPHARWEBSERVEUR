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
	public partial class wsCtcontratcheque
	{

        public List<HT_Stock.BOJ.clsCtcontratcheque> TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratcheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }
            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }
            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratcheques.Add(clsCtcontratcheque);
            //    return clsCtcontratcheques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratcheques.Add(clsCtcontratcheque);
            //    return clsCtcontratcheques;

            //}


            else
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratcheque> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratcheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();

           

            if (string.IsNullOrEmpty(Objet.CH_REFCHEQUE))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_REFCHEQUE";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }

            else
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratcheque> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratcheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();

            if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }

        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }

            if (string.IsNullOrEmpty(Objet.CH_DATESAISIECHEQUE))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATESAISIECHEQUE";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }



            if (string.IsNullOrEmpty(Objet.CH_REFCHEQUE) && Objet.TYPEOPERATION!="3")
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_REFCHEQUE";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratcheques.Add(clsCtcontratcheque);
            //    return clsCtcontratcheques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratcheques.Add(clsCtcontratcheque);
            //    return clsCtcontratcheques;

            //}


            else
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratcheques.Add(clsCtcontratcheque);
            return clsCtcontratcheques;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratcheque> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratcheque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();

            if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
            {
                clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
                clsCtcontratcheques.Add(clsCtcontratcheque);
                return clsCtcontratcheques;

            }
            else
            {
            clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratcheques.Add(clsCtcontratcheque);
            return clsCtcontratcheques;

            }


        }


    }
}