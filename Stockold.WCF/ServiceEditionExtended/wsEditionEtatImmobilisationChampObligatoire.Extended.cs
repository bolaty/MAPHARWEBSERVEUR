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
	public partial class wsEditionEtatImmobilisation
	{

        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

        }

            //if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            //{
            //    clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
            //    clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            //    return clsEditionEtatImmobilisations;

            //}


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

        }
            else
            {
                clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
                return clsEditionEtatImmobilisations;

            }

            else
            {
                clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
                return clsEditionEtatImmobilisations;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
                return clsEditionEtatImmobilisations;

            }

            




            else
            {
                clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            //    return clsEditionEtatImmobilisations;

            //}
            //else
            //{
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;

            //}


        }


    }
}