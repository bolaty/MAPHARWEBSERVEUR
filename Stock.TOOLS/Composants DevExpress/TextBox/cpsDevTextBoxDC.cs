using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un textbox generique de saisie numérique des numéros de client 
/// avec taille maximal=8 et formaté sur 8 positions
/// et gère aussi les focus sous forme de tabulation,
/// la valeur par defaut(ou d'initialisation) de l'objet est =""
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
[ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
public class cpsDevTextBoxDC : DevExpress.XtraEditors.TextEdit
{
    private bool _FocusAutomatique = true;

    public bool FocusAutomatique
    {
        get { return _FocusAutomatique; }
        set { _FocusAutomatique = value; }
    }

	public cpsDevTextBoxDC()
	{
        this._FocusAutomatique = true ;
        this.Properties.MaxLength = 8;
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        this.Properties.Mask.EditMask = "\\d{0,8}";
        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        this.CausesValidation = false;
        this.Tag = "ON";
        this.Text = "0";
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        //this.Text = double.Parse(Text) < 0 ? "0" : Text;
        if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique==true)
        {
            SendKeys.Send("{TAB}");
        }
         if (!this.Properties.ReadOnly && Enabled)
             this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
         Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        try
        {
              Text = string.Format("{0:00000000}", double.Parse(Text));
        }
        catch { };
        // FAIT LE FORMATAGE SUR HUIT POSITIONS
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);
    }
}
}
