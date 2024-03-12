using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Stock.TOOLS
{
    public class clsDesign
    {
        #region  Declaration unique de la classe

        //declaration unique de la classe clsDeclaration pour tout le projet
        private readonly static clsDesign ClassesDesign = new clsDesign();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsDesign()
        {
        }
        //constructeur public de la classe fonction 

        public static clsDesign ClasseDesign
        {
            get { return ClassesDesign; }
        }

        #endregion

        public void pvgActivationFeuille(Form vppFeuilleEncours, int vppLargeur, int vppHauteur)
        {
            vppFeuilleEncours.Height = vppHauteur;
            vppFeuilleEncours.Width = vppLargeur;
            //vppFeuilleEncours.Icon = Properties.Resources.icone;

          //vppFeuilleEncours.Icon  = new Icon("D:\\PROJETS\\PROJET STOCK\\Stock en cours\\HT_STOCK\\Stock.GUI\\Resources\\HT_Gestion.ico");
        }
        public void pvgActivationFeuille(Form vppFeuilleEncours, int vppLargeur, int vppHauteur,string vppDesactivationDesObjets)
        {
            pvgActivationFeuille(vppFeuilleEncours, vppLargeur, vppHauteur);

            foreach (Control vppObjetControl in vppFeuilleEncours.Controls)
            {
                if (vppObjetControl.GetType() == typeof(cpsDevGroup) || vppObjetControl.GetType() == typeof(PictureBox) || vppObjetControl.GetType() == typeof(TabControl) || vppObjetControl.GetType() == typeof(Panel))
                {
                    foreach (Control vppObjetControl1 in vppObjetControl.Controls)
                    {
                        pvgActivation(vppObjetControl1, false);
                    }
                }
                else
                {
                    pvgActivation(vppObjetControl, false);
                }
            }
        }

        public void pvgActivationFeuille(Form vppFeuilleEncours, int vppLargeur, int vppHauteur,bool vppActivation)
        {
            vppFeuilleEncours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(221)))), ((int)(((byte)(245)))));
            vppFeuilleEncours.Height = vppHauteur;
            vppFeuilleEncours.Width = vppLargeur;
            foreach (Control vppObjetControl in vppFeuilleEncours.Controls)
            {
                pvgActivation(vppObjetControl, vppActivation);
            }
        }

        public void pvgActivation(bool vppEtat, params Control[] vppControls)
        {
            for (int vlpLigne = 0; vlpLigne < vppControls.Length; vlpLigne++)
            {
                pvgActivation(vppControls[vlpLigne], vppEtat);
            }
        }

        public void pvgActivation(Control vppObjetEncours, bool vppActivation)
        {
            if (vppObjetEncours.GetType() == typeof(cpsDevGroup) || vppObjetEncours.GetType() == typeof(PictureBox)
            || vppObjetEncours.GetType() == typeof(TabControl) || vppObjetEncours.GetType() == typeof(Panel))
            {
                foreach (Control vppObjetEncours1 in vppObjetEncours.Controls)
                {
                    pvgActivation(vppObjetEncours1, vppActivation);
                }
            }
            else
            {
                // INITIALISATION DES PROPRIETES DU LABEL           
                if (vppObjetEncours is Label)
                {
                    Label vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (Label)vppObjetEncours;

                    vppNouvelleInstanceObjet.AutoSize = true;
                    vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.Transparent;
                    vppNouvelleInstanceObjet.ForeColor = clsDeclaration.Noir;

                    if (vppNouvelleInstanceObjet.Text.StartsWith("*"))
                    {
                        vppNouvelleInstanceObjet.Text = vppNouvelleInstanceObjet.Text + " *";
                    }

                    if (vppNouvelleInstanceObjet.Name != "LabelSigne")
                    {
                        if (vppNouvelleInstanceObjet.Name != "NomRaisonSocial")
                        {
                            vppNouvelleInstanceObjet.Height = 225;
                        }
                        if (vppNouvelleInstanceObjet.Name == "labelTitre")
                        {
                            vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                            vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                        else if (vppNouvelleInstanceObjet.Name == "labelAffiche")
                        {
                            vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            vppNouvelleInstanceObjet.AutoSize = false;
                            vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                            vppNouvelleInstanceObjet.Height = 20;
                        }

                        else { vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); }

                    }
                    vppObjetEncours = vppNouvelleInstanceObjet;
                }
                else if (vppObjetEncours is cpsDevTextBoxT || vppObjetEncours is Stock.TOOLS.cpsDevTextBoxM)
                {
                    cpsDevTextBoxT vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxT)vppObjetEncours;

                    if (vppNouvelleInstanceObjet.Name != "txtEditN")
                    {
                        vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                        //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                        vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                        if (vppActivation == false)
                        {
                            vppNouvelleInstanceObjet.TabStop = false;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                            vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                        }
                        else if (vppActivation == true)
                        {
                            vppNouvelleInstanceObjet.TabStop = true;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                else if (vppObjetEncours is Stock.TOOLS.cpsDevTextBoxD)
                {
                    cpsDevTextBoxD vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxD)vppObjetEncours;

                    //if (vppNouvelleInstanceObjet.Name != "txtEditN")
                    //{
                        //vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                        //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                        vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                        if (vppActivation == false)
                        {
                            vppNouvelleInstanceObjet.TabStop = false;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                            vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                        }
                        else if (vppActivation == true)
                        {
                            vppNouvelleInstanceObjet.TabStop = true;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    //}
                }
                else if (vppObjetEncours is Stock.TOOLS.cpsDevTextBoxDC)
                {
                    cpsDevTextBoxDC vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxDC)vppObjetEncours;

                    if (vppNouvelleInstanceObjet.Name != "txtEditN")
                    {
                        //vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                        //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                        vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                        if (vppActivation == false)
                        {
                            vppNouvelleInstanceObjet.TabStop = false;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                            vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                        }
                        else if (vppActivation == true)
                        {
                            vppNouvelleInstanceObjet.TabStop = true;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                else if (vppObjetEncours is Stock.TOOLS.cpsDevTextBoxP)
                {
                    cpsDevTextBoxP vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxP)vppObjetEncours;

                    if (vppNouvelleInstanceObjet.Name != "txtEditN")
                    {
                        vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                        //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                        vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                        if (vppActivation == false)
                        {
                            vppNouvelleInstanceObjet.TabStop = false;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                            vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                        }
                        else if (vppActivation == true)
                        {
                            vppNouvelleInstanceObjet.TabStop = true;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                else if (vppObjetEncours is Stock.TOOLS.cpsDevTextBoxD)
                {
                    cpsDevTextBoxD vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxD)vppObjetEncours;

                    if (vppNouvelleInstanceObjet.Name != "txtEditN")
                    {
                        vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                        //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                        vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                        if (vppActivation == false)
                        {
                            vppNouvelleInstanceObjet.TabStop = false;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                            vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                        }
                        else if (vppActivation == true)
                        {
                            vppNouvelleInstanceObjet.TabStop = true;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                else if (vppObjetEncours is Stock.TOOLS.cpsDevTextBoxDA)
                {
                    cpsDevTextBoxDA vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxDA)vppObjetEncours;

                    if (vppNouvelleInstanceObjet.Name != "txtEditN")
                    {
                        vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                        //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                        vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                        if (vppActivation == false)
                        {
                            vppNouvelleInstanceObjet.TabStop = false;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                            vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                        }
                        else if (vppActivation == true)
                        {
                            vppNouvelleInstanceObjet.TabStop = true;
                            vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    }
                }


                // INITIALISATION DES PROPRIETES DU COMBOBOX
                else if (vppObjetEncours is cpsDevComboBox)
                {
                    cpsDevComboBox vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevComboBox)vppObjetEncours;

                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.TabStop = false;
                        vppNouvelleInstanceObjet.Enabled = vppActivation;
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        vppNouvelleInstanceObjet.TabStop = true;
                        vppNouvelleInstanceObjet.Enabled = vppActivation;
                        vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                    }
                }
                // INITIALISATION DES PROPRIETES DU cpsDevLookUpEdit
                else if (vppObjetEncours is cpsDevLookUpEdit)
                {
                    cpsDevLookUpEdit vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevLookUpEdit)vppObjetEncours;

                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.TabStop = false;
                        vppNouvelleInstanceObjet.Enabled = vppActivation;
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        vppNouvelleInstanceObjet.TabStop = true;
                        vppNouvelleInstanceObjet.Enabled = vppActivation;
                        vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                    }
                }        
                // INITIALISATION DES PROPRIETES DU MASKEDTEXTBOX
                else if (vppObjetEncours is MaskedTextBox)
                {
                    MaskedTextBox vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (MaskedTextBox)vppObjetEncours;

                    vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    vppNouvelleInstanceObjet.ForeColor = vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Blue;
                    vppNouvelleInstanceObjet.Height = 300;
                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.Enabled = false;
                        vppNouvelleInstanceObjet.TabStop = false;
                        vppNouvelleInstanceObjet.Tag = "LOCKED";
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        vppNouvelleInstanceObjet.Enabled = true;
                        vppNouvelleInstanceObjet.TabStop = true;
                        vppNouvelleInstanceObjet.Tag = "OPEN";
                        vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                    }
                }
                // INITIALISATION DES PROPRIETES DU cpsDevTextBoxTEL
                else if (vppObjetEncours is cpsDevTextBoxTEL)
                {
                    cpsDevTextBoxTEL vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevTextBoxTEL)vppObjetEncours;

                    vppNouvelleInstanceObjet.Properties.CharacterCasing = CharacterCasing.Upper;
                    //vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Black;
                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //if (!vppNouvelleInstanceObjet.Properties.Multiline) { vppNouvelleInstanceObjet.Height = 275; }
                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.TabStop = false;
                        vppNouvelleInstanceObjet.Properties.ReadOnly = true;
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        vppNouvelleInstanceObjet.TabStop = true;
                        vppNouvelleInstanceObjet.Properties.ReadOnly = false;
                        vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                    }
                }

                // INITIALISATION DES PROPRIETES DU cpsDevMemoEdit
                else if (vppObjetEncours is cpsDevMemoEdit)
                {
                    cpsDevMemoEdit vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (cpsDevMemoEdit)vppObjetEncours;

                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.TabStop = false;
                        vppNouvelleInstanceObjet.Enabled = vppActivation;
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        vppNouvelleInstanceObjet.TabStop = true;
                        vppNouvelleInstanceObjet.Enabled = vppActivation;
                        vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                    }
                } 
                // INITIALISATION DES PROPRIETES DU COMMAND BUTTON
                else if (vppObjetEncours is Button)
                {
                    Button vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (Button)vppObjetEncours;
                    vppNouvelleInstanceObjet.Enabled = vppActivation;
                }

                // INITIALISATION DES PROPRIETES DU COMMAND PICTUREBOX
                else if (vppObjetEncours is PictureBox)
                {
                    PictureBox vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (PictureBox)vppObjetEncours;
                    vppNouvelleInstanceObjet.Enabled = vppActivation;
                    vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        if (vppNouvelleInstanceObjet.Name != "pictureTitre")
                        {
                            vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                // INITIALISATION DES PROPRIETES DU  LISTBOX
                else if (vppObjetEncours is ListBox)
                {
                    ListBox vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (ListBox)vppObjetEncours;
                    vppNouvelleInstanceObjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Blue;
                    vppNouvelleInstanceObjet.Enabled = vppActivation;

                    if (vppActivation == false)
                    {
                        vppNouvelleInstanceObjet.BackColor = clsDeclaration.vagCouleurDésactivation;
                    }
                    else if (vppActivation == true)
                    {
                        vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.White;
                    }
                }
                //INITIALISATION DES PROPRIETES DU RADIO BUTTON
                else if (vppObjetEncours is RadioButton)
                {
                    RadioButton vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (RadioButton)vppObjetEncours;
                    vppNouvelleInstanceObjet.Enabled = vppActivation;
                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Blue;
                    vppNouvelleInstanceObjet.BackColor = System.Drawing.Color.Transparent;
                    vppNouvelleInstanceObjet.Height = 275;
                }
                //INITIALISATION DES PROPRIETES DE LA GRILLE
                else if (vppObjetEncours is DataGridView)
                {
                    DataGridView vppNouvelleInstanceObjet;
                    vppNouvelleInstanceObjet = (DataGridView)vppObjetEncours;
                    vppNouvelleInstanceObjet.Enabled = vppActivation;
                    vppNouvelleInstanceObjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //vppNouvelleInstanceObjet.ForeColor = System.Drawing.Color.Blue;
                    vppNouvelleInstanceObjet.AllowUserToAddRows = false;
                    vppNouvelleInstanceObjet.AllowUserToOrderColumns = false;
                    vppNouvelleInstanceObjet.AllowUserToResizeColumns = false;
                    vppNouvelleInstanceObjet.AllowUserToResizeRows = false;
                    vppNouvelleInstanceObjet.BackgroundColor = Stock.TOOLS.clsDeclaration.BleuCiel;
                    vppNouvelleInstanceObjet.CausesValidation = false;
                    vppNouvelleInstanceObjet.RowHeadersVisible = false;
                    vppNouvelleInstanceObjet.AlternatingRowsDefaultCellStyle.BackColor = Stock.TOOLS.clsDeclaration.BleuCiel;
                    vppNouvelleInstanceObjet.MultiSelect = false;
                }
            }
        }

        public void pvgActivationDesactivationComboZoneAgence(cpsDevComboBox vppDevComboBoxZone, cpsDevCheckedComboBoxEdit vppDevCheckedComboBoxEditAgence, object vppTable1, object vppTable2)
        {
            //Transformation des objet en dataset pour appeller la procedure :pvgLoadValueMemberDisplayMember
            if (vppTable1.GetType() != typeof(DataSet)) return;
            DataSet vppDataSet1;
            vppDataSet1 = (DataSet)vppTable1;
            //
            if (vppTable2.GetType() != typeof(DataSet)) return;
            DataSet vppDataSet2;
            vppDataSet2 = (DataSet)vppTable2;
            //Chargements des deux combox
            vppDevComboBoxZone.pvgLoadValueMemberDisplayMember(vppDataSet1, true);
            vppDevCheckedComboBoxEditAgence.pvgLoadValueMemberDisplayMember(vppDataSet2, true);
            //vppDevCheckedComboBoxEditAgence.Properties.GETD
            //vppDevCheckedComboBoxEditAgence.EditValue=Stock.TOOLS.clsDeclaration.vagAgence.AG_RAISONSOCIAL;
            vppDevCheckedComboBoxEditAgence.EditValue=Stock.TOOLS.clsDeclaration.vagAgence.AG_CODEAGENCE;


            //Si c'est une agence tout simplement
            if (Stock.TOOLS.clsDeclaration.vagAgence.AG_REFERENCE == "N")
            {
                vppDevComboBoxZone.Properties.ReadOnly = true;
                vppDevCheckedComboBoxEditAgence.Properties.ReadOnly = true;
            }
            //s'il s'agit d'une coordination
            else if (Stock.TOOLS.clsDeclaration.vagAgence.AG_REFERENCE == "Z")
            {
                ////Si c'est un opérateur de coordination
                //if (Stock.TOOLS.clsDeclaration.vagOperateurEnCours.OP_AGENTCREDIT == "O")
                //{
                //    vppDevComboBoxZone.SetValue(Stock.TOOLS.clsDeclaration.vagAgence.ZN_CODEZONE);
                //    vppDevComboBoxZone.Properties.ReadOnly = true;
                //    vppDevCheckedComboBoxEditAgence.Properties.ReadOnly = false;
                //}
                //else
                //{
                    vppDevComboBoxZone.Properties.ReadOnly = true;
                    vppDevCheckedComboBoxEditAgence.Properties.ReadOnly = true;
                //}
            }
            //Si c'est la direction générale
            else
            {
                vppDevComboBoxZone.Properties.ReadOnly = false;
                vppDevCheckedComboBoxEditAgence.Properties.ReadOnly = false;
            }
        }


        public bool pvgChargementFeuille(Form vppFeuille, Form vppFeuillePrincipale,
                                        bool vppModeAppel, bool vppMdiParent, 
                                        bool vppTestJourneeComptable,bool vppTestDateSystemeAvantAffichage)
        {


            //////////////////////////////////////////////////////////////////////////////////////////
            //List<string[]> maList = new List<string[]>();
            ////Récupération des adresses MAC de l'ordinateurd en cours
            //maList = Stock.TOOLS.clsReseaux.ClasseReseaux.GetMACAddress();

            ////Test de la licence de l'ordinateur
            //if (!(Stock.TOOLS.clsLicenceUtilisation.ClassecLicenceUtilisation.pvgControlAdressesMACs(maList)))
            //{
            //    XtraMessageBox.Show("Licence d'utilisation requise !!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

            //    //Appel de l'écran de licence
            //    FrmGestionLicence FrmGestionLicence = new FrmGestionLicence();
            //    FrmGestionLicence.maList = maList;

            //    FrmGestionLicence.Show();
            //    //clsDesign.ClasseDesign.pvgChargementFeuille(FrmGestionLicence.Instance, this, true, true, true, true);

            //    return false;
            //}

            Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;

            //Si la feuille est déjà lancée et qu'il se trouve dans la mdi, il  doit être en avant.
            if (vppFeuille.Name != "FrmJourneeTravail")
            foreach (Form vppForm in Application.OpenForms)
            {
                if (vppForm.Name == vppFeuille.Name)
                {
                    Application.OpenForms[vppForm.Name].Activate();
                    Application.OpenForms[vppForm.Name].WindowState = FormWindowState.Normal;
                    //Application.OpenForms[vppForm.Name].StartPosition = FormStartPosition.CenterScreen;
                    return true;
                }
            }


            try
            {
                //vppFeuille.Visible = true;
                if (vppMdiParent) vppFeuille.MdiParent = vppFeuillePrincipale;
                vppFeuille.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                if (vppModeAppel)
                    vppFeuille.ShowDialog(vppFeuillePrincipale);
                else
                    vppFeuille.Show();

                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}



