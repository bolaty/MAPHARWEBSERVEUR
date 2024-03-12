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
public class cpsDevTextBoxDV : DevExpress.XtraEditors.TextEdit
{
    private bool _FocusAutomatique = true;

    public bool FocusAutomatique
    {
        get { return _FocusAutomatique; }
        set { _FocusAutomatique = value; }
    }

	public cpsDevTextBoxDV()
	{
        this._FocusAutomatique = true;
        this.Properties.MaxLength = 21;
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        this.Properties.Mask.EditMask = "n";
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
        //this.Text = double.Parse(Text) < 0 ? "0" : Text;
        if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique == true)
        {
            SendKeys.Send("{TAB}");
        }
         if (!this.Properties.ReadOnly && Enabled)
             this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
         Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
    }

    //protected override void OnLostFocus(EventArgs e)
    //{
    //    //base.OnLostFocus(e);
    //    try
    //    {
    //        //Text = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier( Math.Abs(double.Parse(Text)).ToString(),"M");
    //        Text = Math.Abs(double.Parse(Text)).ToString();
    //    }
    //    catch { };
    //    // FAIT LE FORMATAGE EN MILLIERS SI LA LONGUEUR DE CARACTERES SAISIE DEPASSE 3
    //}

    protected override void OnLeave(EventArgs e)
    {
        base.OnLeave(e);
        try
        {
            this.Text = double.Parse(Text.Replace(".", ",")).ToString();
        }
        catch { };

    }



    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);
    }


}
}
