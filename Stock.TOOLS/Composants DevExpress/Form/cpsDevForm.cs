using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Drawing;


namespace Stock.TOOLS
{
    public class cpsDevForm :XtraForm 
    {

        private bool _AJOUT = true;
        private bool _APERCU = true;
        private bool _IMPRESSION = true;
        private bool _MODIFICATION = true;
        private bool _SUPPRESSION = true;
        private bool _AUTORISER = true;
        private bool _IMPRIMERTOUT = true;
        private int _CODEOBJET = 2;

        public int CODEOBJET
        {
            get { return _CODEOBJET; }
        }

        public bool AJOUT
        {
            get { return _AJOUT; }
            set { _AJOUT = value; }
        }

        public bool APERCU
        {
            get { return _APERCU; }
            set { _APERCU = value; }
        }

        public bool MODIFICATION
        {
            get { return _MODIFICATION; }
            set { _MODIFICATION = value; }
        }

        public bool SUPPRESSION
        {
            get { return _SUPPRESSION; }
            set { _SUPPRESSION = value; }
        }

        public bool IMPRESSION
        {
            get { return _IMPRESSION; }
            set { _IMPRESSION = value; }
        }

        public bool AUTORISER
        {
            get { return _AUTORISER; }
            set { _AUTORISER = value; }
        }

        public bool IMPRIMERTOUT
        {
            get { return _IMPRIMERTOUT; }
            set { _IMPRIMERTOUT = value; }
        }

        public cpsDevForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new clsXtraGridTraducteur();
            DevExpress.XtraEditors.Controls.Localizer.Active = new clsXtraEditorsTraducteur();
            //this.Icon = new Icon("Resources\\HT_Gestion.ico");



            //System.ComponentModel.ComponentResourceManager resources =
            //new System.ComponentModel.ComponentResourceManager(typeof(cpsDevForm));
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("statusnormal.Icon")));
           
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // cpsDevForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "cpsDevForm";
            this.Load += new System.EventHandler(this.cpsDevForm_Load);
            this.ResumeLayout(false);


          
        }

        public void pvgChargerDroits(object[][] vppDroits)
        { 
            
        }

        public  bool pvgVerifierDroitAjout()
        {
            if (!this.AJOUT) XtraMessageBox.Show(this, "Vous n'avez pas le droit d'ajouter. ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return this.AJOUT;
        }
        public  bool pvgVerifierDroitModification()
        {
            if (!this.MODIFICATION) XtraMessageBox.Show(this, "Vous n'avez pas le droit de modifier. ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return this.MODIFICATION;
        }
        public  bool pvgVerifierDroitSuppression()
        {
            if (!this.SUPPRESSION) XtraMessageBox.Show(this, "Vous n'avez pas le droit de supprimer. ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return this.SUPPRESSION;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        }

        private void cpsDevForm_Load(object sender, EventArgs e)
        {
            
        }

        //protected override void OnMouseEnter(object sender, MouseEventArgs e)
        //{
        //    clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        //}

        //protected override void OnMouseLeave(object sender, FormClosingEventArgs e)
        //{
        //    clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        //}

        //protected override void OnMouseMove(object sender, EventArgs e)
        //{
        //    clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        //}
        //protected override void OnLoad(object sender, EventArgs e)
        //{
        //    clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        //}

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    //base.OnKeyPress(e);
        //    Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
        //}
    }
}
