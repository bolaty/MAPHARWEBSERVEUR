using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using DevExpress.XtraEditors;



//using MedoLib.WindowsForms;


namespace Stock.TOOLS
{
    public class clsReporting
    {

        #region "Variables Private"
        private static clsReporting s_Instance;
        private static object s_InstanceLocker = new object();
        //ParameterFieldDefinitions vppReports = new ParameterFieldDefinitions();
        ConnectionInfo vppConnectionInfo = new ConnectionInfo();
        //Database crSubDB;
        //Tables crTables;

        // Permet de charger et d'afficher rapidement un état Crystal Reports
        // Fourni un moyen d'initialisation facile des champs de formule de l'état
        //DataSet vapReportingDataSet;
        private string vapFileName;
        // Chemin d'accès au fichier RPT à charger
        private DataSet vapDataSource;
        // Source de données de l'état
        private ReportDocument vapReport;
        // Représente l'état Crystal Reports lui-même
        #endregion

        #region"Création"
        // Constructeur par défaut
        public clsReporting()
        {
            vapReport = new ReportDocument();
        }

        public clsReporting(string vppFichierEtat, DataSet vppSourceDonnees)
        {
            vapReport = new ReportDocument();
        }

        // Singleton
        public static clsReporting Instance
        {
            get
            {
                lock (s_InstanceLocker)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new clsReporting();
                    }
                    return s_Instance;
                }
            }
        }

        #endregion

        #region"Propriétes"

        /// <summary>
        /// Accesseur  pour le chemin d'accès au fichier RPT
        /// </summary>
        public string vagFileName
        {
            get { return vapFileName; }
            set
            {
                vapFileName = value;
                vapReport.Load(value);
            }
        }
        /// <summary>
        /// Accesseur  pour la source de données de l'état
        /// </summary>
        public DataSet vagDataSource
        {
            get { return vapDataSource; }
            set
            {
                vapDataSource = value;
                vapReport.SetDataSource(value);
            }
        }
        /// <summary>
        /// Accesseur  pour l'objet état Crystal Reports
        /// </summary>
        public ReportDocument vagReport
        {
            get { return vapReport; }
        }
        /// <summary>
        /// Accesseur pour le texte des champs de formule de l'état
        /// </summary>
        //public string vagFormulaText(int vppIndex)
        //{
        //    get { return vapReport.DataDefinition.FormulaFields[vppIndex].Text; }
        //    set { vapReport.DataDefinition.FormulaFields[vppIndex].Text = value;}
        //}
        /// <summary>
        ///// Accesseur pour le texte des champs de formule de l'état
        ///// </summary>
        //public Object vagFormulaText(string vppNomFormule)
        //{
        //    get { return vapReport.DataDefinition.FormulaFields[vppNomFormule].Text; }
        //    set { vapReport.DataDefinition.FormulaFields[vppNomFormule].Text = value;}
        //}


        #endregion

        // Affiche un aperçu avant impression de l'état
        private void pvpPrintPreview(Form owner, bool vappModal, string vappSelectionFormula, string vappTitreEtat, int vappZoom, Control vppControlParent)
        {
            pvpPrintPreview(owner, vappModal, vappSelectionFormula, vappTitreEtat, vappZoom, vppControlParent, true);
        }
        private void pvpPrintPreview(Form owner, bool vappModal, string vappSelectionFormula, string vappTitreEtat, int vappZoom, Control vppControlParent, bool vppBottonImprimer)
        {
            CrystalReportViewer vapCRViewer = new CrystalReportViewer();
            {

                // vapCRViewer.DisplayGroupTree = false;
                vapCRViewer.ToolPanelView = ToolPanelViewType.None;
                vapCRViewer.ShowPrintButton = vppBottonImprimer;
                vapCRViewer.Dock = DockStyle.Fill;
                vapCRViewer.ShowRefreshButton = false;
                vapCRViewer.ReportSource = vapReport;
                if (!string.IsNullOrEmpty(vappSelectionFormula)) vapCRViewer.SelectionFormula = vappSelectionFormula;
                //vapCRViewer.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                vapCRViewer.Zoom(vappZoom);
            }
            //if (vppControlParent != null)
            //{
            //    //vppControlParent.Cursor = Cursors.WaitCursor;
            //    //vapCRViewer.ShowGroupTreeButton = false;
            //    //vapCRViewer.ShowTextSearchButton = false;
            //    //vapCRViewer.Zoom(2);
            //    //vppControlParent.Controls.Add(vapCRViewer);
            //    //vppControlParent.Cursor = Cursors.Default;
            //}
            //else
            //{
            vapCRViewer.ShowPrintButton = vppBottonImprimer;
            Form fViewer = new Form();
            {
                //vapReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;



                fViewer.Cursor = Cursors.WaitCursor;
                switch (vapReport.PrintOptions.PaperOrientation)
                {
                    case PaperOrientation.Landscape:
                        fViewer.Size = new System.Drawing.Size(600, 450);
                        break;
                    default:
                        fViewer.Size = new System.Drawing.Size(400, 600);
                        break;
                }

                fViewer.Text = "Aperçu avant impression [ " + vappTitreEtat + " ]";
                if (vppControlParent == null)
                {
                    fViewer.StartPosition = FormStartPosition.CenterParent;
                    fViewer.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    fViewer.StartPosition = FormStartPosition.Manual;
                    fViewer.WindowState = FormWindowState.Normal;
                }

                fViewer.Controls.Add(vapCRViewer);
                if (vappModal)
                {
                    fViewer.ShowDialog(owner);
                    fViewer.Dispose();
                }
                else
                {
                    fViewer.Show(owner);
                }
                fViewer.Cursor = Cursors.Default;
            }
            //}

        }

        // Affiche un aperçu avant impression de l'état
        private void pvpPrintPreview(Form owner, bool vappModal, string vappSelectionFormula, string vappTitreEtat, int vappZoom)
        {
            CrystalReportViewer vapCRViewer = new CrystalReportViewer();
            {

                vapCRViewer.DisplayGroupTree = false;
                vapCRViewer.Dock = DockStyle.Fill;
                vapCRViewer.ShowRefreshButton = true;
                vapCRViewer.ReportSource = vapReport;
                //vapCRViewer.ShowPrintButton = false;
                if (!string.IsNullOrEmpty(vappSelectionFormula)) vapCRViewer.SelectionFormula = vappSelectionFormula;
                vapCRViewer.Zoom(vappZoom);
            }

            Form fViewer = new Form();
            {
                fViewer.Cursor = Cursors.WaitCursor;
                switch (vapReport.PrintOptions.PaperOrientation)
                {
                    case PaperOrientation.Landscape:
                        fViewer.Size = new System.Drawing.Size(600, 450);
                        break;
                    default:
                        fViewer.Size = new System.Drawing.Size(400, 600);
                        break;
                }

                fViewer.Text = "Aperçu avant impression [ " + vappTitreEtat + " ]";
                fViewer.StartPosition = FormStartPosition.CenterParent;
                fViewer.Controls.Add(vapCRViewer);
                fViewer.WindowState = FormWindowState.Maximized;

                if (vappModal)
                {
                    fViewer.ShowDialog(owner);
                    fViewer.Dispose();
                }
                else
                {
                    fViewer.Show(owner);

                }
                fViewer.Cursor = Cursors.Default;
            }

        }

        // Provoque l'impression directe de l'état
        private void Print(PrinterSettings printSettings)
        {
            int copies = 1;
            bool collated = false;
            int startPage = 0;
            int lastPage = 0;

            if ((null != printSettings))
            {
                copies = printSettings.Copies;
                collated = printSettings.Collate;
                startPage = printSettings.FromPage;
                lastPage = printSettings.ToPage;
                vapReport.PrintOptions.PrinterName = printSettings.PrinterName;
            }
            vapReport.PrintToPrinter(copies, collated, startPage, lastPage);
        }

        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, null, null, "", "", false, true, false, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vppFichierEtat, DataSet vppDataSetEtat, string[] vppFichierSousEtat, DataSet[] vppDataSetSousEtat)
        {
            pvpApercuEtat(owner, vppFichierEtat, vppDataSetEtat, vppFichierSousEtat, vppDataSetSousEtat, null, null, "", "", false, true, false, 100);
        }

        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, "", "", false, true, false, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, "", false, true, false, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, false, true, false, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, true, false, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, vppAffichagePortait, false, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, vppAffichagePortait, vappModal, 100, null);
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, vppAffichagePortait, vappModal, vappZoom, null);
        }

        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom, Control vppControlParent)
        {
            pvpApercuEtat(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, vppAffichagePortait, vappModal, vappZoom, null, true);
        }


        public void pvpApercuEtat1(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom)
        {
            pvpApercuEtatAvecImage(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, vppAffichagePortait, vappModal, vappZoom, null, true);
        }

        //public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom, Control vppControlParent,string test)
        //{
        //    pvpApercuEtatAvecImage(owner, vappFichier, vappTable, vappNomFormule, vappValeurFormule, vappSelectionFormula, vappTitreEtat, vappImprimante, vppAffichagePortait, vappModal, vappZoom, null, true);
        //}

        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom, Control vppControlParent, bool vppBoutonImprimer)
        {
            try
            {
                vapReport = new ReportDocument();
                string PATH = Application.StartupPath + "\\ETATS\\" + vappFichier;
                vapReport.Load(PATH);
                vapReport.SetDataSource(vappTable.Tables[0]);
                //vapReport.SetDataSource(vappTable);
                if (vappNomFormule != null && vappValeurFormule != null)
                {
                    if (vappNomFormule.GetLength(0) == vappValeurFormule.GetLength(0))
                    {
                        pvpRenseignerFormule(vappNomFormule, vappValeurFormule);
                    }
                }

                if (vapReport.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Aucun enregistrement trouvé !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                if (!vappImprimante)
                {
                    this.pvpPrintPreview(owner, vappModal, vappSelectionFormula, vappTitreEtat, vappZoom, vppControlParent, vppBoutonImprimer);
                }
                else
                {
                    this.Print(null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cpsErreurs.Enregistrer(ex.Message, true, ex);
            }
        }






        public void pvpApercuEtatAvecImage(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom, Control vppControlParent, bool vppBoutonImprimer)
        {
            try
            {
                vapReport = new ReportDocument();
                string PATH = Application.StartupPath + "\\ETATS\\" + vappFichier;
                vapReport.Load(PATH);
                vapReport.SetDataSource(vappTable.Tables[0]);
                //vapReport.SetDataSource(vappTable);
                if (vappNomFormule != null && vappValeurFormule != null)
                {
                    if (vappNomFormule.GetLength(0) == vappValeurFormule.GetLength(0))
                    {
                        pvpRenseignerFormule(vappNomFormule, vappValeurFormule);
                    }
                }

                if (vappTable.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("Aucun enregistrement trouvé !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                if (!vappImprimante)
                {
                    this.pvpPrintPreview(owner, vappModal, vappSelectionFormula, vappTitreEtat, vappZoom, vppControlParent, vppBoutonImprimer);
                }
                else
                {
                    this.Print(null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cpsErreurs.Enregistrer(ex.Message, true, ex);
            }
        }






        public void pvpApercuEtat(Form owner, string vppFichierEtat, DataSet vppDataSetEtat, string[] vppFichierSousEtat, DataSet[] vppDataSetSousEtat,
                              string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom)
        {
            try
            {
                if (!Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application.StartupPath + "\\Etats\\" + vppFichierEtat))
                {
                    XtraMessageBox.Show("Fichier état inexistant !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }

                //for (int Idx = 0; Idx < vppFichierSousEtat.Length; Idx++)
                //    if (!Microsoft.VisualBasic.FileIO.FileSystem.FileExists(Application.StartupPath + "\\Etats\\" + vppFichierSousEtat[Idx]))
                //    {
                //        XtraMessageBox.Show("Fichier Sous état inexistant !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                //        return;
                //    }

                if (vppDataSetEtat.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("Aucun enregistrement trouvé !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                vapReport = new ReportDocument();
                string PATH = Application.StartupPath + "\\Etats\\" + vppFichierEtat;
                vapReport.Load(PATH);
                vapReport.SetDataSource(vppDataSetEtat.Tables[0]);
                for (int Idx = 0; Idx < vppFichierSousEtat.Length; Idx++)
                    vapReport.Subreports[vppFichierSousEtat[Idx]].SetDataSource(vppDataSetSousEtat[Idx].Tables[0]);
                if (vappNomFormule != null && vappValeurFormule != null)
                {
                    if (vappNomFormule.GetLength(0) == vappValeurFormule.GetLength(0))
                    {
                        pvpRenseignerFormule(vappNomFormule, vappValeurFormule);
                    }
                }
                if (!vappImprimante)
                {
                    this.pvpPrintPreview(owner, vappModal, vappSelectionFormula, vappTitreEtat, vappZoom);
                }
                else
                {
                    this.Print(null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cpsErreurs.Enregistrer(ex.Message, true, ex);
            }
        }
        public void pvpApercuEtat(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, bool vappImprimante)
        {
            try
            {
                if (!System.IO.File.Exists(Application.StartupPath + "\\Etats\\" + vappFichier))
                {
                    XtraMessageBox.Show("Fichier état inexistant !!", "Impression");
                    return;
                }

                if (vappTable.Tables[0].Rows.Count == 0)
                {
                    XtraMessageBox.Show("Aucun élément trouvé !!", "Impression");
                    return;
                }
                vapReport = new ReportDocument();
                string PATH = Application.StartupPath + "\\Etats\\" + vappFichier;
                vapReport.Load(PATH);

                vapReport.SetDataSource(vappTable.Tables[0]);

                if (vappNomFormule != null && vappValeurFormule != null)
                {
                    if (vappNomFormule.GetLength(0) == vappValeurFormule.GetLength(0))
                    {
                        for (int Idx = 0; Idx < vappNomFormule.GetLength(0); Idx++)
                        {
                            string vlpNomFormule = vappNomFormule[Idx].ToString();
                            string vlpValeurFormule = vappValeurFormule[Idx].ToString();
                            vapReport.DataDefinition.FormulaFields[vlpNomFormule].Text = vlpValeurFormule;
                        }
                    }
                }
                if (!vappImprimante)
                {
                    this.pvpPrintPreview(owner, false, "", "", 100);
                }
                else
                {
                    this.Print(null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cpsErreurs.Enregistrer(ex.Message, true, ex);
            }
        }

        private void pvpRenseignerFormule(string[] vappNomFormule, object[] vappValeurFormule)
        {
            for (int Idx = 0; Idx < vappNomFormule.GetLength(0); Idx++)
            {
                string vlpNomFormule = vappNomFormule[Idx].ToString();
                string vlpValeurFormule = vappValeurFormule[Idx].ToString();
                vapReport.DataDefinition.FormulaFields[vlpNomFormule].Text = "'" + vlpValeurFormule.Replace("'", "''") + "'";

            }
        }

        private void pvpMiseADispoFormule(string[] vappNomFormule, object[] vappValeurFormule)
        {
            for (int Idx = 0; Idx < vappNomFormule.GetLength(0); Idx++)
            {
                string vlpNomFormule = vappNomFormule[Idx].ToString();
                string vlpValeurFormule = vappValeurFormule[Idx].ToString();
                vapReport.DataDefinition.FormulaFields[vlpNomFormule].Text = "'" + vlpValeurFormule.Replace("'", "''") + "'";
            }
        }

        public void pvpAfficherEtat(string vppRequete, bool vppOption)
        {
            DataSet vapDataSetImprimer = new DataSet();
            ReportClass monEtat = new ReportClass();
            FrmVisionneuse vopFormVisionneuse = new FrmVisionneuse();

            try
            {
                monEtat.Refresh();
                vopFormVisionneuse.crystalReportViewer1.ReportSource = monEtat;
                vopFormVisionneuse.crystalReportViewer1.DisplayGroupTree = false;
                vopFormVisionneuse.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public void pvpTesterEtat(string vappFichier, DataSet vappTable)
        {
            //try
            //{
            vapReport = new ReportDocument();
            string PATH = Application.StartupPath + "\\ETATS\\" + vappFichier;
            vapReport.Load(PATH);
            vapReport.SetDataSource(vappTable.Tables[0]);

            //if (vapReport.Rows.Count == 0)
            //{
            //    XtraMessageBox.Show("Aucun enregistrement trouvé !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            //    return;
            //}
            //}
            //catch 
            //{
            //    XtraMessageBox.Show("Échec du test de chargement des états", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }






        public void pvpApercuEtatTEST(Form owner, string vappFichier, DataSet vappTable, string[] vappNomFormule, object[] vappValeurFormule, string vappSelectionFormula, string vappTitreEtat, bool vappImprimante, bool vppAffichagePortait, bool vappModal, int vappZoom, Control vppControlParent, bool vppBoutonImprimer)
        {
            try
            {
                vapReport = new ReportDocument();
                string PATH = Application.StartupPath + "\\ETATS\\" + vappFichier;
                vapReport.Load(PATH);
                vapReport.SetDataSource(vappTable.Tables[0]);
                //vapReport.SetDataSource(vappTable);
                if (vappNomFormule != null && vappValeurFormule != null)
                {
                    if (vappNomFormule.GetLength(0) == vappValeurFormule.GetLength(0))
                    {
                        pvpRenseignerFormule(vappNomFormule, vappValeurFormule);
                    }
                }

                if (vapReport.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Aucun enregistrement trouvé !!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                if (!vappImprimante)
                {
                    this.pvpPrintPreview(owner, vappModal, vappSelectionFormula, vappTitreEtat, vappZoom, vppControlParent, vppBoutonImprimer);
                }
                else
                {
                    this.Print(null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //cpsErreurs.Enregistrer(ex.Message, true, ex);
            }
        }



        //private void Form1_Load(object sender, EventArgs e)
        //{

        //    CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //    rd.Load(@"C:\CrystalReport.rpt");
        //    CrystalDecisions.ReportAppServer.ClientDoc.ISCDReportClientDocument rptClientDoc;
        //    rptClientDoc = rd.ReportClientDocument;
        //    System.Drawing.Printing.PrintDocument pDoc = new System.Drawing.Printing.PrintDocument();
        //    CrystalDecisions.ReportAppServer.Controllers.PrintReportOptions rasPROpts = new CrystalDecisions.ReportAppServer.Controllers.PrintReportOptions();
        //    CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions MYPRTOpts = new CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions();

        //    pDoc.PrinterSettings.PrinterName = "Printer Name";
        //    MYPRTOpts.PrinterName = "Printer Name";
        //    // MYPRTOpts.PaperSize = (CrPaperSizeEnum)     pDoc.PrinterSettings.PaperSizes[cboCurrentPaperSizes.SelectedIndex].Kind;
        //    //MYPRTOpts.PaperSource = (CrPaperSourceEnum)     pDoc.PrinterSettings.PaperSources[cboCurrentPaperTrays.SelectedIndex].Kind;
        //    // added the below line to verify the changes work.
        //    MYPRTOpts.PaperOrientation = CrPaperOrientationEnum.crPaperOrientationLandscape;
        //    rptClientDoc.PrintOutputController.ModifyPrintOptions(MYPRTOpts);
        //    MessageBox.Show("Printer set.", "RAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    rptClientDoc.PrintOutputController.PrintReport(rasPROpts);
        //    MessageBox.Show("Printing report.", "RAS", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    crystalReportViewer1.ReportSource = rd;
        //}





        public void Form1_Load(string vappFichier)
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rd.Load(Application.StartupPath + "\\ETATS\\" + vappFichier);
            ReportDocument rptClientDoc=new ReportDocument();
            //rptClientDoc = rd.ReportClientDocument;
            System.Drawing.Printing.PrintDocument pDoc = new System.Drawing.Printing.PrintDocument();

            rptClientDoc.PrintOptions.PaperOrientation = PaperOrientation.Landscape;


            //CrystalDecisions.ReportAppServer.Controllers.PrintReportOptions rasPROpts = new CrystalDecisions.ReportAppServer.Controllers.PrintReportOptions();
            //CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions MYPRTOpts = new CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions();

            pDoc.PrinterSettings.PrinterName = "Printer Name";
            //pDoc.PrinterName = "Printer Name";
            // MYPRTOpts.PaperSize = (CrPaperSizeEnum)     pDoc.PrinterSettings.PaperSizes[cboCurrentPaperSizes.SelectedIndex].Kind;
            //MYPRTOpts.PaperSource = (CrPaperSourceEnum)     pDoc.PrinterSettings.PaperSources[cboCurrentPaperTrays.SelectedIndex].Kind;
            // added the below line to verify the changes work.
            //rptClientDoc.PaperOrientation = PaperOrientation.Landscape;
            //rptClientDoc.ReportClientDocument.ModifyPrintOptions(PaperOrientation.Landscape);
            MessageBox.Show("Printer set.", "RAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //rptClientDoc.PrintOutputController.PrintReport(rasPROpts);
            MessageBox.Show("Printing report.", "RAS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //crystalReportViewer1.ReportSource = rd;
        }





    }
}