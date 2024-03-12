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
	public partial class wsPhamouvementstockfiltragedestock
	{

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> TestChampObligatoireListe(HT_Stock.BOJ.clsPhamouvementstockfiltragedestock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();

            //if (string.IsNullOrEmpty(Objet.MF_IDFILTRAGEDESTOCK))
            //{
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_IDFILTRAGEDESTOCK";
            //    clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            //    return clsPhamouvementstockfiltragedestocks;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            //    return clsPhamouvementstockfiltragedestocks;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            //    return clsPhamouvementstockfiltragedestocks;

            //}


            //else
            //{
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                return clsPhamouvementstockfiltragedestocks;

            //}


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhamouvementstockfiltragedestock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();

           

            if (string.IsNullOrEmpty(Objet.MF_NUMEROLOTFILTRAGEDESTOCK))
            {
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_NUMEROLOTFILTRAGEDESTOCK";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                return clsPhamouvementstockfiltragedestocks;

            }

            else
            {
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                return clsPhamouvementstockfiltragedestocks;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhamouvementstockfiltragedestock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();

            if (string.IsNullOrEmpty(Objet.MF_IDFILTRAGEDESTOCK))
            {
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_IDFILTRAGEDESTOCK";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                return clsPhamouvementstockfiltragedestocks;

            }

            if (string.IsNullOrEmpty(Objet.MF_NUMEROLOTFILTRAGEDESTOCK))
            {
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_NUMEROLOTFILTRAGEDESTOCK";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                return clsPhamouvementstockfiltragedestocks;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            //    return clsPhamouvementstockfiltragedestocks;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            //    return clsPhamouvementstockfiltragedestocks;

            //}


            else
            {
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            return clsPhamouvementstockfiltragedestocks;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhamouvementstockfiltragedestock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();

            if (string.IsNullOrEmpty(Objet.MF_IDFILTRAGEDESTOCK))
            {
                clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MF_IDFILTRAGEDESTOCK";
                clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
                return clsPhamouvementstockfiltragedestocks;

            }
            else
            {
            clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            return clsPhamouvementstockfiltragedestocks;

            }


        }


    }
}