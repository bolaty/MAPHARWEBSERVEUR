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
    [ToolboxBitmap(typeof(DevExpress.XtraTab.XtraTabControl))]
    public class cpsDevTabControl : DevExpress.XtraTab.XtraTabControl
    {
        public cpsDevTabControl()
	{

    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        // Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        if ( e.KeyChar == 13)
        {
            SendKeys.Send("{TAB}");
        } 
        //this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
        Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
    }


    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);
    }
}
}
