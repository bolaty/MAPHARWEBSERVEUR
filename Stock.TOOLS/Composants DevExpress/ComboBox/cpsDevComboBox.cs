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
    public class cpsDevComboBox : DevExpress.XtraEditors.ComboBoxEdit
    {
        private DataTable _datasource;
        private List<object> _DisplayMember = new List<object>();
        private List<object> _ValueMember = new List<object>();
        private string _Code ="";
        private string _Libelle="";
        private bool _PremiereLigneVide = true;


        public string ValueMember
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public string DisplayMember
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }

        public DataTable DataSource
        {
            get
            {
                return _datasource;
            }
            set 
            { 
                _datasource = value ;
                if (ValueMember != "" && DisplayMember != "")
                {
                    pvpChargerItems(ValueMember, DisplayMember);
                }
                else
                {
                    pvpChargerItems();
                }
            }
        }
        /// <summary>
        /// Obtenir la valeur sélectionnée
        /// </summary>
        /// <returns>String</returns>
        public string GetValue() 
        {
            if (SelectedIndex < 0 || _ValueMember.Count <= SelectedIndex) return "";
            return _ValueMember[SelectedIndex].ToString();
        }
        /// <summary>
        /// Définir la valeur selectionnée
        /// </summary>
        /// <param name="vppCritere">valeur (value member)</param>
        public void  SetValue(object vppCritere)
        {
            SelectedIndex = -1;
            for (int Idx = 0; Idx < _ValueMember.Count; Idx++)
            {
                if (_ValueMember[Idx].ToString() == vppCritere.ToString())
                {
                    SelectedIndex = Idx;
                    break;
                }
            }
        }

        /// <summary>
        /// Définir la valeur selectionnée a partir du debut
        /// </summary>
        /// <param name="vppCritere">valeur (value member)</param>
        public void SetValueByFirst(string vppCritere)
        {
            SelectedIndex = -1;
            for (int Idx = 0; Idx < Properties.Items.Count; Idx++)
            {
                if (Properties.Items[Idx].ToString() != "")
                {
                    if (Properties.Items[Idx].ToString().Substring(0, vppCritere.Length) == vppCritere)
                    {
                        SelectedIndex = Idx;
                        break;
                    }
                }
            }
        }

        public cpsDevComboBox()
        {
            //MET LE COMBO EN LECTURE SEULE
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
            ToolTip = Text;// SendKeys.Send("{TAB}");   
        }

        private void InitializeComponent()
        {
        }

        private void pvpChargerItems()
        {
            try
            {
                _DisplayMember.Clear();
                _ValueMember.Clear();
                Properties.Items.Clear();
                if (_datasource != null)
                {
                    if(_PremiereLigneVide && _datasource.Rows.Count>0)
                    {
                        Properties.Items.Add("");
                        _DisplayMember.Add("");
                        _ValueMember.Add("");
                    }

                    foreach (DataRow row in _datasource.Rows)
                    {
                        if (_datasource.Columns.Count > 1)
                        {
                            Properties.Items.Add(row[1]);
                            _DisplayMember.Add(row[1]);
                            _ValueMember.Add(row[0]);
                        }
                        else
                        {
                            Properties.Items.Add(row[0]);
                            _DisplayMember.Add(row[0]);
                            _ValueMember.Add(row[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Composant ComboBoxEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                _PremiereLigneVide =true;
            }


        }
        private void pvpChargerItems(string Code, string Libelle)
        {
            try
            {
                _DisplayMember.Clear();
                _ValueMember.Clear();
                Properties.Items.Clear();
                if (_datasource != null)
                {
                    if(_PremiereLigneVide && _datasource.Rows.Count>0)
                    {
                        Properties.Items.Add("");
                        _DisplayMember.Add("");
                        _ValueMember.Add("");
                    }
                    foreach (DataRow row in _datasource.Rows)
                    {
                        Properties.Items.Add(row[Libelle]);
                        _DisplayMember.Add(row[Libelle]);
                        _ValueMember.Add(row[Code]);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Composant ComboBoxEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                this._PremiereLigneVide = true;
            }

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
        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, bool vppPremiereLigneVide)
        {
            try
            {
                if (vppDataset.Tables.Count == 0) return;
                if (vppDataset.Tables[0].Columns.Count == 0) return;
                string vppValeur = "";
                string vppTextAffiche = "";
                if (vppDataset.Tables[0].Columns.Count > 1)
                {
                    vppValeur = vppDataset.Tables[0].Columns[0].Caption;
                    vppTextAffiche = vppDataset.Tables[0].Columns[1].Caption;
                }
                else
                    vppValeur = vppTextAffiche = vppDataset.Tables[0].Columns[0].Caption;
                pvgLoadValueMemberDisplayMemberColonneMultiple(vppDataset.Tables[0], vppValeur, vppTextAffiche, vppPremiereLigneVide);
                this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            catch
            {
            }
        }

        public void pvgLoadValueMemberDisplayMember(DataSet vppDataset, bool vppPremiereLigneVide, int vppLignePardefaut)
        {
            this.pvgLoadValueMemberDisplayMember(vppDataset, vppPremiereLigneVide);
            if (vppLignePardefaut < this.Properties.Items.Count)
                this.SelectedIndex = (vppLignePardefaut >= -1 && vppLignePardefaut < this.Properties.Items.Count) ? vppLignePardefaut : -1;
        }

        private void pvgLoadValueMemberDisplayMemberColonneMultiple(DataTable vppDataTable, string vppValeur, string vppTextAffiche, params bool[] vppPremiereLigneVide)
        {
            if (vppPremiereLigneVide.Length > 0)
               this._PremiereLigneVide  = vppPremiereLigneVide[0];

            try
            {
                this.Text = "";
                ValueMember = vppValeur;
                if (!string.IsNullOrEmpty(vppTextAffiche))
                {
                    DisplayMember = vppTextAffiche;
                }
                else
                {
                    DisplayMember = vppValeur;
                }
                DataSource = vppDataTable;
                Refresh();
            }
            catch
            {
                throw;
            }
        }

        public void pvgChargerOuiNon()
        {
            this.Properties.Items.Clear(); this.Properties.Items.Add("OUI"); this.Properties.Items.Add("NON");
        }
        public void pvgChargerNonOui()
        {
            this.Properties.Items.Clear(); this.Properties.Items.Add("NON"); this.Properties.Items.Add("OUI");
        }

        public void pvgChargerDebitCredit()
        {
            this.Properties.Items.Clear(); this.Properties.Items.Add("DEBIT"); this.Properties.Items.Add("CREDIT");
        }

        public void pvgChargerValeur(params string[] vppValeur)
        {
            this.Properties.Items.Clear();
            for (int Idx = 0; Idx < vppValeur.Length; Idx++)
                this.Properties.Items.Add(vppValeur[Idx]); 
        }

        /// <summary>
        /// cette methode permet de remplir le combo avec un tableau de chaine de caracteres. 
        /// chaque chaine contient le code et le libellé separés par #. si la chaine ne contient pas de #, 
        /// la meme chaine est à la fois utilisée comme code et libellé 
        /// exemple d'utilisation:cpsDevComboBox10.pvgChargerCodeLibelle("O#OUI", "N#NON");
        /// permet de charger le cpsDevComboBox10 avec le code:O et le Libellé:OUI puis code:N et le Libellé:NON
        /// </summary>
        /// <param name="vppCodeLibelle"></param>
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
                    vlpDataset.Tables[0].Rows.Add(vppValeur[0], vppValeur[0]);
                    continue;
                }
                if (vppValeur.Length == 2)
                {
                    vlpDataset.Tables[0].Rows.Add(vppValeur[0], vppValeur[1]);
                }
            }
            this.pvgLoadValueMemberDisplayMember(vlpDataset, false);
        }

        public void pvgChargerSigne()
        {
            this.Properties.Items.Clear(); this.Properties.Items.Add("+"); this.Properties.Items.Add("-");
        }
        
    }
}
