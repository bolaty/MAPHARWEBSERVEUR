using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock.TOOLS
{
    /// <summary>
    /// Cette classe represente un textbox generique multiline qui respect l'alignement gauche
    /// et les caractères majuscules et gère aussi les focus sous forme de tabulation
    /// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
    /// parce que sa saisie est obligatoire
    /// </summary>
    [ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))] // Pour avoir un bel icone de Textbox dans la toolbox
    public class cpsDevTextBoxTM : DevExpress.XtraEditors.TextEdit
    {
        private bool _FocusAutomatique = true;

        public bool FocusAutomatique
        {
            get { return _FocusAutomatique; }
            set { _FocusAutomatique = value; }
        }

        public cpsDevTextBoxTM()
        {
            //this.Multiline = true;
            this._FocusAutomatique = true;
            this.Tag = "OC";
            this.Properties.MaxLength = 80;
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.Properties.CharacterCasing = CharacterCasing.Upper;
            this.CausesValidation = false;
            this.TabStop = false;
            this.Tag = "OC";
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
             //Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
            if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique == true)
            {
                SendKeys.Send("{TAB}");
            }

            //char c = e.KeyChar;
            //if (!(char.IsNumber(c) || char.IsControl(c) || c.ToString() == ",")) { e.Handled = true; }

            this.BackColor = clsDeclaration.Blanc;
            Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        }




        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
