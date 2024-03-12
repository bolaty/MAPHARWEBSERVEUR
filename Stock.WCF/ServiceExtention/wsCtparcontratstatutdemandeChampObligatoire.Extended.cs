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
	public partial class wsCtparcontratstatutdemande
	{

        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparcontratstatutdemande Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();

            //if (string.IsNullOrEmpty(Objet.SD_CODEPIECE))
            //{
            //    clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_CODEPIECE";
            //    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            //    return clsCtparcontratstatutdemandes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            //    return clsCtparcontratstatutdemandes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            //    return clsCtparcontratstatutdemandes;

            //}


            //else
            //{
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                return clsCtparcontratstatutdemandes;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparcontratstatutdemande Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();

           

            if (string.IsNullOrEmpty(Objet.SD_LIBELLEPIECE))
            {
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_LIBELLEPIECE";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                return clsCtparcontratstatutdemandes;

            }

            else
            {
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                return clsCtparcontratstatutdemandes;

            }


        }

        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparcontratstatutdemande Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();

            if (string.IsNullOrEmpty(Objet.SD_CODEPIECE))
            {
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_CODEPIECE";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                return clsCtparcontratstatutdemandes;

            }

            if (string.IsNullOrEmpty(Objet.SD_LIBELLEPIECE))
            {
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_LIBELLEPIECE";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                return clsCtparcontratstatutdemandes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            //    return clsCtparcontratstatutdemandes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            //    return clsCtparcontratstatutdemandes;

            //}


            else
            {
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            return clsCtparcontratstatutdemandes;

            }


        }

        public List<HT_Stock.BOJ.clsCtparcontratstatutdemande> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparcontratstatutdemande Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparcontratstatutdemande> clsCtparcontratstatutdemandes = new List<HT_Stock.BOJ.clsCtparcontratstatutdemande>();
            HT_Stock.BOJ.clsCtparcontratstatutdemande clsCtparcontratstatutdemande = new HT_Stock.BOJ.clsCtparcontratstatutdemande();

            if (string.IsNullOrEmpty(Objet.SD_CODEPIECE))
            {
                clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_CODEPIECE";
                clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
                return clsCtparcontratstatutdemandes;

            }
            else
            {
            clsCtparcontratstatutdemande.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcontratstatutdemande.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcontratstatutdemande.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcontratstatutdemandes.Add(clsCtparcontratstatutdemande);
            return clsCtparcontratstatutdemandes;

            }


        }


    }
}