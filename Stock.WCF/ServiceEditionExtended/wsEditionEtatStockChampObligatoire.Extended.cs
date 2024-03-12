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
	public partial class wsEditionEtatStock
	{

        public List<HT_Stock.BOJ.clsEditionEtatStock> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatStocks.Add(clsEditionEtatStock);
                return clsEditionEtatStocks;

            }


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }
            else
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

            }


        }
        public List<HT_Stock.BOJ.clsEditionEtatStock> TestChampObligatoireListeGenerer(HT_Stock.BOJ.clsEditionEtatStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

            //if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            //{
            //    clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
            //    clsEditionEtatStocks.Add(clsEditionEtatStock);
            //    return clsEditionEtatStocks;

            //}


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsEditionEtatStocks.Add(clsEditionEtatStock);
                return clsEditionEtatStocks;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

        }
            else
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

            }


        }
        public List<HT_Stock.BOJ.clsEditionEtatStock> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatStocks.Add(clsEditionEtatStock);
                return clsEditionEtatStocks;

            }

            else
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatStocks.Add(clsEditionEtatStock);
                return clsEditionEtatStocks;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatStock> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatStocks.Add(clsEditionEtatStock);
                return clsEditionEtatStocks;

            }

            




            else
            {
                clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatStock> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatStocks.Add(clsEditionEtatStock);
            //    return clsEditionEtatStocks;

            //}
            //else
            //{
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;

            //}


        }


    }
}