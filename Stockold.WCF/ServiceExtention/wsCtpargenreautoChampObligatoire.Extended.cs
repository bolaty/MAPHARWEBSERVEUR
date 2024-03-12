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
	public partial class wsCtpargenreauto
	{

        public List<HT_Stock.BOJ.clsCtpargenreauto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpargenreauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();

            //if (string.IsNullOrEmpty(Objet.GE_CODEGENRE))
            //{
            //    clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GE_CODEGENRE";
            //    clsCtpargenreautos.Add(clsCtpargenreauto);
            //    return clsCtpargenreautos;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargenreautos.Add(clsCtpargenreauto);
            //    return clsCtpargenreautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargenreautos.Add(clsCtpargenreauto);
            //    return clsCtpargenreautos;

            //}


            //else
            //{
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtpargenreautos.Add(clsCtpargenreauto);
                return clsCtpargenreautos;

            //}


        }

        public List<HT_Stock.BOJ.clsCtpargenreauto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpargenreauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();

           

            if (string.IsNullOrEmpty(Objet.GE_LIBELLEGENRE))
            {
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GE_LIBELLEGENRE";
                clsCtpargenreautos.Add(clsCtpargenreauto);
                return clsCtpargenreautos;

            }

            else
            {
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtpargenreautos.Add(clsCtpargenreauto);
                return clsCtpargenreautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtpargenreauto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpargenreauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();

            if (string.IsNullOrEmpty(Objet.GE_CODEGENRE))
            {
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GE_CODEGENRE";
                clsCtpargenreautos.Add(clsCtpargenreauto);
                return clsCtpargenreautos;

            }

            if (string.IsNullOrEmpty(Objet.GE_LIBELLEGENRE))
            {
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GE_LIBELLEGENRE";
                clsCtpargenreautos.Add(clsCtpargenreauto);
                return clsCtpargenreautos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargenreautos.Add(clsCtpargenreauto);
            //    return clsCtpargenreautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpargenreautos.Add(clsCtpargenreauto);
            //    return clsCtpargenreautos;

            //}


            else
            {
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargenreautos.Add(clsCtpargenreauto);
            return clsCtpargenreautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtpargenreauto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpargenreauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();

            if (string.IsNullOrEmpty(Objet.GE_CODEGENRE))
            {
                clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", GE_CODEGENRE";
                clsCtpargenreautos.Add(clsCtpargenreauto);
                return clsCtpargenreautos;

            }
            else
            {
            clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargenreautos.Add(clsCtpargenreauto);
            return clsCtpargenreautos;

            }


        }


    }
}