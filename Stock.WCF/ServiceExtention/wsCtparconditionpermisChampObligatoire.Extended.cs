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
	public partial class wsCtparconditionpermis
	{

        public List<HT_Stock.BOJ.clsCtparconditionpermis> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparconditionpermis Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();

            //if (string.IsNullOrEmpty(Objet.CD_CODECONDITION))
            //{
            //    clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CD_CODECONDITION";
            //    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            //    return clsCtparconditionpermiss;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            //    return clsCtparconditionpermiss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            //    return clsCtparconditionpermiss;

            //}


            //else
            //{
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                return clsCtparconditionpermiss;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparconditionpermis> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparconditionpermis Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();

           

            if (string.IsNullOrEmpty(Objet.CD_LIBELLECONDITION))
            {
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CD_LIBELLECONDITION";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                return clsCtparconditionpermiss;

            }

            else
            {
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                return clsCtparconditionpermiss;

            }


        }

        public List<HT_Stock.BOJ.clsCtparconditionpermis> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparconditionpermis Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();

            if (string.IsNullOrEmpty(Objet.CD_CODECONDITION))
            {
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CD_CODECONDITION";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                return clsCtparconditionpermiss;

            }

            if (string.IsNullOrEmpty(Objet.CD_LIBELLECONDITION))
            {
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CD_LIBELLECONDITION";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                return clsCtparconditionpermiss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            //    return clsCtparconditionpermiss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            //    return clsCtparconditionpermiss;

            //}


            else
            {
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "";
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            return clsCtparconditionpermiss;

            }


        }

        public List<HT_Stock.BOJ.clsCtparconditionpermis> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparconditionpermis Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparconditionpermis> clsCtparconditionpermiss = new List<HT_Stock.BOJ.clsCtparconditionpermis>();
            HT_Stock.BOJ.clsCtparconditionpermis clsCtparconditionpermis = new HT_Stock.BOJ.clsCtparconditionpermis();

            if (string.IsNullOrEmpty(Objet.CD_CODECONDITION))
            {
                clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CD_CODECONDITION";
                clsCtparconditionpermiss.Add(clsCtparconditionpermis);
                return clsCtparconditionpermiss;

            }
            else
            {
            clsCtparconditionpermis.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparconditionpermis.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparconditionpermis.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparconditionpermis.clsObjetRetour.SL_MESSAGE = "";
            clsCtparconditionpermiss.Add(clsCtparconditionpermis);
            return clsCtparconditionpermiss;

            }


        }


    }
}