using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stock.TOOLS
{
    public class clsInitialisation
    {
        #region  declaration unique de la classe
        //declaration unique de la classe clsInitialisation pour tout le projet
        private readonly static clsInitialisation ClassesInitialisation = new clsInitialisation();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsInitialisation()
        {
        }
        //constructeur public de la classe fonction 
        public static clsInitialisation ClasseInitialisation
        {
            get { return ClassesInitialisation; }
        }
        #endregion



        public void pvgInitialiseSaisie(Object vppObjetEncours)
        {
            //TEXTBOX
            if (vppObjetEncours.GetType() == typeof(TextBox))
            {
                TextBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (TextBox)vppObjetEncours;
                vppNouvelleInstanceObjet.Text = "";
                if (vppNouvelleInstanceObjet.Tag == "ON")
                {
                    vppNouvelleInstanceObjet.Text = "0";
                }
            }
            //COMBOXBOX
            if (vppObjetEncours.GetType() == typeof(ComboBox))
            {
                ComboBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (ComboBox)vppObjetEncours;
                vppNouvelleInstanceObjet.Text = "";
            }
            //MASKBOX
            if (vppObjetEncours.GetType() == typeof(MaskedTextBox))
            {
                MaskedTextBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (MaskedTextBox)vppObjetEncours;

                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.Mask = "##/##/####";
                }
            }
        }


    }
}
