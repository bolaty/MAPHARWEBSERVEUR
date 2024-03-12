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
	public partial class wsCtpartarif
	{

        public List<HT_Stock.BOJ.clsCtpartarif> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();

            //if (string.IsNullOrEmpty(Objet.TA_CODETARIF))
            //{
            //    clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtpartarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETARIF";
            //    clsCtpartarifs.Add(clsCtpartarif);
            //    return clsCtpartarifs;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartarifs.Add(clsCtpartarif);
            //    return clsCtpartarifs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartarifs.Add(clsCtpartarif);
            //    return clsCtpartarifs;

            //}


            //else
            //{
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartarifs.Add(clsCtpartarif);
                return clsCtpartarifs;

            //}


        }

        public List<HT_Stock.BOJ.clsCtpartarif> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpartarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();

           

            if (string.IsNullOrEmpty(Objet.TA_LIBELLETARIF))
            {
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLETARIF";
                clsCtpartarifs.Add(clsCtpartarif);
                return clsCtpartarifs;

            }

            else
            {
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartarifs.Add(clsCtpartarif);
                return clsCtpartarifs;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartarif> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpartarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();

            if (string.IsNullOrEmpty(Objet.TA_CODETARIF))
            {
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETARIF";
                clsCtpartarifs.Add(clsCtpartarif);
                return clsCtpartarifs;

            }

            if (string.IsNullOrEmpty(Objet.TA_LIBELLETARIF))
            {
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLETARIF";
                clsCtpartarifs.Add(clsCtpartarif);
                return clsCtpartarifs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartarifs.Add(clsCtpartarif);
            //    return clsCtpartarifs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartarif.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartarifs.Add(clsCtpartarif);
            //    return clsCtpartarifs;

            //}


            else
            {
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartarifs.Add(clsCtpartarif);
            return clsCtpartarifs;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartarif> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpartarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();

            if (string.IsNullOrEmpty(Objet.TA_CODETARIF))
            {
                clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETARIF";
                clsCtpartarifs.Add(clsCtpartarif);
                return clsCtpartarifs;

            }
            else
            {
            clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartarifs.Add(clsCtpartarif);
            return clsCtpartarifs;

            }


        }


    }
}