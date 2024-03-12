using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un textbox generique de saisie numérique avec taille maximal=18 et sans virgule
/// et formaté en millier qui respect l'alignement droite
/// et gère aussi les focus sous forme de tabulation,
/// la valeur par defaut(ou d'initialisation) de l'objet est =0
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
[ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
public class cpsDevTextBoxM : DevExpress.XtraEditors.TextEdit
{
    private bool _FocusAutomatique = true;

    public bool FocusAutomatique
    {
        get { return _FocusAutomatique; }
        set { _FocusAutomatique = value; }
    }
    public cpsDevTextBoxM()
    {
        this._FocusAutomatique = true;
        this.Properties.MaxLength = 18;
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        this.Properties.Mask.EditMask = "d";
        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        this.CausesValidation = false;
        this.Tag = "ON";
        this.Text = "0";
    }

    //* Désactiver les 6 lignes suivantes pour permettre le copier / coller */
    //private const int WM_PASTE = 0x0302;
    //protected override void WndProc(ref System.Windows.Forms.Message m)
    //{
    //    if (m.Msg != WM_PASTE)
    //        base.WndProc(ref m);
    //}

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);

        // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        if (e.KeyChar == 13 && _FocusAutomatique == true)
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
