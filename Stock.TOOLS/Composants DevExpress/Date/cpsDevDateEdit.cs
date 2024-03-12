using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un text box generique qui respect l'alignement gauche
/// et les caractères majuscules et gère aussi les focus sous forme de tabulation
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
    [ToolboxBitmap(typeof(DevExpress.XtraEditors.DateEdit))]
    public class cpsDevDateEdit : DevExpress.XtraEditors.DateEdit
    {
	public cpsDevDateEdit()
	{
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        this.Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/[123][0-9][0-9][0-9]";
        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        this.CausesValidation = false;
        this.Tag = "OC";
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        
        base.OnKeyPress(e);
         //Si la touche Entrez doit jouer le rôle de tabulation, ajoutez le code suivant
        if (e.KeyChar == 13 && e.Handled == false)
        {
            SendKeys.Send("{TAB}");
        }
        if (!this.Properties.ReadOnly && Enabled)
            this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
        Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;

    }
    /// <summary>
    /// Cette fonction ppermet de definir si la date saisie est valide
    /// </summary>
    /// <returns>booleen</returns>
    public bool pvgDatevalide()
    {

        if (Text == "") return true;
        try
        {
            //Cette condition est mise pour eviter l'enregistrement des dates dans sql server
            if (DateTime.Parse(Text).Year < 1900)
            {
                XtraMessageBox.Show(this, "Date invalide!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorText = "Erreur";
                SelectAll();
                Focus();
                return false;
            }
            ErrorText = "";
            return true;
        }
        catch
        {
            XtraMessageBox.Show(this, "Date invalide!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorText = "Erreur";
            SelectAll();
            Focus();

            return false;
        }

    }

    /// <summary>
    /// cette fonction permet de verifier si la date saisie est superieure ou egale a la date seuil definie en parametre
    /// </summary>
    /// <param name="vppDateSeuil">date seuil</param>
    /// <returns></returns>
    public bool pvgDateSeuilSuperieur(DateTime vppDateSeuil)
    {
        if (!pvgDatevalide()) return false;
        if (Text == "") return true;
        if (DateTime.Parse(Text) > vppDateSeuil)
        {
            XtraMessageBox.Show(this, "Cette date est invalide! Elle ne doit pas être au delà du " + vppDateSeuil.ToShortDateString() +"." , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorText = "Erreur";
            return false;
        }
        ErrorText = "";
        return true;

    }
    /// <summary>
    /// cette fonction permet de verifier si la date saisie est inferieure ou egale a la date seuil definie en parametre
    /// </summary>
    /// <param name="vppDateSeuil">date seuil</param>
    /// <returns></returns>
    public bool pvgDateSeuilInferieur(DateTime vppDateSeuil)
    {

        if (!pvgDatevalide()) return false;
        if (Text == "")
        {
            ErrorText = "";
            return true;
        }
        if (DateTime.Parse(Text).Date < vppDateSeuil.Date)
        {
            XtraMessageBox.Show(this, "Cette date est invalide! Elle doit être en delà du " + vppDateSeuil.ToShortDateString() + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorText = "Erreur";
            return false;
        }
        ErrorText = "";
        return true;

    }
    public bool pvgAppartientAExerciceEnCours(DateTime vppDebutExercice, DateTime vppFinExercice)
    {

        if (!pvgDatevalide()) return false;
        if (Text == "")
        {
            ErrorText = "";
            return true;
        }
        if (DateTime.Parse(Text).Date < vppDebutExercice.Date || DateTime.Parse(Text).Date > vppFinExercice.Date)
        {
            XtraMessageBox.Show(this, "la date doit etre comprise entre le " + vppDebutExercice.ToShortDateString() + " et le " + vppFinExercice.ToShortDateString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorText = "Date Hors Exercice";
            return false;
        }
        ErrorText = "";
        return true;

    }



    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);
    }
}
}
