using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using HT_Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
    public partial class wsEditionEtatBudget
    {

      
        public List<Stock.BOJ.clsEditionEtatBudget> TestChampObligatoireListe(Stock.BOJ.clsEditionEtatBudget Objet)
        {


            clsObjetRetour clsObjetRetour = new clsObjetRetour();



            List<Stock.BOJ.clsEditionEtatBudget> clsEditionEtatBudgets = new List<Stock.BOJ.clsEditionEtatBudget>();
            Stock.BOJ.clsEditionEtatBudget clsEditionEtatBudget = new Stock.BOJ.clsEditionEtatBudget();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
                clsMessages.MS_CODEMESSAGE = "GNE0280";
                //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
                clsEditionEtatBudget.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatBudget.SL_RESULTAT = "FALSE";
                clsEditionEtatBudget.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                return clsEditionEtatBudgets;

            }


            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
                clsMessages.MS_CODEMESSAGE = "GNE0280";
                //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
                clsEditionEtatBudget.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatBudget.SL_RESULTAT = "FALSE";
                clsEditionEtatBudget.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                return clsEditionEtatBudgets;

            }

            if (string.IsNullOrEmpty(Objet.TYPEETAT))
            {

                //----EXEPTION
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
                clsMessages.MS_CODEMESSAGE = "GNE0001";
                //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
                clsEditionEtatBudget.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatBudget.SL_RESULTAT = "FALSE";
                clsEditionEtatBudget.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                return clsEditionEtatBudgets;

            }
           

            else
            {

                clsEditionEtatBudget.SL_CODEMESSAGE = "";
                clsEditionEtatBudget.SL_RESULTAT = "TRUE";
                clsEditionEtatBudget.SL_MESSAGE = "";
                clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                return clsEditionEtatBudgets;

            }


        }

    }
}
