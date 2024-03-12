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
	public partial class wsCtparusageauto
	{

        public List<HT_Stock.BOJ.clsCtparusageauto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparusageauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();

            //if (string.IsNullOrEmpty(Objet.US_CODEUSAGE))
            //{
            //    clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", US_CODEUSAGE";
            //    clsCtparusageautos.Add(clsCtparusageauto);
            //    return clsCtparusageautos;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparusageautos.Add(clsCtparusageauto);
            //    return clsCtparusageautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparusageautos.Add(clsCtparusageauto);
            //    return clsCtparusageautos;

            //}


            //else
            //{
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtparusageautos.Add(clsCtparusageauto);
                return clsCtparusageautos;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparusageauto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparusageauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();

           

            if (string.IsNullOrEmpty(Objet.US_LIBELLEUSAGE))
            {
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", US_LIBELLEUSAGE";
                clsCtparusageautos.Add(clsCtparusageauto);
                return clsCtparusageautos;

            }

            else
            {
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtparusageautos.Add(clsCtparusageauto);
                return clsCtparusageautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtparusageauto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparusageauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();

            if (string.IsNullOrEmpty(Objet.US_CODEUSAGE))
            {
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", US_CODEUSAGE";
                clsCtparusageautos.Add(clsCtparusageauto);
                return clsCtparusageautos;

            }

            if (string.IsNullOrEmpty(Objet.US_LIBELLEUSAGE))
            {
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", US_LIBELLEUSAGE";
                clsCtparusageautos.Add(clsCtparusageauto);
                return clsCtparusageautos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparusageautos.Add(clsCtparusageauto);
            //    return clsCtparusageautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparusageautos.Add(clsCtparusageauto);
            //    return clsCtparusageautos;

            //}


            else
            {
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparusageautos.Add(clsCtparusageauto);
            return clsCtparusageautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtparusageauto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparusageauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();

            if (string.IsNullOrEmpty(Objet.US_CODEUSAGE))
            {
                clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparusageauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparusageauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", US_CODEUSAGE";
                clsCtparusageautos.Add(clsCtparusageauto);
                return clsCtparusageautos;

            }
            else
            {
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparusageautos.Add(clsCtparusageauto);
            return clsCtparusageautos;

            }


        }


    }
}