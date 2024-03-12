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
	public partial class wsCtparquestionnairedocumentrisqueassuranceliaison
	{

        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            //    return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            //    return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            //}


            else
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }


        }

        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();

           

            if (string.IsNullOrEmpty(Objet.DC_LIBELLEDOCUMENT))
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_LIBELLEDOCUMENT";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }

            else
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }


        }

        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }

            if (string.IsNullOrEmpty(Objet.DC_LIBELLEDOCUMENT))
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_LIBELLEDOCUMENT";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            //    return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            //    return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            //}


            else
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }


        }

        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
                return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }
            else
            {
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;

            }


        }


    }
}