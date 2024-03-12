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
	public partial class wsClipartypejourfacturation
	{

        public List<HT_Stock.BOJ.clsClipartypejourfacturation> TestChampObligatoireListe(HT_Stock.BOJ.clsClipartypejourfacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypejourfacturation> clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();

            //if (string.IsNullOrEmpty(Objet.JF_CODETYPEJOURFACTURATION))
            //{
            //    clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JF_CODETYPEJOURFACTURATION";
            //    clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            //    return clsClipartypejourfacturations;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            //    return clsClipartypejourfacturations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            //    return clsClipartypejourfacturations;

            //}


            //else
            //{
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                return clsClipartypejourfacturations;

            //}


        }

        public List<HT_Stock.BOJ.clsClipartypejourfacturation> TestChampObligatoireInsert(HT_Stock.BOJ.clsClipartypejourfacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypejourfacturation> clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();

           

            if (string.IsNullOrEmpty(Objet.JF_LIBELLETYPEJOURFACTURATION))
            {
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JF_LIBELLETYPEJOURFACTURATION";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                return clsClipartypejourfacturations;

            }

            else
            {
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                return clsClipartypejourfacturations;

            }


        }

        public List<HT_Stock.BOJ.clsClipartypejourfacturation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsClipartypejourfacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypejourfacturation> clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();

            if (string.IsNullOrEmpty(Objet.JF_CODETYPEJOURFACTURATION))
            {
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JF_CODETYPEJOURFACTURATION";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                return clsClipartypejourfacturations;

            }

            if (string.IsNullOrEmpty(Objet.JF_LIBELLETYPEJOURFACTURATION))
            {
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JF_LIBELLETYPEJOURFACTURATION";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                return clsClipartypejourfacturations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            //    return clsClipartypejourfacturations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            //    return clsClipartypejourfacturations;

            //}


            else
            {
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            return clsClipartypejourfacturations;

            }


        }

        public List<HT_Stock.BOJ.clsClipartypejourfacturation> TestChampObligatoireDelete(HT_Stock.BOJ.clsClipartypejourfacturation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypejourfacturation> clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();

            if (string.IsNullOrEmpty(Objet.JF_CODETYPEJOURFACTURATION))
            {
                clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JF_CODETYPEJOURFACTURATION";
                clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
                return clsClipartypejourfacturations;

            }
            else
            {
            clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            return clsClipartypejourfacturations;

            }


        }


    }
}