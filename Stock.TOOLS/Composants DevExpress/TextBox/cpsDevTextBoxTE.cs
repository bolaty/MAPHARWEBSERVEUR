using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un text box generique de saisie des e-mail qui respect l'alignement gauche
/// et les caractères miniscule et gère aussi les focus sous forme de tabulation
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
    [ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
    public class cpsDevTextBoxTE : DevExpress.XtraEditors.TextEdit
    {
        private bool _FocusAutomatique = true;

        public bool FocusAutomatique
        {
            get { return _FocusAutomatique; }
            set { _FocusAutomatique = value; }
        }

    public cpsDevTextBoxTE()
	{
        this._FocusAutomatique = true;
        this.Properties.MaxLength = 80;
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
        this.Properties.CharacterCasing = CharacterCasing.Lower;
        this.CausesValidation = false;
        this.Tag = "";
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique == true)
        {
            if (clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(this.Text))
            {
                ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
                ErrorText = "";
                SendKeys.Send("{TAB}");
            }
            else
            {
                ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
                ErrorText = "Erreur";
            }
            //SendKeys.Send("{TAB}");
        }
        if (!this.Properties.ReadOnly && Enabled)
            this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
        Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
    }

    protected override void OnLostFocus(EventArgs e)
    {
        // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        if (!clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(this.Text))
        {
           ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
           this.ErrorIcon = DefaultErrorIcon;
            ErrorText = "Erreur";
            this.Focus();
        }
        else
        {
                 ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft;
           ErrorText = "";
        }

    }
    //protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
    //{
    //    // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
    //    base.OnValidating(e);
    //    bool vlpOK = clsChaineCaractere.ClasseChaineCaractere.pvgValidationEmail(this.Text);
    //    if (!(vlpOK))
    //    {
    //        this.BackColor = clsDeclaration.VertClair2;
    //        XtraMessageBox.Show("L'e-mail saisi est incorrect!", "",
    //            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //        this.Focus();
    //    }
    //}


    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);
    }
}
}
