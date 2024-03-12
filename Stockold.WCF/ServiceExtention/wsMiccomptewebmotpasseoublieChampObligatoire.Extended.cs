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
	public partial class wsMiccomptewebmotpasseoublie
	{

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireListe(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            //if (string.IsNullOrEmpty(Objet.RP_NUMSEQUENCE))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_NUMSEQUENCE";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            //else
            //{
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            //}


        }

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireInsert(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

           

            if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }

            else
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }


        }

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            if (string.IsNullOrEmpty(Objet.RP_NUMSEQUENCE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_NUMSEQUENCE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }

            if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            else
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

            }


        }

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireDelete(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            if (string.IsNullOrEmpty(Objet.RP_NUMSEQUENCE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_NUMSEQUENCE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            else
            {
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

            }


        }


    }
}