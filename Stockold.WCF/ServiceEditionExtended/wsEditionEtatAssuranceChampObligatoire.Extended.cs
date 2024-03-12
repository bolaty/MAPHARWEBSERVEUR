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
	public partial class wsEditionEtatAssurance
	{

        public List<HT_Stock.BOJ.clsEditionEtatAssurance> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatAssurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

        }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                return clsEditionEtatAssurances;

            }


            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

        }
            else
            {
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatAssurance> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatAssurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                return clsEditionEtatAssurances;

            }

            else
            {
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                return clsEditionEtatAssurances;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatAssurance> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatAssurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
                return clsEditionEtatAssurances;

            }

            




            else
            {
                clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatAssurance> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatAssurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            //    return clsEditionEtatAssurances;

            //}
            //else
            //{
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;

            //}


        }


    }
}