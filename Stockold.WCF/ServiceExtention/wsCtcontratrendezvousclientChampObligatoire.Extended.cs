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
	public partial class wsCtcontratrendezvousclient
	{

        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratrendezvousclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }
            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }
           
            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }

            else
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratrendezvousclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();

           

            if (string.IsNullOrEmpty(Objet.RD_OBJETRENDEZVOUS))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RD_OBJETRENDEZVOUS";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }

            else
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratrendezvousclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();

            if (string.IsNullOrEmpty(Objet.RD_INDEXRENDEZVOUS))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RD_INDEXRENDEZVOUS";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }

            if (string.IsNullOrEmpty(Objet.RD_OBJETRENDEZVOUS))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RD_OBJETRENDEZVOUS";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            //    return clsCtcontratrendezvousclients;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            //    return clsCtcontratrendezvousclients;

            //}


            else
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            return clsCtcontratrendezvousclients;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratrendezvousclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();

            if (string.IsNullOrEmpty(Objet.RD_INDEXRENDEZVOUS))
            {
                clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RD_INDEXRENDEZVOUS";
                clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
                return clsCtcontratrendezvousclients;

            }
            else
            {
            clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            return clsCtcontratrendezvousclients;

            }


        }


    }
}