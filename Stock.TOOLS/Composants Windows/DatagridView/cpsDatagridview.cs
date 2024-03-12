using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stock.TOOLS
{
    public class cpsDatagridview : DataGridView
    {
        public cpsDatagridview()
        {
            this.AlternatingRowsDefaultCellStyle.BackColor = Stock.TOOLS.clsDeclaration.BleuCiel;
            //this.SortOrder = SortOrder.None;
        }
        protected override void  OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (this.Columns[e.ColumnIndex].Tag.ToString() == "TN")
                {
                    if (this.Columns[e.ColumnIndex].Tag.ToString() == "") this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = clsNombreMontant.ClasseNombre.pvgFormatageEnMillier(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), "M");
                }
                if (this.Columns[e.ColumnIndex].Tag.ToString() == "DP")
                {
                    if (this.Columns[e.ColumnIndex].Tag.ToString() == "") this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DateTime.Parse(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).ToShortDateString();
                }
            }
            base.OnCellFormatting(e);
        }

        protected override void OnCellValidating(DataGridViewCellValidatingEventArgs e)
        {
            //1-Validation de la valeur maximale du taux
            if (this.Columns[e.ColumnIndex].Tag.ToString() == "TP")
            {
                if (!e.FormattedValue.Equals(""))
                {
                    if (double.Parse(e.FormattedValue.ToString()) > 100)
                    {
                        MessageBox.Show("Taux incorrect !!!", Application.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }

            //2-Validation du masque de saisie des heures
            if (this.Columns[e.ColumnIndex].Tag.ToString() == "HM")
            {
                if (!e.FormattedValue.Equals(""))
                {
                    bool vlpOK = clsChaineCaractere.ClasseChaineCaractere.pvgValidationHeure(e.FormattedValue.ToString());
                    if (!(vlpOK))
                    {
                        MessageBox.Show(this, "L'heure saisie est incorrect!", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }

            base.OnCellValidating(e);
        }
        protected override void OnCellLeave(DataGridViewCellEventArgs e)
        {
            //if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{

            //    bool vlpOK = clsChaineCaractere.ClasseChaineCaractere.pvgValidationHeure(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //    if (!(vlpOK))
            //    {
            //        MessageBox.Show(this, "L'heure saisie est incorrect!", "",
            //            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        e.Cancel = true;
            //    }
            //}
            //base.OnCellLeave(e);
        }
        public void pvgEditingControlShowing(cpsDatagridview cpsDatagridview,object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (cpsDatagridview.Columns[cpsDatagridview.CurrentCell.ColumnIndex].Tag.ToString() == "TN" || cpsDatagridview.Columns[cpsDatagridview.CurrentCell.ColumnIndex].Tag.ToString() == "TP")
                {
                    clsDeclaration.vagControl = (DataGridViewTextBoxEditingControl)e.Control;
                    clsDeclaration.vagControl.KeyPress += clsNombreMontant.ClasseNombre.pvgSaisirNumeriqueGrille;
                }
            }
            catch
            {
            }
        }
    }
}
