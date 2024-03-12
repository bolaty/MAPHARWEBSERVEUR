using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stock.TOOLS
{
/// <summary>
/// Cette classe represente un textbox generique de saisie de dates
/// et gère aussi les focus sous forme de tabulation,
/// la valeur par defaut(ou d'initialisation) de l'objet est =0
/// il permet aussi d'activer l'objet textbox en blanc lorsque celui-ci se colorie en vert
/// parce que sa saisie est obligatoire
/// </summary>
[ToolboxBitmap(typeof(DevExpress.XtraEditors.TextEdit))]
public class cpsDevTextBoxDA : DevExpress.XtraEditors.TextEdit
{
    private bool _FocusAutomatique = true;

    public bool FocusAutomatique
    {
        get { return _FocusAutomatique; }
        set { _FocusAutomatique = value; }
    }
    public cpsDevTextBoxDA()
	{
        this._FocusAutomatique = true;
        this.Size = new System.Drawing.Size(75, 20);
        this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        this.Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/[123][0-9][0-9][0-9]";
        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        this.CausesValidation = false;
        this.Tag = "OC";
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
        if (e.KeyChar == 13 && e.Handled == false && _FocusAutomatique == true)
        {
            try
            {
                if (Text != "" && Text != "__/__/____") DateTime.Parse(Text);
                ErrorText = "";
                SendKeys.Send("{TAB}");
           }
            catch {
                ErrorText = "Erreur";
            }
        }  
        if(!this.Properties.ReadOnly && Enabled )
        this.BackColor = Stock.TOOLS.clsDeclaration.Blanc;
        Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
    }

    protected override void OnLeave(EventArgs e)
    {
        
        try
        {
            if (Text != "" && Text != "__/__/____") DateTime.Parse(Text);
            this.ErrorText = "";
        }
        catch
        {
            //XtraMessageBox.Show("error date");
            this.ErrorText = "Erreur";
            this.Focus();
        }

    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ResumeLayout(false);

    }
    /// <summary>
    /// Cette fonction ppermet de definir si la date saisie est valide
    /// </summary>
    /// <returns>booleen</returns>
    public bool pvgDatevalide()
    {
        
        if(Text=="") return true;
        try
        {
            //Cette condition est mise pour eviter l'enregistrement des dates dans sql server
            if (  DateTime.Parse(Text).Year<1900 )
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
        if (!pvgDatevalide()) return false ;
        if (Text == "") return true;
        if (DateTime.Parse(Text)< vppDateSeuil)
        {
            XtraMessageBox.Show(this, "Cette date est invalide!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        if (!pvgDatevalide()) return false ;
        if (Text == "")
        {
            ErrorText = "";
            return true;
        }
        if (DateTime.Parse(Text).Date > vppDateSeuil.Date)
        {
            XtraMessageBox.Show(this, "Cette date est invalide!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorText = "Erreur";
            return false;
        }
        ErrorText = "";
        return true;

    }
    public bool pvgAppartientAExerciceEnCours(DateTime vppDebutExercice,DateTime vppFinExercice)
    {

        if (!pvgDatevalide()) return false;
        if (Text == "")
        {
            ErrorText = "";
            return true;
        }
        if (DateTime.Parse(Text).Date < vppDebutExercice.Date || DateTime.Parse(Text).Date > vppFinExercice.Date)
        {
            XtraMessageBox.Show(this, "la date doit etre comprise entre le " + vppDebutExercice.ToShortDateString() + " et le " + vppFinExercice.ToShortDateString() , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorText = "Date Hors Exercice";           
            return false;
        }
        ErrorText = "";
        return true;

    }

    //Affecte la valeur 01/01/1900 à un champ cpsDevTextBoxDA pour le convertir en date
    public DateTime pvpAffectationDate(cpsDevTextBoxDA cpsDevTextBoxDA)
    {
        DateTime vppDate = DateTime.Parse("01/01/1900");
        try
        {

            if (cpsDevTextBoxDA.Text != "")
            {
                vppDate = DateTime.Parse(cpsDevTextBoxDA.Text);
            }

        }
        catch (Exception EX) { XtraMessageBox.Show(EX.Message); }
        finally { }

        return vppDate;

    }

    ////Test des dates
    //public bool pvgTestDate(DateTime vppDate1, DateTime vppDate2)
    //{
    //    //date1 = DateTime.Parse(cpsDevTextBoxDA1.Text);
    //    //date2 = DateTime.Parse(cpsDevTextBoxDA2.Text);
    //    int vlpResult = DateTime.Compare(vppDate1, vppDate2);
    //    bool vlpResultatTest = false;
    //    if (vlpResult <= 0)
    //    {
    //        vlpResultatTest = true;
    //    }
    //    else if (vlpResult > 0)
    //    {
    //        vlpResultatTest = false;
    //    }
    //    DateTime vlpDate3 = Stock.TOOLS.clsDeclaration.vagJourneetravail.JT_DATESYSTEMSERVEURDEMARRAGE;
    //    if (DateTime.Compare(vppDate2, vlpDate3) <= 0)
    //    {
    //        vlpResultatTest = true;
    //    }
    //    else
    //    {
    //        vlpResultatTest = false;
    //    }
    //    return vlpResultatTest;
    //}


    //public DateTime pvgTestDate(cpsDevTextBoxDA vppDate)
    //{
    //    //
    //    DateTime DateRetournee = DateTime.Parse("01/01/0001");
    //    try
    //    {
    //        if (vppDate.Text != "")
    //        {
    //            DateRetournee = DateTime.Parse(vppDate.Text);
    //        }
    //    }
    //    catch
    //    { }
    //    return DateRetournee;
    //}

    ////Cette procedure permet de tester la hierachie entre deux dates
    //public bool pvgTestHierachieDate(DateTime vppDate1, DateTime vppDate2)
    //{
    //    int vlpResult = DateTime.Compare(vppDate1, vppDate2);
    //    bool vlpResultatTest = false;
    //    if (vlpResult <= 0)
    //    {
    //        vlpResultatTest = true;
    //    }
    //    else if (vlpResult > 0)
    //    {
    //        vlpResultatTest = false;
    //    }
    //    return vlpResultatTest;
    //}
}
}
