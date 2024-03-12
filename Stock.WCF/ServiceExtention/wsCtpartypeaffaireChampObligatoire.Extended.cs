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
	public partial class wsCtpartypeaffaire
	{

        public List<HT_Stock.BOJ.clsCtpartypeaffaire> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartypeaffaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeaffaire> clsCtpartypeaffaires = new List<HT_Stock.BOJ.clsCtpartypeaffaire>();
            HT_Stock.BOJ.clsCtpartypeaffaire clsCtpartypeaffaire = new HT_Stock.BOJ.clsCtpartypeaffaire();

            if (string.IsNullOrEmpty(Objet.TA_CODETYPEAFFAIRES))
            {
                clsCtpartypeaffaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeaffaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeaffaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeaffaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPEAFFAIRES";
                clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
                return clsCtpartypeaffaires;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeaffaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeaffaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeaffaire.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
            //    return clsCtpartypeaffaires;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeaffaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeaffaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeaffaire.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
            //    return clsCtpartypeaffaires;

            //}


            else
            {
                clsCtpartypeaffaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeaffaire.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypeaffaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypeaffaire.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
                return clsCtpartypeaffaires;

            }


        }


    }
}