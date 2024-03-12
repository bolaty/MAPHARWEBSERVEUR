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
public class cpsDevTextBoxD : DevExpress.XtraEditors.TextEdit
{
    private bool _FocusAutomatique = true;

    public bool FocusAutomatique
    {
        get { return _FocusAutomatique; }
        set { _FocusAutomatique = value; }
    }

    string _Text = "0";
    public string Text
    {
        get { return _Text; }
        set 
        {
            try
            {
                base.Text = _Text = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Math.Abs(double.Parse(value)).ToString(), "M");
            }
            catch
            { }
        }
    }
	public cpsDevTextBoxD()
	{
        this._FocusAutomatique = true;
        this.Properties.MaxLength = 18;
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        this.Properties.Mask.EditMask = "n0"; //FormatString = "{0:N0}";
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
            try
            {
                if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique == true)
                {
                SendKeys.Send("{TAB}");
                }
                if (!this.Properties.ReadOnly && Enabled)
                    this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
                Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
            }
            catch(Exception ex)
            {

            }
        
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        try
        {
            this.Text = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(Math.Abs(double.Parse(base.Text)).ToString(), "M");
        }
        catch { };
        // FAIT LE FORMATAGE EN MILLIERS SI LA LONGUEUR DE CARACTERES SAISIE DEPASSE 3
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        try
        {
            if(Text == "")Text = "0";
        }
        catch { };
        // FAIT LE FORMATAGE EN MILLIERS SI LA LONGUEUR DE CARACTERES SAISIE DEPASSE 3
    }



    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);
    }


}
}
