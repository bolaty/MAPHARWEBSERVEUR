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
	public partial class wsNumeroDebut
	{

        public List<HT_Stock.BOJ.clsPlancomptable> TestChampObligatoireListe(HT_Stock.BOJ.clsPlancomptable Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();

            //if (string.IsNullOrEmpty(Objet.PL_CODENUMERODEBUT))
            //{
            //    clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptable.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPlancomptable.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_CODENUMERODEBUT";
            //    clsPlancomptables.Add(clsPlancomptable);
            //    return clsPlancomptables;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptables.Add(clsPlancomptable);
            //    return clsPlancomptables;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptables.Add(clsPlancomptable);
            //    return clsPlancomptables;

            //}


            //else
            //{
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
                clsPlancomptables.Add(clsPlancomptable);
                return clsPlancomptables;

            //}


        }

        public List<HT_Stock.BOJ.clsPlancomptable> TestChampObligatoireInsert(HT_Stock.BOJ.clsPlancomptable Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();

           

            if (string.IsNullOrEmpty(Objet.PL_LIBELLENUMERODEBUT))
            {
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_LIBELLENUMERODEBUT";
                clsPlancomptables.Add(clsPlancomptable);
                return clsPlancomptables;

            }

            else
            {
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
                clsPlancomptables.Add(clsPlancomptable);
                return clsPlancomptables;

            }


        }

        public List<HT_Stock.BOJ.clsPlancomptable> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPlancomptable Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();

            if (string.IsNullOrEmpty(Objet.PL_CODENUMERODEBUT))
            {
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_CODENUMERODEBUT";
                clsPlancomptables.Add(clsPlancomptable);
                return clsPlancomptables;

            }

            if (string.IsNullOrEmpty(Objet.PL_LIBELLENUMERODEBUT))
            {
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_LIBELLENUMERODEBUT";
                clsPlancomptables.Add(clsPlancomptable);
                return clsPlancomptables;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptables.Add(clsPlancomptable);
            //    return clsPlancomptables;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptable.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptable.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptables.Add(clsPlancomptable);
            //    return clsPlancomptables;

            //}


            else
            {
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptables.Add(clsPlancomptable);
            return clsPlancomptables;

            }


        }

        public List<HT_Stock.BOJ.clsPlancomptable> TestChampObligatoireDelete(HT_Stock.BOJ.clsPlancomptable Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();

            if (string.IsNullOrEmpty(Objet.PL_CODENUMERODEBUT))
            {
                clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptable.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptable.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_CODENUMERODEBUT";
                clsPlancomptables.Add(clsPlancomptable);
                return clsPlancomptables;

            }
            else
            {
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptables.Add(clsPlancomptable);
            return clsPlancomptables;

            }


        }


    }
}