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
	public partial class wsLogicielobjetweb
	{

        public List<HT_Stock.BOJ.clsLogicielobjetweb> TestChampObligatoireListe(HT_Stock.BOJ.clsLogicielobjetweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();

           // Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL

            if (string.IsNullOrEmpty(Objet.OT_CODETYPEOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OT_CODETYPEOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }

            


            else
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }


        }
        public List<HT_Stock.BOJ.clsLogicielobjetweb> TestChampObligatoireListe1(HT_Stock.BOJ.clsLogicielobjetweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();

           // Objet[0].OT_CODETYPEOBJET,Objet[0].LO_CODELOGICIEL

            if (string.IsNullOrEmpty(Objet.OT_CODETYPEOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OT_CODETYPEOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }           


            else
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }


        }
        public List<HT_Stock.BOJ.clsLogicielobjetweb> TestChampObligatoireInsert(HT_Stock.BOJ.clsLogicielobjetweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();

           

            if (string.IsNullOrEmpty(Objet.OB_NOMOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_NOMOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }

            else
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjetweb> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogicielobjetweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }

            if (string.IsNullOrEmpty(Objet.OB_NOMOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_NOMOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            //    return clsLogicielobjetwebs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            //    return clsLogicielobjetwebs;

            //}


            else
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            return clsLogicielobjetwebs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjetweb> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogicielobjetweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsLogicielobjetwebs.Add(clsLogicielobjetweb);
                return clsLogicielobjetwebs;

            }
            else
            {
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            return clsLogicielobjetwebs;

            }


        }


    }
}