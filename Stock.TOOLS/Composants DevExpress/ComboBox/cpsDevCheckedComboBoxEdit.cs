using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;

namespace Stock.TOOLS
{
    public class cpsDevCheckedComboBoxEdit : DevExpress.XtraEditors.CheckedComboBoxEdit
    {

        public cpsDevCheckedComboBoxEdit()
        {
            Tag = "OC";
            
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                SendKeys.Send("{TAB}");
            }
            this.BackColor = clsDeclaration.Blanc;
            Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        }

        protected override void OnPopupClosed(DevExpress.XtraEditors.PopupCloseMode e)
        {
            ToolTip = Text; //SendKeys.Send("{TAB}");
        }

        private void InitializeComponent()
        {
        }

        /// <summary>
        /// Permet de charger le combo avec une source de données 
        /// </summary>
        /// <param name="vppDataTable">source de données </param>
        /// <param name="vppValeur">Valeur</param>
        /// <param name="vppTexte">Texte affiché</param>
        /// <param name="vppAfficherPremiereLigneVide">Permet d'afficher une premiere ligne vide</param>
        public void pvgLoadValueMemberDisplayMember(DataTable vppDataTable, string vppValeur, string vppTexte, bool vppAfficherPremiereLigneVide)
        {
            //if (vppAfficherPremiereLigneVide && vppDataTable.Rows.Count>0)
            //    vppDataTable.Rows.InsertAt(vppDataTable.NewRow(), 0);
            this.Properties.DataSource = vppDataTable;
            this.Properties.ValueMember = vppValeur;
            this.Properties.DisplayMember = vppTexte;
            this.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
        }

        public void pvgLoadValueMemberDisplayMember(DataSet vppDataSet, string vppValeur, string vppTexte, bool vppAfficherPremiereLigneVide)
        {
            if (vppDataSet.Tables.Count == 0) return;
            pvgLoadValueMemberDisplayMember(vppDataSet.Tables[0], vppValeur, vppTexte, vppAfficherPremiereLigneVide);       
        }

        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, bool vppPremiereLigneVide)
        {
            try
            {
                if (vppDataset.Tables.Count == 0) return;
                string vppValeur = "";
                string vppTextAffiche = "";
                if (vppDataset.Tables[0].Columns.Count > 0) vppValeur = vppDataset.Tables[0].Columns[0].Caption;
                if (vppDataset.Tables[0].Columns.Count > 1)
                    vppTextAffiche = vppDataset.Tables[0].Columns[1].Caption;
                else
                    vppTextAffiche = vppDataset.Tables[0].Columns[0].Caption;
                pvgLoadValueMemberDisplayMember(vppDataset.Tables[0], vppValeur, vppTextAffiche, vppPremiereLigneVide);
                this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            catch
            {
            }
        }


        public string pvgRecupererEltComboBoxEditSelectionnes(cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEdit)
        {
            string Agence = "";

            string[] vppAgenceSelectionnees = cpsDevCheckedComboBoxEdit.Properties.GetCheckedItems().ToString().Split(',');

            try
            {
                for (int idx = 0; idx <= vppAgenceSelectionnees.Length - 1; idx++)
                {
                    if (idx == 0 && vppAgenceSelectionnees[0] != "")
                        Agence = "''" + cpsDevCheckedComboBoxEdit.Properties.GetItems().GetCheckedValues()[0].ToString() + "''";
                    if (idx > 0)
                        Agence = Agence + "," + "''" + cpsDevCheckedComboBoxEdit.Properties.GetItems().GetCheckedValues()[idx].ToString() + "''";
                }
            }
            catch
            {

            }
            return Agence;
        }

        //Retourne le nombre d'élement coché dans un cpsDevCheckedComboBoxEdit
        public int pvgRecupererNombreEltComboBoxEditSelectionnes(cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEdit)
        {
            string[] vppAgenceSelectionnees = cpsDevCheckedComboBoxEdit.Properties.GetCheckedItems().ToString().Split(',');
            return vppAgenceSelectionnees.Length;
        }


        //Retourne le nombre d'élement coché dans un cpsDevCheckedComboBoxEdit qui a le code concaténé avec le libellé
        public string pvgRecupererEltComboBoxEditSelectionnesConcateneAvecCode(cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEdit, int pvpLongeur)
        {

            string Agence = "";

            string[] vppAgenceSelectionnees = cpsDevCheckedComboBoxEdit.Properties.GetCheckedItems().ToString().Split(',');

            try
            {
                for (int idx = 0; idx <= vppAgenceSelectionnees.Length - 1; idx++)
                {
                    if (idx == 0 && vppAgenceSelectionnees[0] != "")
                        Agence = "''" + cpsDevCheckedComboBoxEdit.Properties.GetItems().GetCheckedValues()[0].ToString().Substring(0, pvpLongeur) + "''";
                    if (idx > 0)
                        Agence = Agence + "," + "''" + cpsDevCheckedComboBoxEdit.Properties.GetItems().GetCheckedValues()[idx].ToString().Substring(0, pvpLongeur) + "''";


                    
                }

            }
            catch
            {

            }

            return Agence;
        }


        //Cette procédure permet de remplir un cpsDevCheckedComboBoxEdit avec le code et le libellé concaténés  
        public string pvgRecupererEltComboBoxEditSelectionnesConcateneAvecCode(cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEdit)
        {

            string Agence = "";

            string[] vppAgenceSelectionnees = cpsDevCheckedComboBoxEdit.Properties.GetCheckedItems().ToString().Split(',');

            try
            {
                for (int idx = 0; idx <= vppAgenceSelectionnees.Length - 1; idx++)
                {
                    if (idx == 0 && vppAgenceSelectionnees[0] != "")


                        Agence = "''" + clsChaineCaractere.ClasseChaineCaractere.pvgExtraireChaine(cpsDevCheckedComboBoxEdit.Properties.GetItems().GetCheckedValues()[0].ToString(), "-", "G") + "''";
                    if (idx > 0)
                        Agence = Agence + "," + "''" + clsChaineCaractere.ClasseChaineCaractere.pvgExtraireChaine(cpsDevCheckedComboBoxEdit.Properties.GetItems().GetCheckedValues()[idx].ToString(), "-", "G") + "''";
                }

            }
            catch
            {

            }

            return Agence;
        }

        //Cette procédure permet de remplir un cpsDevCheckedComboBoxEdit avec le code et le libellé concaténés
        public void pvgChargerValeur(DataSet vppDataset)
        {
            this.Properties.Items.Clear();
            if(vppDataset.Tables.Count>0)
            {
                for (int Idx = 0; Idx < vppDataset.Tables[0].Rows.Count; Idx++)
                    this.Properties.Items.Add(vppDataset.Tables[0].Rows[Idx].ItemArray[0].ToString() + "-" + vppDataset.Tables[0].Rows[Idx].ItemArray[1].ToString());
            }

        }

        //à intégrer dans la tools dans cpsDevCheckedComboBoxEdit

        public void pvgCocherToutDansComboEdit(cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEdit, DataSet vppDataset)
        {
            if (vppDataset.Tables.Count > 0)
            {
                for (int i = 0; i <= vppDataset.Tables[0].Rows.Count - 1; i++)
                {
                    cpsDevCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Checked;
               
                }
            }
            
        }


        public void pvgCocherUnEltDansComboEdit(cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEdit, DataSet vppDataset, string Elt,int longueur)
        {
            for (int i = 0; i < vppDataset.Tables[0].Rows.Count ; i++)
            {

                string valeur = cpsDevCheckedComboBoxEdit.Properties.Items[i].ToString().Substring(0, longueur);

                //if (valeur == Elt)
                //{
                    cpsDevCheckedComboBoxEdit.Properties.Items[i].CheckState = valeur == Elt ? CheckState.Checked : CheckState.Unchecked;
                    //cpsDevCheckedComboBoxEdit.Properties.Items[i].CheckState = CheckState.Checked;
                //}

            }
        }


        //string vlpET_INDEX = "";
        //string vlpET_INDEX1 = "";
        //cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEditARemplir;
        //cpsDevCheckedComboBoxEdit cpsDevCheckedComboBoxEditCritaire;
        //DataSet DataSetCocher;

        public void checkedComboBoxEdit1_Popup(object sender, EventArgs e)
        {
            if (Stock.TOOLS.clsDeclaration.vagParametreGlobal.vlpET_INDEX != Stock.TOOLS.clsDeclaration.vagParametreGlobal.vlpET_INDEX1) return;
            //if (Stock.TOOLS.clsDeclaration.vagOperateur.OP_AGENTDIRECTION == "N") return;

            CheckedPopupContainerForm f = (sender as IPopupControl).PopupWindow as CheckedPopupContainerForm;
            CheckedListBoxControl listBox = f.ActiveControl as CheckedListBoxControl;
            if (listBox != null)
                listBox.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(listBox_ItemCheck);

        }


        bool flag = true;
        void listBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (!flag) return;
            CheckedListBoxControl listBox = sender as CheckedListBoxControl;

            if (Stock.TOOLS.clsDeclaration.vagParametreGlobal.vlpET_INDEX == Stock.TOOLS.clsDeclaration.vagParametreGlobal.vlpET_INDEX1)
            {
                //if (Stock.TOOLS.clsDeclaration.vagOperateur.OP_AGENTDIRECTION != "N")
                //{
                    if (e.Index > 0 && e.State == CheckState.Checked)
                    {
                        flag = false;
                        listBox.UnCheckAll();
                        listBox.Items[e.Index].CheckState = CheckState.Checked;
                        //listBox.Items[2].CheckState = CheckState.Checked;
                        flag = true;
                    }

                    //string valeur = listBox.Items[e.Index].ToString().Substring(0, 3);
                    //string Elt = "001";
                    //if (valeur == Elt)
                    //     listBox.Items[e.Index].CheckState = CheckState.Checked; 





                    //string[] vppAgenceSelectionnees = Stock.TOOLS.clsDeclaration.vagParametreGlobal.cpsDevCheckedComboBoxEditARemplir.Properties.GetCheckedItems().ToString().Split(',');
                    //if (vppAgenceSelectionnees.Length > 1)
                    //    listBox.UnCheckAll();
                    ////cpsDevCheckedComboBoxEdit6.SetEditValue(clsDeclaration.vagOperateur.EN_CODEENTREPOT);
                    //Stock.TOOLS.clsDeclaration.vagParametreGlobal.cpsDevCheckedComboBoxEditARemplir.pvgCocherToutDansComboEdit(Stock.TOOLS.clsDeclaration.vagParametreGlobal.cpsDevCheckedComboBoxEditARemplir, Stock.TOOLS.clsDeclaration.vagParametreGlobal.DataSetCocher);
                    ////Stock.TOOLS.clsDeclaration.vagParametreGlobal.cpsDevCheckedComboBoxEditARemplir.pvgCocherUnEltDansComboEdit(Stock.TOOLS.clsDeclaration.vagParametreGlobal.cpsDevCheckedComboBoxEditARemplir, Stock.TOOLS.clsDeclaration.vagParametreGlobal.DataSetCocher, "001",3);


                //}

            }



            //if (e.Index == 0 && e.State == CheckState.Checked)
            //{
            //    flag = false;
            //    listBox.UnCheckAll();
            //    listBox.Items[e.Index].CheckState = CheckState.Checked;
            //    //listBox.Items[2].CheckState = CheckState.Checked;

            //    flag = true;
            //}
        }
       

    }
}
