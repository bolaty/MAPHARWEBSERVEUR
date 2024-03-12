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
	public partial class wsCtparreduction
	{

        public List<HT_Stock.BOJ.clsCtparreduction> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparreduction Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparreduction> clsCtparreductions = new List<HT_Stock.BOJ.clsCtparreduction>();
            HT_Stock.BOJ.clsCtparreduction clsCtparreduction = new HT_Stock.BOJ.clsCtparreduction();

            //if (string.IsNullOrEmpty(Objet.RD_CODEREDUCTION))
            //{
            //    clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparreduction.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparreduction.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RD_CODEREDUCTION";
            //    clsCtparreductions.Add(clsCtparreduction);
            //    return clsCtparreductions;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparreduction.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparreduction.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparreductions.Add(clsCtparreduction);
            //    return clsCtparreductions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparreduction.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparreduction.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparreductions.Add(clsCtparreduction);
            //    return clsCtparreductions;

            //}


            //else
            //{
                clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparreduction.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparreduction.clsObjetRetour.SL_MESSAGE = "";
                clsCtparreductions.Add(clsCtparreduction);
                return clsCtparreductions;

            //}


        }


    }
}