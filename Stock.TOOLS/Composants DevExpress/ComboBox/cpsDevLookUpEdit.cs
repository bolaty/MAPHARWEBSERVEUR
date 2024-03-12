using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;

namespace Stock.TOOLS
{
    public class cpsDevLookUpEdit : DevExpress.XtraEditors.LookUpEdit
    {

        public cpsDevLookUpEdit()
        {
            Tag = "OC";
            Tag = "OC";
            Properties.NullText = "";
            Properties.NullValuePrompt = "";
            Properties.ShowHeader = false;
            Properties.ShowFooter = false;
            Properties.ShowLines = false;
            Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Flat;
            Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
            Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
        }

        private DataTable _datasource;
        private string _Code = "";
        private string _Libelle = "";
        private bool _PremiereLigneVide = true;


        public string ValueMember
        {
            get { return Properties.ValueMember; }
            set { Properties.ValueMember= value;  }
            
        }

        public string DisplayMember
        {
            get { return Properties.DisplayMember; }
            set { Properties.DisplayMember = value; }
        }

        public DataTable DataSource
        {
            set
            {
                Properties.DataSource = value;
            }
        }
        /// <summary>
        /// Obtenir la valeur sélectionnée
        /// </summary>
        /// <returns>String</returns>
        public string GetValue() 
        {
            if (EditValue == null) return "";
            return EditValue.ToString();
        }

        public string GetValue(string vppChamp)
        {
            if(ItemIndex<0) return "";
            return this.Properties.GetDataSourceValue(vppChamp,ItemIndex).ToString();
        }

        /// <summary>
        /// Définir la valeur selectionnée
        /// </summary>
        /// <param name="vppCritere">valeur (value member)</param>
        public void SetValue(string vppChamp,object vppCritere)
        {
            this.ItemIndex = this.Properties.GetDataSourceRowIndex(vppChamp, vppCritere);
        }

        ///<summary>
        ///Définir la valeur selectionnée a partir du debut
        ///</summary>
        ///<param name="vppCritere">valeur (value member)</param>
        public void SetValueByFirst(string vppChamp, object vppCritere)
        {
            SetValue(vppChamp, vppCritere);
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
            ToolTip = Text;// SendKeys.Send("{TAB}");
        }

        private void InitializeComponent()
        {
        }

        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, string vppValeur, string vppTextAffiche, params bool[] vppPremiereLigneVide)
        {
            if (vppDataset.Tables.Count == 0) return;
            pvgLoadValueMemberDisplayMemberColonneMultiple(vppDataset.Tables[0], vppValeur, vppTextAffiche, vppPremiereLigneVide);
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset)
        {
            this.pvgLoadValueMemberDisplayMember(vppDataset, true);
        }
        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, bool vppPremiereLigneVide, params string[] vppChampsVisibles)
        {
            try
            {
                if (vppDataset.Tables.Count == 0) return;
                if (vppPremiereLigneVide && vppDataset.Tables[0].Rows.Count>0) vppDataset.Tables[0].Rows.InsertAt(vppDataset.Tables[0].NewRow(), 0);
                if (vppDataset.Tables[0].Columns.Count == 0) return;
                // defini le chap valeur et le champ a afficher
                if (vppDataset.Tables[0].Columns.Count > 1)
                {
                    //lorsque le datasource contient plusieurs colonnes.
                    ValueMember = vppDataset.Tables[0].Columns[0].Caption;
                    DisplayMember = vppDataset.Tables[0].Columns[1].Caption;
                }
                else
                {
                    //lorsque le datasource contient une seule colonne.
                    ValueMember = DisplayMember = vppDataset.Tables[0].Columns[0].Caption;
                }
                //affectation du datasource
                DataSource = vppDataset.Tables[0];
                //ajout des colonnes du combo
                Properties.Columns.Clear();
                foreach (DataColumn colonne in vppDataset.Tables[0].Columns)
                {
                    Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(colonne.ColumnName));
                    //permet de rendre visible les colonnes specifiées et les autres invisibles
                    if (vppChampsVisibles.Length > 0)
                    {
                        Properties.Columns[colonne.ColumnName].Visible = vppChampsVisibles.ToList().Contains(colonne.ColumnName);
                    }
                }

                Refresh();
                //permet de ne pas afficher la colonne du code síl y a une seule colonne dans le datatable
                if (ValueMember != DisplayMember)
                    Properties.Columns[ValueMember].Visible = false;
                //evite la saisie dans le composant 
                this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            catch
            {
                throw;
            }
        }
        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, bool vppPremiereLigneVide, int vppLignePardefaut)
        {
            this.pvgLoadValueMemberDisplayMember(vppDataset, vppPremiereLigneVide);
            //if (vppLignePardefaut < this.Properties.Items.Count)
            //    this.SelectedIndex = ( vppLignePardefaut>=-1 && vppLignePardefaut < this.Properties.Items.Count)? vppLignePardefaut:-1;
        }
        private void pvgLoadValueMemberDisplayMemberColonneMultiple(DataTable vppDataTable, string vppValeur, string vppTextAffiche, params bool[] vppPremiereLigneVide)
        {
            if (vppPremiereLigneVide.Length > 0)
                this._PremiereLigneVide = vppPremiereLigneVide[0];
            try
            {
                this.Text = "";
                DataSource = vppDataTable;
                foreach (DataColumn colonne in vppDataTable.Columns)
                {
                    Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(colonne.ColumnName));
                }

                Properties.ValueMember = vppValeur;
                if (!string.IsNullOrEmpty(vppTextAffiche))
                {
                    Properties.DisplayMember = vppTextAffiche;
                }
                else
                {
                    Properties.DisplayMember = vppValeur;
                }
                Refresh();
                if (vppTextAffiche != vppValeur)
                {
                    int I= Properties.Columns.Count;
                    Properties.Columns[vppValeur].Visible = false;
                }
                //Properties.
            }
            catch
            {
                throw;
            }
        }
        public void pvgChargerOuiNon()
        {
            //this.Properties.Items.Clear(); this.Properties.Items.Add("OUI"); this.Properties.Items.Add("NON");
            //this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }
        public void pvgChargerNonOui()
        {
            //this.Properties.Items.Clear(); this.Properties.Items.Add("NON"); this.Properties.Items.Add("OUI");
            //this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }
        public void pvgChargerDebitCredit()
        {
            //this.Properties.Items.Clear(); this.Properties.Items.Add("DÉBIT"); this.Properties.Items.Add("CRÉDIT");
            //this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }
        public void pvgChargerValeur(params string[] vppValeur)
        {
            //this.Properties.Items.Clear();
            //for (int Idx = 0; Idx < vppValeur.Length; Idx++)
            //    this.Properties.Items.Add(vppValeur[Idx]);
            //this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }
      
        /// <summary>
        /// cette procedure permet de charger un combo avec un tableau de valeurs séparées. 
        /// </summary>
        /// <param name="vppCodeLibelle"> valeurs a charger dans le combo de la forme code1#libelle1,code2#libelle2 ,...... </param>
        public void pvgChargerCodeLibelle(params string[] vppCodeLibelle)
        {
            DataSet vlpDataset = new DataSet();
            vlpDataset.Tables.Add();
            vlpDataset.Tables[0].Columns.Add("CODE");
            vlpDataset.Tables[0].Columns.Add("LIBELLE");
            for (int Idx = 0; Idx < vppCodeLibelle.Length; Idx++)
            {
                string[] vppValeur = vppCodeLibelle[Idx].Split('#');
                if (vppValeur.Length == 1)
                {
                    vlpDataset.Tables[0].Rows.Add(vppValeur[0]);
                    vlpDataset.Tables[0].Rows.Add(vppValeur[0]);
                    continue;
                }
                if (vppValeur.Length == 2)
                {
                    vlpDataset.Tables[0].Rows.Add(vppValeur[0]);
                    vlpDataset.Tables[0].Rows.Add(vppValeur[1]);
                }
            }
            this.pvgLoadValueMemberDisplayMember(vlpDataset, false);
        }

        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, string vppValeur, string vppTextAffiche, bool vppPremiereLigneVide)
        {
            if (vppDataset.Tables.Count == 0) return;
            pvgLoadValueMemberDisplayMemberColonneMultiple(vppDataset.Tables[0], vppValeur, vppTextAffiche, vppPremiereLigneVide);
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void pvgLoadValueMemberDisplayMemberColonneMultiple(DataTable vppDataTable, string vppValeur, string vppTextAffiche, bool vppPremiereLigneVide)
        {

            if (vppPremiereLigneVide && vppDataTable.Rows.Count > 0) vppDataTable.Rows.InsertAt(vppDataTable.NewRow(), 0);
            if (vppDataTable.Columns.Count == 0) return;

            try
            {
                this.Text = "";
                DataSource = vppDataTable;
                Properties.Columns.Clear();
                foreach (DataColumn datacolonne in vppDataTable.Columns)
                {
                    DevExpress.XtraEditors.Controls.LookUpColumnInfo colonne = new DevExpress.XtraEditors.Controls.LookUpColumnInfo(datacolonne.ColumnName);
                    colonne.Visible = datacolonne.ColumnName == vppTextAffiche ? true : false;
                    Properties.Columns.Add(colonne);
                }

                Properties.ValueMember = vppValeur;
                if (!string.IsNullOrEmpty(vppTextAffiche))
                {
                    Properties.DisplayMember = vppTextAffiche;
                }
                else
                {
                    Properties.DisplayMember = vppValeur;
                }
                Refresh();
                if (vppTextAffiche != vppValeur)
                {
                    int I = Properties.Columns.Count;
                    Properties.Columns[vppValeur].Visible = false;
                }
                //Properties.
            }
            catch
            {
                throw;
            }
        }
        
    }
}
