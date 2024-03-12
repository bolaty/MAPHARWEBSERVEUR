using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un textbox generique de saisie numérique avec taille maximal=20 et avec virgule et deux chiffres après
/// la virgule et formaté en millier qui respect l'alignement droite
/// et gère aussi les focus sous forme de tabulation,
/// la valeur par defaut(ou d'initialisation) de l'objet est =0
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
[ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
    public class cpsDevTextBoxTEL : DevExpress.XtraEditors.TextEdit
{
    private bool _FocusAutomatique = true;

    public bool FocusAutomatique
    {
        get { return _FocusAutomatique; }
        set { _FocusAutomatique = value; }
    }

	public cpsDevTextBoxTEL()
	{
        this._FocusAutomatique = true;
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        this.Properties.Mask.EditMask = "\\d\\d-\\d\\d-\\d\\d-\\d\\d(/\\d\\d-\\d\\d-\\d\\d-\\d\\d)?(/\\d\\d-\\d\\d-\\d\\d-\\d\\d)?";
        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        this.CausesValidation = false;
        this.Tag = "OC";
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique == true)
        {
        //this.Text = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(this.Text, "P");
            SendKeys.Send("{TAB}");
        } 
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
