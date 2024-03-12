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
	public partial class wsSmsout
	{

        public List<HT_Stock.BOJ.clsSmsout> TestChampObligatoireListe(HT_Stock.BOJ.clsSmsout Objet)
        {
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();

                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "";
                clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsSmsout.clsObjetRetour.SL_MESSAGE = "";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
        }

        public List<HT_Stock.BOJ.clsSmsout> TestChampObligatoireInsert(HT_Stock.BOJ.clsSmsout Objet)
        {
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSmsout.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSmsout.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
            else if (string.IsNullOrEmpty(Objet.SM_DATEPIECE))
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSmsout.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSmsout.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SM_DATEPIECE";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
            else
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "";
                clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsSmsout.clsObjetRetour.SL_MESSAGE = "";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
        }

        public List<HT_Stock.BOJ.clsSmsout> TestChampObligatoireUpdate(HT_Stock.BOJ.clsSmsout Objet)
        {
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSmsout.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSmsout.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
            else if (string.IsNullOrEmpty(Objet.SM_DATEPIECE))
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSmsout.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSmsout.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SM_DATEPIECE";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
            else
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "";
                clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsSmsout.clsObjetRetour.SL_MESSAGE = "";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
        }

        public List<HT_Stock.BOJ.clsSmsout> TestChampObligatoireDelete(HT_Stock.BOJ.clsSmsout Objet)
        {
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSmsout.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSmsout.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
            else if (string.IsNullOrEmpty(Objet.SM_DATEPIECE))
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSmsout.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSmsout.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SM_DATEPIECE";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
            else
            {
                clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
                clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "";
                clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsSmsout.clsObjetRetour.SL_MESSAGE = "";
                clsSmsouts.Add(clsSmsout);
                return clsSmsouts;
            }
        }
    }
}