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
	public partial class wsOperateurdroitagence
	{

        public List<HT_Stock.BOJ.clsOperateurdroitagence> TestChampObligatoireListe(HT_Stock.BOJ.clsOperateurdroitagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitagences.Add(clsOperateurdroitagence);
            //    return clsOperateurdroitagences;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitagences.Add(clsOperateurdroitagence);
            //    return clsOperateurdroitagences;

            //}


            else
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitagence> TestChampObligatoireInsert(HT_Stock.BOJ.clsOperateurdroitagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }

            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }

            else
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitagence> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOperateurdroitagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitagences.Add(clsOperateurdroitagence);
            //    return clsOperateurdroitagences;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitagences.Add(clsOperateurdroitagence);
            //    return clsOperateurdroitagences;

            //}


            else
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
            return clsOperateurdroitagences;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitagence> TestChampObligatoireDelete(HT_Stock.BOJ.clsOperateurdroitagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitagence> clsOperateurdroitagences = new List<HT_Stock.BOJ.clsOperateurdroitagence>();
            HT_Stock.BOJ.clsOperateurdroitagence clsOperateurdroitagence = new HT_Stock.BOJ.clsOperateurdroitagence();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitagences.Add(clsOperateurdroitagence);
                return clsOperateurdroitagences;

            }
            else
            {
            clsOperateurdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitagence.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitagences.Add(clsOperateurdroitagence);
            return clsOperateurdroitagences;

            }


        }


    }
}