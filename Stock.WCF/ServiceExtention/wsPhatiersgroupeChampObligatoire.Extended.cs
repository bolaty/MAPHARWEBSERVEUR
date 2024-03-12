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
	public partial class wsPhatiersgroupe
	{

        public List<HT_Stock.BOJ.clsPhatiersgroupe> TestChampObligatoireListe(HT_Stock.BOJ.clsPhatiersgroupe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();

            //if (string.IsNullOrEmpty(Objet.GP_CODEGROUPE))
            //{
            //    clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GP_CODEGROUPE";
            //    clsPhatiersgroupes.Add(clsPhatiersgroupe);
            //    return clsPhatiersgroupes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersgroupes.Add(clsPhatiersgroupe);
            //    return clsPhatiersgroupes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersgroupes.Add(clsPhatiersgroupe);
            //    return clsPhatiersgroupes;

            //}


            //else
            //{
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
                return clsPhatiersgroupes;

            //}


        }

        public List<HT_Stock.BOJ.clsPhatiersgroupe> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhatiersgroupe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();

           

            if (string.IsNullOrEmpty(Objet.GP_LIBELLE))
            {
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GP_LIBELLE";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
                return clsPhatiersgroupes;

            }

            else
            {
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
                return clsPhatiersgroupes;

            }


        }

        public List<HT_Stock.BOJ.clsPhatiersgroupe> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhatiersgroupe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();

            if (string.IsNullOrEmpty(Objet.GP_CODEGROUPE))
            {
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GP_CODEGROUPE";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
                return clsPhatiersgroupes;

            }

            if (string.IsNullOrEmpty(Objet.GP_LIBELLE))
            {
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GP_LIBELLE";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
                return clsPhatiersgroupes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersgroupes.Add(clsPhatiersgroupe);
            //    return clsPhatiersgroupes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersgroupes.Add(clsPhatiersgroupe);
            //    return clsPhatiersgroupes;

            //}


            else
            {
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
            return clsPhatiersgroupes;

            }


        }

        public List<HT_Stock.BOJ.clsPhatiersgroupe> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhatiersgroupe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();

            if (string.IsNullOrEmpty(Objet.GP_CODEGROUPE))
            {
                clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GP_CODEGROUPE";
                clsPhatiersgroupes.Add(clsPhatiersgroupe);
                return clsPhatiersgroupes;

            }
            else
            {
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
            return clsPhatiersgroupes;

            }


        }


    }
}