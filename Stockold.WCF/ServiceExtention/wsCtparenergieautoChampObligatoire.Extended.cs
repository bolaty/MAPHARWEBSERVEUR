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
	public partial class wsCtparenergieauto
	{

        public List<HT_Stock.BOJ.clsCtparenergieauto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparenergieauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();

            //if (string.IsNullOrEmpty(Objet.EN_CODEENERGIE))
            //{
            //    clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENERGIE";
            //    clsCtparenergieautos.Add(clsCtparenergieauto);
            //    return clsCtparenergieautos;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparenergieautos.Add(clsCtparenergieauto);
            //    return clsCtparenergieautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparenergieautos.Add(clsCtparenergieauto);
            //    return clsCtparenergieautos;

            //}


            //else
            //{
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtparenergieautos.Add(clsCtparenergieauto);
                return clsCtparenergieautos;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparenergieauto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparenergieauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();

           

            if (string.IsNullOrEmpty(Objet.EN_LIBELLEENERGIE))
            {
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_LIBELLEENERGIE";
                clsCtparenergieautos.Add(clsCtparenergieauto);
                return clsCtparenergieautos;

            }

            else
            {
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtparenergieautos.Add(clsCtparenergieauto);
                return clsCtparenergieautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtparenergieauto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparenergieauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();

            if (string.IsNullOrEmpty(Objet.EN_CODEENERGIE))
            {
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENERGIE";
                clsCtparenergieautos.Add(clsCtparenergieauto);
                return clsCtparenergieautos;

            }

            if (string.IsNullOrEmpty(Objet.EN_LIBELLEENERGIE))
            {
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_LIBELLEENERGIE";
                clsCtparenergieautos.Add(clsCtparenergieauto);
                return clsCtparenergieautos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparenergieautos.Add(clsCtparenergieauto);
            //    return clsCtparenergieautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparenergieautos.Add(clsCtparenergieauto);
            //    return clsCtparenergieautos;

            //}


            else
            {
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparenergieautos.Add(clsCtparenergieauto);
            return clsCtparenergieautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtparenergieauto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparenergieauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparenergieauto> clsCtparenergieautos = new List<HT_Stock.BOJ.clsCtparenergieauto>();
            HT_Stock.BOJ.clsCtparenergieauto clsCtparenergieauto = new HT_Stock.BOJ.clsCtparenergieauto();

            if (string.IsNullOrEmpty(Objet.EN_CODEENERGIE))
            {
                clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENERGIE";
                clsCtparenergieautos.Add(clsCtparenergieauto);
                return clsCtparenergieautos;

            }
            else
            {
            clsCtparenergieauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparenergieauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparenergieauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparenergieauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparenergieautos.Add(clsCtparenergieauto);
            return clsCtparenergieautos;

            }


        }


    }
}