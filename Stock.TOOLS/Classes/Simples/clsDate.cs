using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Stock.TOOLS
{
    public class clsDate
    {
        #region  Declaration unique de la classe
        //declaration unique de la classe clsDeclaration pour tout le projet
        private readonly static clsDate ClassesDate = new clsDate();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsDate()
        {
        }
        //constructeur public de la classe fonction 

        public static clsDate ClasseDate
        {
            get { return ClassesDate; }
        }

        #endregion

        public bool pvgTestSiDate(string vppValeurSaisie)
        {
            try
            {
                //Lui dire que le format de date est français (JJ/MM/AAAA)

               // IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

               //DateTime dtTest = System.Convert.ToDateTime(vppValeurSaisie, culture);
                DateTime dt = DateTime.ParseExact(vppValeurSaisie, "dd/MM/yyyy", null);
               return true;
            }
            catch
            {
                return false;
                //XtraMessageBox.Show("Cette date n'est pas valide !");
            }
        }


        public string pvgRecuperationDate(DateTime vppDate)
        {
            if (vppDate.ToShortDateString() !="01/01/1900")
            {
                return vppDate.ToShortDateString();
            }
            else
            {
                return "";
            }
        }

        public bool pvgTestComparaisonDeuxDates(DateTime vppDate1, DateTime vppDate2)
        {
            if (vppDate2 > vppDate1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool pvgTestComparaisonDeuxDatesOuEgalite(DateTime vppDate1, DateTime vppDate2)
        {
            if (vppDate2 >= vppDate1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool pvgTestSiDateEstDansExerciceEnCours(DateTime vppDate)
        {
            if (vppDate.Year.ToString() == Stock.TOOLS.clsDeclaration.vagExerciceEnCours.EX_EXERCICE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool pvgTestSiDateEstDansExerciceEnCours(DateTime vppDate,string vppExercice)
        {
            if (vppDate.Year.ToString() == vppExercice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime pvgDateAdd(DateTime vppDate, double vppDuree, string vppDureeType)
        {
            if (vppDureeType == "J") return DateAndTime.DateAdd("D", vppDuree - 1, vppDate);
            if (vppDureeType == "M") return DateAndTime.DateAdd("M", vppDuree , vppDate);
            return DateTime.Parse("01/01/1900");
        }
    }
}
