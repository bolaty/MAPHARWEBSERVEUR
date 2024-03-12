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
	public partial class wsPhapartypetiers
	{

        public List<HT_Stock.BOJ.clsPhapartypetiers> TestChampObligatoireListe(HT_Stock.BOJ.clsPhapartypetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();

            if (string.IsNullOrEmpty(Objet.MG_CODEMODEGESTION))
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MG_CODEMODEGESTION";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }
            if (string.IsNullOrEmpty(Objet.EC_CODECRAN))
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EC_CODECRAN";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierss.Add(clsPhapartypetiers);
            //    return clsPhapartypetierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierss.Add(clsPhapartypetiers);
            //    return clsPhapartypetierss;

            //}


            //else
            //{
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            //}


        }

        public List<HT_Stock.BOJ.clsPhapartypetiers> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhapartypetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();

           

            if (string.IsNullOrEmpty(Objet.TP_LIBELLE))
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TP_LIBELLE";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }

            else
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypetiers> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhapartypetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();

            if (string.IsNullOrEmpty(Objet.TP_CODETYPETIERS))
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TP_CODETYPETIERS";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }

            if (string.IsNullOrEmpty(Objet.TP_LIBELLE))
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TP_LIBELLE";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierss.Add(clsPhapartypetiers);
            //    return clsPhapartypetierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypetierss.Add(clsPhapartypetiers);
            //    return clsPhapartypetierss;

            //}


            else
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierss.Add(clsPhapartypetiers);
            return clsPhapartypetierss;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypetiers> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhapartypetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();

            if (string.IsNullOrEmpty(Objet.TP_CODETYPETIERS))
            {
                clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TP_CODETYPETIERS";
                clsPhapartypetierss.Add(clsPhapartypetiers);
                return clsPhapartypetierss;

            }
            else
            {
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierss.Add(clsPhapartypetiers);
            return clsPhapartypetierss;

            }


        }


    }
}