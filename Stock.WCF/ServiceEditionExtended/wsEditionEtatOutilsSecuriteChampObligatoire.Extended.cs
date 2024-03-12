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
	public partial class wsEditionEtatOutilsSecurite
	{

        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatOutilsSecurite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
                return clsEditionEtatOutilsSecurites;

            }


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }
            else
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

            }


        }
        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> TestChampObligatoireListeGenerer(HT_Stock.BOJ.clsEditionEtatOutilsSecurite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

            //if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            //{
            //    clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
            //    clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            //    return clsEditionEtatOutilsSecurites;

            //}


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
                return clsEditionEtatOutilsSecurites;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

        }
            else
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

            }


        }
        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatOutilsSecurite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
                return clsEditionEtatOutilsSecurites;

            }

            else
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
                return clsEditionEtatOutilsSecurites;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatOutilsSecurite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
                return clsEditionEtatOutilsSecurites;

            }

            




            else
            {
                clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatOutilsSecurite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            //    return clsEditionEtatOutilsSecurites;

            //}
            //else
            //{
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;

            //}


        }


    }
}