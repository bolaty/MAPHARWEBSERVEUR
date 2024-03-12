using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un text box generique qui respect l'alignement gauche
/// et les caractères majuscules et gère aussi les focus sous forme de tabulation
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
    [ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
    public class cpsDevTextBoxT : DevExpress.XtraEditors.TextEdit
    {
        private bool _FocusAutomatique = true;

        public bool FocusAutomatique
        {
            get { return _FocusAutomatique; }
            set { _FocusAutomatique = value; }
        }

	    public cpsDevTextBoxT()
	    {
            this._FocusAutomatique = true;
            this.Properties.MaxLength = 150;
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.Properties.CharacterCasing = CharacterCasing.Upper;
            this.CausesValidation = false;
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
            if (!this.Properties.ReadOnly && Enabled)
                this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
            Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

    }
}
