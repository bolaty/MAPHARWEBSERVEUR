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
	public partial class wsCtparcapitauxrisqueassuranceliaison
	{

        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            //    return clsCtparcapitauxrisqueassuranceliaisons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            //    return clsCtparcapitauxrisqueassuranceliaisons;

            //}


            else
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }


        }

        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();

           

            if (string.IsNullOrEmpty(Objet.CP_LIBELLECAPITAUX))
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_LIBELLECAPITAUX";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }

            else
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }


        }

        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.CP_CODECAPITAUX))
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_CODECAPITAUX";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }

            if (string.IsNullOrEmpty(Objet.CP_LIBELLECAPITAUX))
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_LIBELLECAPITAUX";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            //    return clsCtparcapitauxrisqueassuranceliaisons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            //    return clsCtparcapitauxrisqueassuranceliaisons;

            //}


            else
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            return clsCtparcapitauxrisqueassuranceliaisons;

            }


        }

        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();

            if (string.IsNullOrEmpty(Objet.CP_CODECAPITAUX))
            {
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_CODECAPITAUX";
                clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
                return clsCtparcapitauxrisqueassuranceliaisons;

            }
            else
            {
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            return clsCtparcapitauxrisqueassuranceliaisons;

            }


        }


    }
}