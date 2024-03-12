using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Stock.TOOLS
{
    /// <summary>
    /// Cette classe represente un textbox generique de saisie numérique de valeur en pourcentages
    /// avec taille maximal=5 et avec virgule et deux chiffres après
    /// la virgule et qui respect l'alignement droite
    /// et gère aussi les focus sous forme de tabulation,
    /// la valeur par defaut(ou d'initialisation) de l'objet est =0
    /// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
    /// parce que sa saisie est obligatoire
    /// </summary>
    [ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
    public class cpsDevTextBoxP : DevExpress.XtraEditors.TextEdit
    {
        private bool _FocusAutomatique = true;

        public bool FocusAutomatique
        {
            get { return _FocusAutomatique; }
            set { _FocusAutomatique = value; }
        }

        public cpsDevTextBoxP()
        {
            this._FocusAutomatique = true;
            this.Properties.MaxLength = 5;
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Properties.Mask.EditMask = "P";
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Tag = "ON";
            this.Text = "0";
        }

        //* Désactiver les 6 lignes suivantes pour permettre le copier / coller */
        //private const int WM_PASTE = 0x0302;
        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    if ( m.Msg != WM_PASTE )
        //        base.WndProc( ref m );
        //}

        #region propriétés

        #endregion


        #region évènements

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
            base.OnKeyPress(e);
            EditValue.ToString().Replace(".", ",");
            if (e.KeyChar == 13 && _FocusAutomatique == true)
            {
                SendKeys.Send("{TAB}");
            }

            if (!this.Properties.ReadOnly && Enabled)
                this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
            Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Text = Text.Replace(".", ",").Replace("-", "0");
        }


        protected override void OnValidating(CancelEventArgs e)
        {           
            //if (float.Parse(EditValue.ToString().Replace(".", ",")) > 100)
            //{
            //    XtraMessageBox.Show("Taux incorrect!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //    e.Cancel = true;
            //}
        }


        private void InitializeComponent()
        {

            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}