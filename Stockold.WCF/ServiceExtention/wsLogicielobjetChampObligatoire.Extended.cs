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
	public partial class wsLogicielobjet
	{

        public List<HT_Stock.BOJ.clsLogicielobjet> TestChampObligatoireListe(HT_Stock.BOJ.clsLogicielobjet Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();

           // Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL

            if (string.IsNullOrEmpty(Objet.OT_CODETYPEOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OT_CODETYPEOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }

            


            else
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }


        }
        public List<HT_Stock.BOJ.clsLogicielobjet> TestChampObligatoireListe1(HT_Stock.BOJ.clsLogicielobjet Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();

           // Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL

            if (string.IsNullOrEmpty(Objet.OT_CODETYPEOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OT_CODETYPEOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }           


            else
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }


        }
        public List<HT_Stock.BOJ.clsLogicielobjet> TestChampObligatoireInsert(HT_Stock.BOJ.clsLogicielobjet Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();

           

            if (string.IsNullOrEmpty(Objet.OB_NOMOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_NOMOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }

            else
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjet> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogicielobjet Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }

            if (string.IsNullOrEmpty(Objet.OB_NOMOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_NOMOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjets.Add(clsLogicielobjet);
            //    return clsLogicielobjets;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjets.Add(clsLogicielobjet);
            //    return clsLogicielobjets;

            //}


            else
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjets.Add(clsLogicielobjet);
            return clsLogicielobjets;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjet> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogicielobjet Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjet> clsLogicielobjets = new List<HT_Stock.BOJ.clsLogicielobjet>();
            HT_Stock.BOJ.clsLogicielobjet clsLogicielobjet = new HT_Stock.BOJ.clsLogicielobjet();

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjet.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjet.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsLogicielobjets.Add(clsLogicielobjet);
                return clsLogicielobjets;

            }
            else
            {
            clsLogicielobjet.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjet.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjet.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjet.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjets.Add(clsLogicielobjet);
            return clsLogicielobjets;

            }


        }


    }
}