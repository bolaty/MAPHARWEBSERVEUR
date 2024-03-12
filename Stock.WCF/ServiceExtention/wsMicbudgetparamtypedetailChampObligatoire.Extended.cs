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
	public partial class wsMicbudgetparamtypedetail
	{

        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireListe1(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();

            if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            //    return clsMicbudgetparamtypedetails;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            //    return clsMicbudgetparamtypedetails;

            //}


            else
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireInsert1(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();



            if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }
            //if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            //{
            //    clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
            //    clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            //    return clsMicbudgetparamtypedetails;

            //}

            else
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireUpdate1(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();

            if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }
            else
            if (string.IsNullOrEmpty(Objet.BD_LIBELLE))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BD_LIBELLE";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }
            else
            if (string.IsNullOrEmpty(Objet.BD_CODETYPEBUDGETDETAIL))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BD_CODETYPEBUDGETDETAIL";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }


            else
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireDelete1(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();

            if (string.IsNullOrEmpty(Objet.BD_CODETYPEBUDGETDETAIL))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BD_CODETYPEBUDGETDETAIL";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }
            else if(string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }
           
            else
            {
                clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
                return clsMicbudgetparamtypedetails;

            }


        }


    }
}