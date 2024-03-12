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
	public partial class wsPhaparcasutilisationtiers
	{

        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestChampObligatoireListe(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();

            //if (string.IsNullOrEmpty(Objet.CU_CODECASUTILISATION))
            //{
            //    clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CU_CODECASUTILISATION";
            //    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            //    return clsPhaparcasutilisationtierss;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            //    return clsPhaparcasutilisationtierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            //    return clsPhaparcasutilisationtierss;

            //}


            //else
            //{
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                return clsPhaparcasutilisationtierss;

            //}


        }

        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();

           

            if (string.IsNullOrEmpty(Objet.CU_LIBELLE))
            {
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CU_LIBELLE";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                return clsPhaparcasutilisationtierss;

            }

            else
            {
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                return clsPhaparcasutilisationtierss;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();

            if (string.IsNullOrEmpty(Objet.CU_CODECASUTILISATION))
            {
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CU_CODECASUTILISATION";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                return clsPhaparcasutilisationtierss;

            }

            if (string.IsNullOrEmpty(Objet.CU_LIBELLE))
            {
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CU_LIBELLE";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                return clsPhaparcasutilisationtierss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            //    return clsPhaparcasutilisationtierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            //    return clsPhaparcasutilisationtierss;

            //}


            else
            {
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            return clsPhaparcasutilisationtierss;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();

            if (string.IsNullOrEmpty(Objet.CU_CODECASUTILISATION))
            {
                clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CU_CODECASUTILISATION";
                clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
                return clsPhaparcasutilisationtierss;

            }
            else
            {
            clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            return clsPhaparcasutilisationtierss;

            }


        }


    }
}