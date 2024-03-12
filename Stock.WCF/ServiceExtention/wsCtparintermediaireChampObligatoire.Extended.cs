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
	public partial class wsCtparintermediaire
	{

        public List<HT_Stock.BOJ.clsCtparintermediaire> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparintermediaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparintermediaire> clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
            HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();

            if (string.IsNullOrEmpty(Objet.IT_CODEINTERMEDIAIRE))
            {
                clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PY_CODEPAYS";
                clsCtparintermediaires.Add(clsCtparintermediaire);
                return clsCtparintermediaires;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparintermediaires.Add(clsCtparintermediaire);
            //    return clsCtparintermediaires;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparintermediaires.Add(clsCtparintermediaire);
            //    return clsCtparintermediaires;

            //}


            else
            {
                clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = "";
                clsCtparintermediaires.Add(clsCtparintermediaire);
                return clsCtparintermediaires;

            }


        }


    }
}