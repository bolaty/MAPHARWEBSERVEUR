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
    public partial class wsEditionEtatBudgetTypeDonnee
    {

        public List<Stock.BOJ.clsEditionEtatBudget> TestTypeDonnee(Stock.BOJ.clsEditionEtatBudget Objet)

        {


            List<Stock.BOJ.clsEditionEtatBudget> clsEditionEtatBudgets = new List<Stock.BOJ.clsEditionEtatBudget>();
            Stock.BOJ.clsEditionEtatBudget clsEditionEtatBudget = new Stock.BOJ.clsEditionEtatBudget();
            
                clsEditionEtatBudget.SL_CODEMESSAGE = "";
                clsEditionEtatBudget.SL_RESULTAT = "TRUE";
                clsEditionEtatBudget.SL_MESSAGE = "";
                clsEditionEtatBudgets.Add(clsEditionEtatBudget);
                return clsEditionEtatBudgets;


        } 


       

    }
}
