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
	public partial class wsPhamouvementStock
	{

        public List<HT_Stock.BOJ.clsPhamouvementStock> TestChampObligatoireListe(HT_Stock.BOJ.clsPhamouvementStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            if (string.IsNullOrEmpty(Objet.MS_ANNULATIONPIECE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_ANNULATIONPIECE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }

        if (string.IsNullOrEmpty(Objet.TP_CODETYPETIERS))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TP_CODETYPETIERS";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }



            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementStocks.Add(clsPhamouvementStock);
            //    return clsPhamouvementStocks;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementStocks.Add(clsPhamouvementStock);
            //    return clsPhamouvementStocks;

            //}


            else
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementStock> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhamouvementStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();

           

            if (string.IsNullOrEmpty(Objet.MS_LIBOPERA))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_LIBOPERA";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }

            else
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementStock> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhamouvementStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();

            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }

            if (string.IsNullOrEmpty(Objet.MS_LIBOPERA))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_LIBOPERA";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementStocks.Add(clsPhamouvementStock);
            //    return clsPhamouvementStocks;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementStocks.Add(clsPhamouvementStock);
            //    return clsPhamouvementStocks;

            //}


            else
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            return clsPhamouvementStocks;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementStock> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhamouvementStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();

            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            else
            {
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            return clsPhamouvementStocks;

            }


        }
        public List<HT_Stock.BOJ.clsPhamouvementStock> TestChampObligatoireAnnulerFactureMaphar(HT_Stock.BOJ.clsPhamouvementStock Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }


            else
            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            //else
            //if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            //{
            //    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
            //    clsPhamouvementStocks.Add(clsPhamouvementStock);
            //    return clsPhamouvementStocks;

            //}
            //else
            //if (string.IsNullOrEmpty(Objet.MS_DATESAISIE))
            //{
            //    clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_DATESAISIE";
            //    clsPhamouvementStocks.Add(clsPhamouvementStock);
            //    return clsPhamouvementStocks;

            //}
            else
            if (string.IsNullOrEmpty(Objet.CA_DATESAISIE))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_DATESAISIE";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            else
            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }
            else
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsPhamouvementStocks.Add(clsPhamouvementStock);
                return clsPhamouvementStocks;

            }

            else
            {
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            return clsPhamouvementStocks;

            }


        }

    }
}