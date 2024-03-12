using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace Stock.TOOLS
{
    public class clsControl
    {

        #region  Declaration unique de la classe

        //declaration unique de la classe clsDeclaration pour tout le projet
        private readonly static clsControl ClassesControl = new clsControl();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsControl()
        {
        }
        //constructeur public de la classe fonction 

        public static clsControl ClasseControl
        {
            get { return ClassesControl; }
        }

        #endregion


        /// <summary>
        /// cette fonction est permet de verifier les champs obligatoires sur l'écran
        /// </summary>
        /// <param name="vppChaine">Cette chaine contient les nom des differents chaps obligatoires </param>
        /// <param name="vppControl"> ce sont les controles a verifier. il est préférable de mettre les conteneurs(groupbox, panel ...). 
        /// mais on peut toutefois mettre des controles simples(textbox, combo ...)
        /// il serait souhaitable d'envoyer les conteneurs les plus proches des champs (exemple: les groupesbox)
        /// </param>
        public void  pvgVerifierChampObligatoire(string vppChaine,  params Control[] vppControl)
        {
            //cette premiere boucle permet de parcourir les conteneurs qui lui ont été affectés
            
            for (int i = 0; i < vppControl.Length; i++)
            {
                //verifie si le conteneur contient des controles conteneur
                //si oui on applique la recursivité
                if (vppControl[i].Controls.Count > 1)
                {
                    //on verifie chaque controle du conteneur
                    for (int j = 0; j < vppControl[i].Controls.Count ; j++)
                    {
                        pvgVerifierChampObligatoire(vppChaine, vppControl[i].Controls[j]);                       
                    }
                }
                else
                {
                    vppControl[i].Tag = vppChaine.Contains(vppControl[i].Name) ? "OC" : "";
                }              
            }
        }


        public bool pvgControleAvantEnregistrement(bool vppInitialiseSaisie, params Control[] vppConteneurEncours)
        {
            for (int idx = 0; idx < vppConteneurEncours.Length; idx++)
                foreach (Control vppObjetControl in vppConteneurEncours[idx].Controls)
                {
                    if (vppObjetControl.GetType() == typeof(cpsDevGroup) || vppObjetControl.GetType() == typeof(cpsDevPanel) || vppObjetControl.GetType() == typeof(cpsDevGroup) ||
                         vppObjetControl.GetType() == typeof(cpsDevTabControl) || vppObjetControl.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                    {
                        foreach (Control vppObjetControl1 in vppObjetControl.Controls)
                        {
                            if (!vppInitialiseSaisie)
                            {
                                if (pvpControleAvantEnregistrement3(vppObjetControl1) == false)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                clsInitialisation.ClasseInitialisation.pvgInitialiseSaisie(vppObjetControl1);
                            }
                        }
                    }
                    else
                    {
                        if (!vppInitialiseSaisie)
                        {
                            if (pvpControleAvantEnregistrement3(vppObjetControl) == false)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            clsInitialisation.ClasseInitialisation.pvgInitialiseSaisie(vppObjetControl);
                        }
                    }
                }
            return true;
        }

        //Permet de verouiller une zone de saisie en numerique sans virgule, c-a-d uniquement 
        //les nombre entier
        public bool pvgControleAvantEnregistrement(cpsDevForm vppFeuilleEncours, bool vppInitialiseSaisie)
        {
            foreach (Control vppObjetControl in vppFeuilleEncours.Controls)
            {
                if (vppObjetControl.GetType() == typeof(cpsDevGroup) || vppObjetControl.GetType() == typeof(cpsDevPanel) )
                {
                    foreach (Control vppObjetControl1 in vppObjetControl.Controls)
                    {
                        if (!vppInitialiseSaisie)
                        {
                            if (pvpControleAvantEnregistrement2(vppObjetControl1) == false)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            clsInitialisation.ClasseInitialisation.pvgInitialiseSaisie(vppObjetControl1);
                        }
                    }
                }
                else
                {
                    if (!vppInitialiseSaisie)
                    {
                        if (pvpControleAvantEnregistrement2(vppObjetControl) == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        clsInitialisation.ClasseInitialisation.pvgInitialiseSaisie(vppObjetControl);
                    }
                }
            }
            return true;
        }

        private bool pvpControleAvantEnregistrement2(Object vppObjetEncours)
        {

            //TEXTBOX
            string V = vppObjetEncours.GetType().Name;

            if (vppObjetEncours.GetType() == typeof(cpsDevTextBoxT) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxTE) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxTEL)||
                vppObjetEncours.GetType() == typeof(cpsDevTextBoxTM) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxM) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxD) ||
                vppObjetEncours.GetType() == typeof(cpsDevTextBoxDA) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxDV) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxP)||
                vppObjetEncours.GetType() == typeof(cpsDevTextBoxP3))
            {
                switch (vppObjetEncours.GetType().Name)
                {
                    case "cpsDevTextBoxT":
                    case "cpsDevTextBoxTE":
                    case "cpsDevTextBoxTEL":
                    case "cpsDevTextBoxTM":
                    case "cpsDevTextBoxM":
                        DevExpress.XtraEditors.TextEdit vppNouvelleInstanceObjet;
                        vppNouvelleInstanceObjet = (DevExpress.XtraEditors.TextEdit)vppObjetEncours;

                        if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                        {
                            vppNouvelleInstanceObjet.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                            if (vppNouvelleInstanceObjet.Text.Trim() == string.Empty)
                            {
                                XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                                vppNouvelleInstanceObjet.BackColor = clsDeclaration.VertClair2;
                                vppNouvelleInstanceObjet.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;
                }

            }
            if (vppObjetEncours.GetType() == typeof(cpsDevTextBoxT) || vppObjetEncours.GetType() == typeof(cpsDevTextBoxDA))
            {
            }

            if (vppObjetEncours.GetType() == typeof(cpsDevComboBox))
            {
                DevExpress.XtraEditors.ComboBoxEdit vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (DevExpress.XtraEditors.ComboBoxEdit)vppObjetEncours;

                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                    if (vppNouvelleInstanceObjet.Text.Trim() == string.Empty)
                    {
                        XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.VertClair2;
                        vppNouvelleInstanceObjet.Focus();
                        return false;
                    }
                }
            }
            //COMBOXBOX

            if (vppObjetEncours.GetType() == typeof(System.Windows.Forms.ComboBox))
            {
                System.Windows.Forms.ComboBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (System.Windows.Forms.ComboBox)vppObjetEncours;

                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                    if (vppNouvelleInstanceObjet.Text == string.Empty || vppNouvelleInstanceObjet.Text == "0")
                    {
                        XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.VertClair2;
                        vppNouvelleInstanceObjet.Focus();
                        return false;
                    }
                }
            }
            //COMBOXBOXDEVEXPRESS
            if (vppObjetEncours.GetType() == typeof(cpsDevComboBox))
            {
                cpsDevComboBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (cpsDevComboBox)vppObjetEncours;

                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                    if (vppNouvelleInstanceObjet.Text == string.Empty || vppNouvelleInstanceObjet.Text == "0")
                    {
                        XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.VertClair2;
                        vppNouvelleInstanceObjet.Focus();
                        return false;
                    }
                }
            }
            //COMBOXBOXDEVEXPRESSLOOKUPEDIT
            if (vppObjetEncours.GetType() == typeof(cpsDevLookUpEdit))
            {
                cpsDevLookUpEdit vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (cpsDevLookUpEdit)vppObjetEncours;

                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                    if (vppNouvelleInstanceObjet.Text == string.Empty || vppNouvelleInstanceObjet.Text == "0")
                    {
                        XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.VertClair2;
                        vppNouvelleInstanceObjet.Focus();
                        return false;
                    }
                }
            }
            //MASKBOX
            if (vppObjetEncours.GetType() == typeof(MaskedTextBox) )
            {
                MaskedTextBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (MaskedTextBox)vppObjetEncours;
                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                    if (vppNouvelleInstanceObjet.Text == "  /  /" || vppNouvelleInstanceObjet.Text == "  -  -  -  /  -  -  -  /  -  -  -" || vppNouvelleInstanceObjet.Text == "  :")
                    {
                        XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.VertClair2;
                        vppNouvelleInstanceObjet.Focus();
                        return false;
                    }
                }
            }
            return true;
        }


        private bool pvpControleAvantEnregistrement3(Control vppControlEnCours)
        {
            if (vppControlEnCours.Tag == "ON" || vppControlEnCours.Tag == "OC")
            {
                vppControlEnCours.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                if (vppControlEnCours.Text.Trim() == string.Empty || vppControlEnCours.Text == "0")
                {
                    string fffo = vppControlEnCours.Name;
                    XtraMessageBox.Show("Il existe des zones de saisie obligatoire non renseignées!!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);//, Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);                
                    vppControlEnCours.BackColor = Color.LimeGreen;  //clsDeclaration.VertClair2;
                    vppControlEnCours.Focus();
                    return false;
                }
            }
            return true;
        }

        private void pvgInitialiseSaisie(Object vppObjetEncours)
        {
            //TEXTBOX
            if (vppObjetEncours.GetType() == typeof(TextBox))
            {
                TextBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (TextBox)vppObjetEncours;

                //if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC" || vppNouvelleInstanceObjet.Tag == "")
                //{
                vppNouvelleInstanceObjet.Text = "";
                if (vppNouvelleInstanceObjet.Tag == "ON")
                {
                    vppNouvelleInstanceObjet.Text = "0";
                }
            }
            //COMBOXBOX
            //if (vppObjetEncours.GetType() == typeof(DevExpress.XtraEditors.ComboBox))
            //{
            //    DevExpress.XtraEditors.ComboBox vppNouvelleInstanceObjet;
            //    vppNouvelleInstanceObjet = (DevExpress.XtraEditors.ComboBox)vppObjetEncours;
            //    vppNouvelleInstanceObjet.Text = "";
            //}
            //MASKBOX
            if (vppObjetEncours.GetType() == typeof(MaskedTextBox))
            {
                MaskedTextBox vppNouvelleInstanceObjet;
                vppNouvelleInstanceObjet = (MaskedTextBox)vppObjetEncours;

                if (vppNouvelleInstanceObjet.Tag == "ON" || vppNouvelleInstanceObjet.Tag == "OC")
                {
                    vppNouvelleInstanceObjet.Mask = "##/##/####";
                    //if (vppNouvelleInstanceObjet.Text == "  /  /")
                    //{

                    //}
                }
            }
        }




       




    }
}
