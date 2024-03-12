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
	public partial class wsBanque
	{

        public List<HT_Stock.BOJ.clsBanque> TestChampObligatoireListe(HT_Stock.BOJ.clsBanque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();

            //if (string.IsNullOrEmpty(Objet.BQ_CODEBANQUE))
            //{
            //    clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_CODEBANQUE";
            //    clsBanques.Add(clsBanque);
            //    return clsBanques;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanques.Add(clsBanque);
            //    return clsBanques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanques.Add(clsBanque);
            //    return clsBanques;

            //}


            //else
            //{
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBanque.clsObjetRetour.SL_MESSAGE = "";
                clsBanques.Add(clsBanque);
                return clsBanques;

            //}


        }

        public List<HT_Stock.BOJ.clsBanque> TestChampObligatoireInsert(HT_Stock.BOJ.clsBanque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();

           

            if (string.IsNullOrEmpty(Objet.BQ_SIGLE))
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_SIGLE";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }
            if (string.IsNullOrEmpty(Objet.BQ_RAISONSOCIAL))
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_RAISONSOCIAL";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }


            else
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBanque.clsObjetRetour.SL_MESSAGE = "";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }


        }

        public List<HT_Stock.BOJ.clsBanque> TestChampObligatoireUpdate(HT_Stock.BOJ.clsBanque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();

            if (string.IsNullOrEmpty(Objet.BQ_CODEBANQUE))
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_CODEBANQUE";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }

            if (string.IsNullOrEmpty(Objet.BQ_SIGLE))
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_SIGLE";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }

            if (string.IsNullOrEmpty(Objet.BQ_RAISONSOCIAL))
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_RAISONSOCIAL";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }
            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanque.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanques.Add(clsBanque);
            //    return clsBanques;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanque.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanque.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanques.Add(clsBanque);
            //    return clsBanques;

            //}


            else
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanque.clsObjetRetour.SL_MESSAGE = "";
            clsBanques.Add(clsBanque);
            return clsBanques;

            }


        }

        public List<HT_Stock.BOJ.clsBanque> TestChampObligatoireDelete(HT_Stock.BOJ.clsBanque Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();

            if (string.IsNullOrEmpty(Objet.BQ_CODEBANQUE))
            {
                clsBanque.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanque.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanque.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanque.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_CODEBANQUE";
                clsBanques.Add(clsBanque);
                return clsBanques;

            }
            else
            {
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanque.clsObjetRetour.SL_MESSAGE = "";
            clsBanques.Add(clsBanque);
            return clsBanques;

            }


        }


    }
}