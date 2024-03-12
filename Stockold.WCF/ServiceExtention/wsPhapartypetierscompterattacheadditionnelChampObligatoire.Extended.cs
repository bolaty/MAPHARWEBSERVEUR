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
	public partial class wsPhapartypetierscompterattacheadditionnel
	{

        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> TestChampObligatoireListe(HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();

            if (string.IsNullOrEmpty(Objet.TC_CODECOMPTETYPETIERS))
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TC_CODECOMPTETYPETIERS";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            //    return clsPhapartypetierscompterattacheadditionnels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            //    return clsPhapartypetierscompterattacheadditionnels;

            //}


            else
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();

           

            if (string.IsNullOrEmpty(Objet.TC_LIBELLE))
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TC_LIBELLE";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }

            else
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();

            if (string.IsNullOrEmpty(Objet.TC_CODECOMPTETYPETIERS))
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TC_CODECOMPTETYPETIERS";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }

            if (string.IsNullOrEmpty(Objet.TC_LIBELLE))
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TC_LIBELLE";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            //    return clsPhapartypetierscompterattacheadditionnels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            //    return clsPhapartypetierscompterattacheadditionnels;

            //}


            else
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            return clsPhapartypetierscompterattacheadditionnels;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();

            if (string.IsNullOrEmpty(Objet.TC_CODECOMPTETYPETIERS))
            {
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TC_CODECOMPTETYPETIERS";
                clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
                return clsPhapartypetierscompterattacheadditionnels;

            }
            else
            {
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            return clsPhapartypetierscompterattacheadditionnels;

            }


        }


    }
}