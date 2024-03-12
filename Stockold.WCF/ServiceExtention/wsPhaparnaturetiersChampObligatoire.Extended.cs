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
	public partial class wsPhaparnaturetiers
	{

        public List<HT_Stock.BOJ.clsPhaparnaturetiers> TestChampObligatoireListe(HT_Stock.BOJ.clsPhaparnaturetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();

            //if (string.IsNullOrEmpty(Objet.NT_CODENATURETIERS))
            //{
            //    clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATURETIERS";
            //    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            //    return clsPhaparnaturetierss;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            //    return clsPhaparnaturetierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            //    return clsPhaparnaturetierss;

            //}


            //else
            //{
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                return clsPhaparnaturetierss;

            //}


        }

        public List<HT_Stock.BOJ.clsPhaparnaturetiers> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhaparnaturetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();

           

            if (string.IsNullOrEmpty(Objet.NT_LIBELLE))
            {
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_LIBELLE";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                return clsPhaparnaturetierss;

            }

            else
            {
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                return clsPhaparnaturetierss;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparnaturetiers> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhaparnaturetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();

            if (string.IsNullOrEmpty(Objet.NT_CODENATURETIERS))
            {
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATURETIERS";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                return clsPhaparnaturetierss;

            }

            if (string.IsNullOrEmpty(Objet.NT_LIBELLE))
            {
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_LIBELLE";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                return clsPhaparnaturetierss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            //    return clsPhaparnaturetierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            //    return clsPhaparnaturetierss;

            //}


            else
            {
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            return clsPhaparnaturetierss;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparnaturetiers> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhaparnaturetiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();

            if (string.IsNullOrEmpty(Objet.NT_CODENATURETIERS))
            {
                clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATURETIERS";
                clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
                return clsPhaparnaturetierss;

            }
            else
            {
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            return clsPhaparnaturetierss;

            }


        }


    }
}