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
	public partial class wsStatutContrat
    {

        public List<HT_Stock.BOJ.clsCtparstatutcontrat> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparstatutcontrat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutcontrat> clsCtparstatutcontrats = new List<HT_Stock.BOJ.clsCtparstatutcontrat>();
            HT_Stock.BOJ.clsCtparstatutcontrat clsCtparstatutcontrat = new HT_Stock.BOJ.clsCtparstatutcontrat();

            //if (string.IsNullOrEmpty(Objet.CT_CODESTAUT))
            //{
            //    clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CT_CODESTAUT";
            //    clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            //    return clsCtparstatutcontrats;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            //    return clsCtparstatutcontrats;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            //    return clsCtparstatutcontrats;

            //}


            //else
            //{
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "";
                clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
                return clsCtparstatutcontrats;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparstatutcontrat> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparstatutcontrat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutcontrat> clsCtparstatutcontrats = new List<HT_Stock.BOJ.clsCtparstatutcontrat>();
            HT_Stock.BOJ.clsCtparstatutcontrat clsCtparstatutcontrat = new HT_Stock.BOJ.clsCtparstatutcontrat();

           

            if (string.IsNullOrEmpty(Objet.CT_LIBELLESTATUT))
            {
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CT_LIBELLESTATUT";
                clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
                return clsCtparstatutcontrats;

            }

            else
            {
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "";
                clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
                return clsCtparstatutcontrats;

            }


        }

        public List<HT_Stock.BOJ.clsCtparstatutcontrat> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparstatutcontrat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutcontrat> clsCtparstatutcontrats = new List<HT_Stock.BOJ.clsCtparstatutcontrat>();
            HT_Stock.BOJ.clsCtparstatutcontrat clsCtparstatutcontrat = new HT_Stock.BOJ.clsCtparstatutcontrat();

            if (string.IsNullOrEmpty(Objet.CT_CODESTAUT))
            {
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CT_CODESTAUT";
                clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
                return clsCtparstatutcontrats;

            }

            if (string.IsNullOrEmpty(Objet.CT_LIBELLESTATUT))
            {
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CT_LIBELLESTATUT";
                clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
                return clsCtparstatutcontrats;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            //    return clsCtparstatutcontrats;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            //    return clsCtparstatutcontrats;

            //}


            else
            {
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            return clsCtparstatutcontrats;

            }


        }

        public List<HT_Stock.BOJ.clsCtparstatutcontrat> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparstatutcontrat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutcontrat> clsCtparstatutcontrats = new List<HT_Stock.BOJ.clsCtparstatutcontrat>();
            HT_Stock.BOJ.clsCtparstatutcontrat clsCtparstatutcontrat = new HT_Stock.BOJ.clsCtparstatutcontrat();

            if (string.IsNullOrEmpty(Objet.CT_CODESTAUT))
            {
                clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CT_CODESTAUT";
                clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
                return clsCtparstatutcontrats;

            }
            else
            {
            clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            return clsCtparstatutcontrats;

            }


        }


    }
}