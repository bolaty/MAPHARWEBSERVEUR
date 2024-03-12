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
	public partial class wsCtpardesignation
	{

        public List<HT_Stock.BOJ.clsCtpardesignation> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpardesignation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpardesignation> clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
            HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();

            if (string.IsNullOrEmpty(Objet.DI_CODEDESIGNATION))
            {
                clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpardesignation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpardesignation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PY_CODEPAYS";
                clsCtpardesignations.Add(clsCtpardesignation);
                return clsCtpardesignations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpardesignation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpardesignations.Add(clsCtpardesignation);
            //    return clsCtpardesignations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpardesignation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpardesignations.Add(clsCtpardesignation);
            //    return clsCtpardesignations;

            //}


            else
            {
                clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpardesignation.clsObjetRetour.SL_MESSAGE = "";
                clsCtpardesignations.Add(clsCtpardesignation);
                return clsCtpardesignations;

            }


        }


    }
}