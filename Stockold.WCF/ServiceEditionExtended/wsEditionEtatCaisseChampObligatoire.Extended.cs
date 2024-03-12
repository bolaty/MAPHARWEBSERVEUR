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
	public partial class wsEditionEtatCaisse
	{

        public List<HT_Stock.BOJ.clsEditionEtatCaisse> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatCaisse Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

        }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                return clsEditionEtatCaisses;

            }


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

        }
            else
            {
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatCaisse> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatCaisse Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                return clsEditionEtatCaisses;

            }

            else
            {
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                return clsEditionEtatCaisses;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatCaisse> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatCaisse Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
                return clsEditionEtatCaisses;

            }

            




            else
            {
                clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatCaisse> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatCaisse Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            //    return clsEditionEtatCaisses;

            //}
            //else
            //{
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;

            //}


        }


    }
}