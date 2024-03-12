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
	public partial class wsEditionEtatParametre
	{

        public List<HT_Stock.BOJ.clsEditionEtatParametre> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();

            //  Objet[0].AG_CODEAGENCE,Objet[0].DATEDEBUT,Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUREDITION,Objet[0].ET_TYPEETAT


        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

        }
        if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
        {
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUREDITION";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

        }
            else
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatParametre> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
                return clsEditionEtatParametres;

            }

            if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET)  &&  (Objet.ET_TYPEETAT== "BUDTYPE" || Objet.ET_TYPEETAT== "BUDPARAM" || Objet.ET_TYPEETAT== "PPT" || Objet.ET_TYPEETAT== "BUDPARAMD"))
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
                return clsEditionEtatParametres;

            }


            else
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
                return clsEditionEtatParametres;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatParametre> TestChampObligatoireListePlanComptable(HT_Stock.BOJ.clsEditionEtatParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
                return clsEditionEtatParametres;

            }

            else
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
                return clsEditionEtatParametres;

            }


        }



        public List<HT_Stock.BOJ.clsEditionEtatParametre> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatParametres.Add(clsEditionEtatParametre);
                return clsEditionEtatParametres;

            }

            




            else
            {
                clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatParametre> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatParametres.Add(clsEditionEtatParametre);
            //    return clsEditionEtatParametres;

            //}
            //else
            //{
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;

            //}


        }


    }
}