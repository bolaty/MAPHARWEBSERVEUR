using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Stock.WSTOOLS
{
    public class clsDate
    {

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

        public bool pvgTestSiDate1(string vppValeurSaisie)
        {
            try
            {
                //Lui dire que le format de date est français (JJ/MM/AAAA)

                // IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

                //DateTime dtTest = System.Convert.ToDateTime(vppValeurSaisie, culture);
                DateTime dt = DateTime.ParseExact(vppValeurSaisie, "dd-MM-yyyy", null);
                return true;
            }
            catch
            {
                return false;
                //XtraMessageBox.Show("Cette date n'est pas valide !");
            }
        }



        public DateTime pvgDateAdd(DateTime vppDate, double vppDuree, string vppDureeType)
        {
            
            if (vppDureeType == "J") return DateAndTime.DateAdd("D", vppDuree - 1, vppDate);
            if (vppDureeType == "M") return DateAndTime.DateAdd("M", vppDuree - 1, vppDate);
            return DateTime.Parse("01/01/1900");
        }
    }
}
