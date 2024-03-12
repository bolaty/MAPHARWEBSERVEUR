using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Card;



namespace Stock.TOOLS
{
    /// <summary>
    /// Classe de gestion des Grilles
    /// </summary>
    public class clsObjetXtraGrid
    {
        #region "Variables Private"
        private static clsObjetXtraGrid s_Instance;
        private static object s_InstanceLocker = new object();
        private string vlpTypeFormat = "";
        private string vlpTypeTotal = "";
        private string vlpHalign = "";
        private string vlpCalign = "";
        private bool vlpGroupSummaryFooter;
        GridGroupSummaryItemCollection gsiDisplaySummaryDetails;
        #endregion

        #region"Création"
        //Constructeur
        public clsObjetXtraGrid()
        {
        }
        // Singleton
        public static clsObjetXtraGrid Instance
        {
            get
            {
                lock (s_InstanceLocker)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new clsObjetXtraGrid();

                    }
                    return s_Instance;
                }
            }
        }
        #endregion

        #region "Procédures Publiques gridview"
        /// <summary>
        /// Permet de remplir une grille à partir d'un dataset
        /// </summary>
        /// <param name="myDataGridView","vppTable","vppChampsAffiches","vppTitreColonnes","vppLargeurColonnes"></param>
        /// <remarks></remarks>
        /// 
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, null, null, null, null, null, null);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, null, null, null, null, null);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, null, null, null, null);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, null, null, null);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, vppColonnesPosition, null, null);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition, bool[] vppModificationColonnes)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, vppColonnesPosition, vppModificationColonnes, null);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition, bool[] vppModificationColonnes, int[] vppIcones)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, vppColonnesPosition, vppModificationColonnes, null, false);
        }
        public void pvgInitGridView(GridView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition, bool[] vppModificationColonnes, int[] vppIcones, bool vppGroupSummaryFooter)
        {
            try
            {
                Stock.TOOLS.clsDeclaration.ClasseDeclaration.vagDureeInactivite = 0;
                //Suppression des lignes si besoin
                pvgViderGrille(vppXtrGid);
                //Appel de la procedure pvgStyleColonne
                if (vppTable == null) return;
                //vppXtrGid.GroupPanelText = "Déplacer une entête de colonne ici pour en faire un groupe";
                vppXtrGid.GroupPanelText = "Faites glisser un entête de colonne ici pour regrouper par cette colonne";
                vppXtrGid.OptionsView.ShowFooter = false;

                //vppXtrGid.OptionsMenu.EnableColumnMenu = false;//AFFICHE LE MENU CONTEXTUEL DES COLONNES
                vppXtrGid.OptionsSelection.EnableAppearanceFocusedCell = false;
                //vppXtrGid.
                vppXtrGid.OptionsPrint.ShowPrintExportProgress = true;

                vlpGroupSummaryFooter = vppGroupSummaryFooter;
                if (vlpGroupSummaryFooter)
                {
                    vppXtrGid.GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
                    gsiDisplaySummaryDetails = new GridGroupSummaryItemCollection(vppXtrGid);
                }
                else
                    vppXtrGid.GroupFooterShowMode = GroupFooterShowMode.Hidden;

                for (int i = 0; i < vppIdentifiantColonnes.GetLength(0); i++)
                {
                    GridColumn vlpMaColonne = new GridColumn();
                    vlpMaColonne.FieldName = vppChampsBD[i].ToString();
                    vlpMaColonne.Caption = vppLibelleEnteteColonnes[i].ToString();
                    vlpMaColonne.Name = vppIdentifiantColonnes[i].ToString();

                    pvgXtraGridFormatColonne(vppXtrGid, vlpMaColonne, vppFormatColonne[i].ToString());

                    if (vppColonnesPosition == null)
                        vlpMaColonne.VisibleIndex = i;
                    else
                        vlpMaColonne.VisibleIndex = (int)vppColonnesPosition[i];

                    if (vppColonnesVisible == null)
                        vlpMaColonne.Visible = true;
                    else
                        vlpMaColonne.Visible = (bool)vppColonnesVisible[i];

                    if (vppLargeurColonnes == null)
                        vlpMaColonne.Width = vlpMaColonne.MinWidth;
                    else
                        vlpMaColonne.Width = (int)vppLargeurColonnes[i];

                    if (vppModificationColonnes == null)
                        vlpMaColonne.OptionsColumn.AllowEdit = false;
                    else
                        vlpMaColonne.OptionsColumn.AllowEdit = (bool)vppModificationColonnes[i];

                    //vlpMaColonne.BestFit();
                    vlpMaColonne.OptionsColumn.FixedWidth = false;

                    //Affichage de icone image si une image list est rattaché
                    if (vppXtrGid.Images != null && vppIcones != null)
                    {
                        int vlpIndexIcone = (int)vppIcones[i];
                        if (vlpIndexIcone >= 0)
                        {
                            vlpMaColonne.ImageIndex = int.Parse(vppIcones[i].ToString());
                            vlpMaColonne.OptionsColumn.ShowCaption = false;
                            vlpMaColonne.OptionsColumn.AllowSize = false;
                            vlpMaColonne.OptionsColumn.FixedWidth = true;
                            vlpMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                            vlpMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            vlpMaColonne.AppearanceCell.Options.UseTextOptions = true;
                            vlpMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            vlpMaColonne.MaxWidth = vlpMaColonne.MinWidth = 70;
                        }
                    }
                    vlpMaColonne.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;

                    vppXtrGid.Columns.Add(vlpMaColonne);
                }

                //Assignation des resumés de groupes
                if (vlpGroupSummaryFooter)
                    vppXtrGid.GroupSummary.Assign(gsiDisplaySummaryDetails);

                if (vppTable.GetType() != typeof(DataSet)) return;
                DataSet vppDataSet;
                vppDataSet = (DataSet)vppTable;
                vppXtrGid.GridControl.DataSource = vppDataSet.Tables[0];
                //vppXtrGid.ShowEditor();
                //vppXtrGid.OptionsCustomization.AllowRowSizing = true;
                //vppXtrGid.OptionsCustomization.AllowColumnMoving = true;
                //vppXtrGid.ShowPrintPreview();
                vppXtrGid.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 7.90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //vppXtrGid.RowHeight = 6;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pvgXtraGridFormatColonne(GridView vppXtrGid, GridColumn vppMaColonne, string vppTypeFormat)
        {
            string[] vlpTabFormat = vppTypeFormat.Split('@');
            vlpTypeTotal = "";
            vlpTypeFormat = "";
            vlpHalign = vlpCalign = "";
            vlpTypeFormat = vlpTabFormat[0].ToString();
            if (vlpTabFormat.Length == 2)
                vlpTypeTotal = vlpTabFormat[1].ToString();

            if (vlpTabFormat.Length == 3)
            {
                vlpHalign = vlpCalign = vlpTabFormat[2].Substring(0, 1);
                if (vlpTabFormat[2].Length == 2)
                    vlpCalign = vlpTabFormat[2].Substring(1, 1);
            }

            switch (vlpTypeFormat)
            {
                case "d":
                case "D":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    vppMaColonne.DisplayFormat.FormatString = vppTypeFormat;
                    vppMaColonne.DisplayFormat.FormatType = FormatType.DateTime;
                    vppMaColonne.MaxWidth = vppMaColonne.MinWidth = 75;
                    break;
                case "P":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    vppMaColonne.DisplayFormat.FormatString = "p";
                    vppMaColonne.DisplayFormat.FormatType = FormatType.Numeric;
                    break;
                case "N":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    //vppMaColonne.DisplayFormat.FormatString = "{0:N0}";
                    vppMaColonne.DisplayFormat.FormatString = "{0:N0}";
                    vppMaColonne.DisplayFormat.FormatType = FormatType.Numeric;
                    break;
            }
            switch (vlpHalign)
            {
                case "G":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Default;
                    break;
                case "D":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case "M":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
            }
            switch (vlpCalign)
            {
                case "G":
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case "D":
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case "M":
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
            }

            if (!string.IsNullOrEmpty(vlpTypeTotal))
            {
                vppMaColonne.SummaryItem.DisplayFormat = "{0:N0}";
                switch (vlpTypeTotal)
                {
                    case "C":
                        vppMaColonne.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        if (vlpGroupSummaryFooter)
                            gsiDisplaySummaryDetails.Add(SummaryItemType.Count, vppMaColonne.FieldName, vppMaColonne, "{0}");
                        break;
                    case "S":
                        vppMaColonne.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        if (vlpGroupSummaryFooter)
                            gsiDisplaySummaryDetails.Add(SummaryItemType.Sum, vppMaColonne.FieldName, vppMaColonne, "{0:N0}");
                        break;
                }
            }

        }
        public void pvgViderGrille(GridView vppXtrGid)
        {
            vppXtrGid.GridControl.DataSource = null;
            vppXtrGid.Columns.Clear();
            vppXtrGid.GridControl.RepositoryItems.Clear(); //ajoute pour supprimer les controle positionnee sur les colonnes;

        }
        public void DeleteSelectedRows(GridView vppXtrGid)
        {
            if (vppXtrGid == null || vppXtrGid.SelectedRowsCount == 0) return;

            DataRow[] rows = new DataRow[vppXtrGid.SelectedRowsCount];
            for (int i = 0; i < vppXtrGid.SelectedRowsCount; i++)
                rows[i] = vppXtrGid.GetDataRow(vppXtrGid.GetSelectedRows()[i]);

            vppXtrGid.BeginSort();
            try
            {
                foreach (DataRow row in rows)
                    row.Delete();
            }
            finally
            {
                vppXtrGid.EndSort();
            }
        }
        #endregion

        #region "Formule de colonnes"
        public class clsXtraGridCoFormule
        {
            public clsXtraGridCoFormule()
            {
            }
            public clsXtraGridCoFormule(string vppIdColonne, string vppChaineFormule, UnboundColumnType vppTypeDonnees)
            {

            }
        }
        #endregion

        #region Fonctions Ajoutees par Brice
        /// <summary>
        /// Cette procedure permet de definir les cellules de colonnes d'une grille comme un type de controle (checkbox, combobox ,....)
        /// </summary>
        /// <param name="vppXtrGid">gridview</param>
        /// <param name="vppIdentifiantColonnes">tableau de string representant les identifiants des colonnes a transformer</param>
        /// <param name="vppTypeColonne" example="CH:Checkbox, CB:Combobox" >code du type de controle</param>
        /// <param name="vppTable" example ="" >valeurs de parametrages </param>
        public void pvgDefinirTypeChamp(GridView vppgridView, string[] vppIdentifiantColonnes, string[] vppTypeColonne, object[] vppTable)
        {

            try
            {
                for (int i = 0; i < vppIdentifiantColonnes.GetLength(0); i++)
                {
                    switch (vppTypeColonne[i])
                    {
                        case "MT"://CHECKBOX
                            RepositoryItemTextEdit repositoryitemtextedit = new RepositoryItemTextEdit();
                            repositoryitemtextedit.AutoHeight = false;
                            repositoryitemtextedit.Name = "repositoryitemtextedit_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemtextedit });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemtextedit;
                            repositoryitemtextedit.DisplayFormat.FormatString = "{0:N0}";
                            repositoryitemtextedit.DisplayFormat.FormatType = FormatType.Numeric;
                            break;
                        case "CH"://CHECKBOX
                            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryitemcheckedit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                            repositoryitemcheckedit.AutoHeight = false;
                            repositoryitemcheckedit.Name = "repositoryitemcheckedit_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemcheckedit });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemcheckedit;
                            if(vppTable[i].ToString().Contains(":"))
                            {
                                repositoryitemcheckedit.ValueChecked = vppTable[i].ToString().Split(':')[0].ToString();
                                repositoryitemcheckedit.ValueUnchecked = vppTable[i].ToString().Split(':')[1].ToString();
                            }
                            break;
                        case "CB"://COMBOBOX
                            DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryitemcombobox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                            repositoryitemcombobox.AutoHeight = false;
                            repositoryitemcombobox.Name = "repositoryitemcombobox_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemcombobox });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemcombobox;
                            String[] vlpValeur = new String[] { };
                            if (vppTable[i].GetType().Name == "String[]")
                            {
                                vlpValeur = (String[])vppTable[i];
                                for (int idx = 0; idx < vlpValeur.Length; idx++)
                                {
                                    repositoryitemcombobox.Items.Add(vlpValeur[idx].ToString());
                                    
                                }
                                break;
                            }
                            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                            //repositoryItemLookUpEdit.DataSource
                            
                            if (vppTable[i].GetType().Name == "String")
                            {
                                vlpValeur = vppTable[i].ToString().Split(':');
                                for (int idx = 0; idx < vlpValeur.GetLength(0); idx++)
                                {
                                    repositoryitemcombobox.Items.Add(vlpValeur[idx].ToString());
                                }
                                break;
                            }
                            break;
                        case "LE"://LOOKUPEDIT
                            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryitemlookupedit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                            repositoryitemlookupedit.AutoHeight = false;
                            repositoryitemlookupedit.Name = "repositoryitemlookupedit_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemlookupedit });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemlookupedit;
                            repositoryitemlookupedit.NullText = "";
                            
                            if (vppTable[i].GetType().Name == "DataSet")
                            {
                                DataSet vlpDataset = new DataSet(); vlpDataset = (DataSet)vppTable[i];
                                if (vlpDataset.Tables.Count > 0)
                                {
                                    repositoryitemlookupedit.DataSource = vlpDataset.Tables[0] ;
                                    for (int J = 0; J < vlpDataset.Tables[0].Columns.Count; J++)
                                    {
                                        repositoryitemlookupedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(vlpDataset.Tables[0].Columns[J].ColumnName));
                                        repositoryitemlookupedit.Columns[J].FieldName = vlpDataset.Tables[0].Columns[J].ColumnName;
                                    }

                                    if (vlpDataset.Tables[0].Columns.Count == 1)
                                    {                                       
                                        repositoryitemlookupedit.ValueMember = repositoryitemlookupedit.DisplayMember =vlpDataset.Tables[0].Columns[0].ColumnName;
                                    }
                                    if (vlpDataset.Tables[0].Columns.Count >1)
                                    {
                                        repositoryitemlookupedit.Columns[0].Visible = false;
                                        repositoryitemlookupedit.ValueMember = vlpDataset.Tables[0].Columns[0].ColumnName;
                                        repositoryitemlookupedit.DisplayMember = vlpDataset.Tables[0].Columns[1].ColumnName;
                                    }

                                }
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            catch { }
        }

        public void pvgTransfererLigneGrille(GridView vppgridViewOrigine, GridView vppgridViewDestination, string[] vppChamp)
        {
            try
            {
                if (vppChamp.Length > 0)
                {
                    vppgridViewDestination.AddNewRow();
                    for (int Idx = 0; Idx < vppChamp.Length; Idx++)
                    {
                        vppgridViewDestination.SetFocusedRowCellValue(vppChamp[Idx], vppgridViewOrigine.GetDataRow(vppgridViewOrigine.GetSelectedRows()[0])[vppChamp[Idx]].ToString());
                    }
                    vppgridViewDestination.UpdateCurrentRow();
                    vppgridViewOrigine.DeleteRow(vppgridViewOrigine.GetSelectedRows()[0]);
                }
            }
            catch { }
        }

        public void pvgmodifierValeurLigneGrille(GridView vppgridView, int vppIndex, string[] vppChamp, object[] vppValeur)
        {
            try
            {
                if (vppChamp.Length > 0)
                    for (int i = 0; i < vppChamp.Length; i++)
                        vppgridView.SetRowCellValue(vppIndex, vppChamp[i], vppValeur[i]);
            }
            catch { }
        }

        /// <summary>
        /// cette procedure permet de valider le type de données qui se trouve dans une grille
        /// </summary>
        /// <param name="vppgridView">grille</param>
        /// <param name="vppChampType">champ où est definit le type de données (date , numerique, )</param>
        /// <param name="e">DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs</param>
        /// <returns>bool</returns>
        public bool pvgValidatingEditor(GridView vppgridView, string vppChampType, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                switch (vppgridView.GetDataRow(vppgridView.GetSelectedRows()[0])[vppChampType].ToString().ToLower())
                {
                    case "date":
                        if (e.Value.ToString() != "")
                            DateTime.Parse(e.Value.ToString());
                        break;
                    case "numerique":
                        if (e.Value.ToString() != "")
                            double.Parse(e.Value.ToString());
                        break;
                    case "numerique+":
                        if (e.Value.ToString() != "")
                            e.Value=Math.Abs(double.Parse(e.Value.ToString()));
                        break;
                    case "numerique-":
                        if (e.Value.ToString() != "")
                            e.Value=-Math.Abs(double.Parse(e.Value.ToString()));
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                e.Valid = false;
            }
            return e.Valid;
        }

        public void pvgDefinirTypeChamp(CardView vppgridView, string[] vppIdentifiantColonnes, string[] vppTypeColonne, object[] vppTable)
        {

            try
            {
                for (int i = 0; i < vppIdentifiantColonnes.GetLength(0); i++)
                {
                    switch (vppTypeColonne[i])
                    {
                        case "CH"://CHECKBOX
                            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryitemcheckedit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                            repositoryitemcheckedit.AutoHeight = false;
                            repositoryitemcheckedit.Name = "repositoryitemcheckedit_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemcheckedit });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemcheckedit;
                            if (vppTable[i].ToString().Contains(":"))
                            {
                                repositoryitemcheckedit.ValueChecked = vppTable[i].ToString().Split(':')[0].ToString();
                                repositoryitemcheckedit.ValueUnchecked = vppTable[i].ToString().Split(':')[1].ToString();
                            }
                            break;
                        case "CB"://COMBOBOX
                            DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryitemcombobox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                            repositoryitemcombobox.AutoHeight = false;
                            repositoryitemcombobox.Name = "repositoryitemcombobox_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemcombobox });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemcombobox;
                            String[] vlpValeur = new String[] { };
                            if (vppTable[i].GetType().Name == "String[]")
                            {
                                vlpValeur = (String[])vppTable[i];
                                for (int idx = 0; idx < vlpValeur.Length; idx++)
                                {
                                    repositoryitemcombobox.Items.Add(vlpValeur[idx].ToString());
                                }
                                break;
                            }

                            vlpValeur = vppTable[i].ToString().Split(':');
                            if (vppTable[i].GetType().Name == "Array")
                            {
                                for (int idx = 0; idx < vlpValeur.GetLength(0); idx++)
                                {
                                    repositoryitemcombobox.Items.Add(vlpValeur[idx].ToString());
                                }
                            }
                            break;
                        case "LE"://LOOKUPEDIT
                            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryitemlookupedit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                            repositoryitemlookupedit.AutoHeight = false;
                            repositoryitemlookupedit.Name = "repositoryitemlookupedit_" + vppIdentifiantColonnes[i];
                            vppgridView.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryitemlookupedit });
                            vppgridView.Columns[vppIdentifiantColonnes[i]].ColumnEdit = repositoryitemlookupedit;
                            if (vppTable[i].GetType().Name == "DataTable")
                            {
                                repositoryitemlookupedit.DataSource = vppTable[i];
                                //repositoryitemlookupedit.DisplayMember
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            catch { }
        }

        public void pvgTransfererLigneGrille(CardView vppgridViewOrigine, GridView vppgridViewDestination, string[] vppChamp)
        {
            try
            {
                if (vppChamp.Length > 0)
                {
                    vppgridViewDestination.AddNewRow();
                    for (int Idx = 0; Idx < vppChamp.Length; Idx++)
                    {
                        vppgridViewDestination.SetFocusedRowCellValue(vppChamp[Idx], vppgridViewOrigine.GetDataRow(vppgridViewOrigine.GetSelectedRows()[0])[vppChamp[Idx]].ToString());
                    }
                    vppgridViewOrigine.DeleteRow(vppgridViewOrigine.GetSelectedRows()[0]);
                }
            }
            catch { }
        }

        public void pvgmodifierValeurLigneGrille(CardView vppgridView, int vppIndex, string[] vppChamp, object[] vppValeur)
        {
            try
            {
                if (vppChamp.Length > 0)
                    for (int i = 0; i < vppChamp.Length; i++)
                        vppgridView.SetRowCellValue(vppIndex, vppChamp[i], vppValeur[i]);
            }
            catch { }
        }


        #region "Procédures Publiques cardview"
        /// <summary>
        /// Permet de remplir une grille à partir d'un dataset
        /// </summary>
        /// <param name="myDataGridView","vppTable","vppChampsAffiches","vppTitreColonnes","vppLargeurColonnes"></param>
        /// <remarks></remarks>
        /// 
        public void pvgInitGridView(CardView  vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, null, null, null, null, null, null);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, null, null, null, null, null);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, null, null, null, null);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, null, null, null);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, vppColonnesPosition, null, null);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition, bool[] vppModificationColonnes)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, vppColonnesPosition, vppModificationColonnes, null);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition, bool[] vppModificationColonnes, int[] vppIcones)
        {
            pvgInitGridView(vppXtrGid, vppTable, vppChampsBD, vppLibelleEnteteColonnes, vppIdentifiantColonnes, vppLargeurColonnes, vppFormatColonne, vppColonnesVisible, vppColonnesPosition, vppModificationColonnes, null, false);
        }
        public void pvgInitGridView(CardView vppXtrGid, object vppTable, string[] vppChampsBD, string[] vppLibelleEnteteColonnes, string[] vppIdentifiantColonnes, int[] vppLargeurColonnes, string[] vppFormatColonne, bool[] vppColonnesVisible, int[] vppColonnesPosition, bool[] vppModificationColonnes, int[] vppIcones, bool vppGroupSummaryFooter)
        {
            try
            {
                //Suppression des lignes si besoin
                pvgViderGrille(vppXtrGid);
                //Appel de la procedure pvgStyleColonne
                if (vppTable == null) return;
                //vppXtrGid.GroupPanelText = "Déplacer une entête de colonne ici pour en faire un groupe";
                //vppXtrGid.GroupPanelText = "Faites glisser un entête de colonne ici pour regrouper par cette colonne";
                //vppXtrGid.OptionsView.ShowFooter = false;

                //vppXtrGid.OptionsMenu.EnableColumnMenu = false;//AFFICHE LE MENU CONTEXTUEL DES COLONNES
                //vppXtrGid.OptionsSelection.EnableAppearanceFocusedCell = false;
                //vppXtrGid.
                vppXtrGid.OptionsPrint.ShowPrintExportProgress = true;

                vlpGroupSummaryFooter = vppGroupSummaryFooter;
                //if (vlpGroupSummaryFooter)
                //{
                //    vppXtrGid.GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
                //    gsiDisplaySummaryDetails = new GridGroupSummaryItemCollection(vppXtrGid);
                //}
                //else
                //    vppXtrGid.GroupFooterShowMode = GroupFooterShowMode.Hidden;

                for (int i = 0; i < vppIdentifiantColonnes.GetLength(0); i++)
                {
                    GridColumn vlpMaColonne = new GridColumn();
                    vlpMaColonne.FieldName = vppChampsBD[i].ToString();
                    vlpMaColonne.Caption = vppLibelleEnteteColonnes[i].ToString();
                    vlpMaColonne.Name = vppIdentifiantColonnes[i].ToString();

                    pvgXtraGridFormatColonne(vppXtrGid, vlpMaColonne, vppFormatColonne[i].ToString());

                    if (vppColonnesPosition == null)
                        vlpMaColonne.VisibleIndex = i;
                    else
                        vlpMaColonne.VisibleIndex = (int)vppColonnesPosition[i];

                    if (vppColonnesVisible == null)
                        vlpMaColonne.Visible = true;
                    else
                        vlpMaColonne.Visible = (bool)vppColonnesVisible[i];

                    if (vppLargeurColonnes == null)
                        vlpMaColonne.Width = vlpMaColonne.MinWidth;
                    else
                        vlpMaColonne.Width = (int)vppLargeurColonnes[i];

                    if (vppModificationColonnes == null)
                        vlpMaColonne.OptionsColumn.AllowEdit = false;
                    else
                        vlpMaColonne.OptionsColumn.AllowEdit = (bool)vppModificationColonnes[i];

                    //vlpMaColonne.BestFit();
                    vlpMaColonne.OptionsColumn.FixedWidth = false;

                    //Affichage de icone image si une image list est rattaché
                    if (vppXtrGid.Images != null && vppIcones != null)
                    {
                        int vlpIndexIcone = (int)vppIcones[i];
                        if (vlpIndexIcone >= 0)
                        {
                            vlpMaColonne.ImageIndex = int.Parse(vppIcones[i].ToString());
                            vlpMaColonne.OptionsColumn.ShowCaption = false;
                            vlpMaColonne.OptionsColumn.AllowSize = false;
                            vlpMaColonne.OptionsColumn.FixedWidth = true;
                            vlpMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                            vlpMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            vlpMaColonne.AppearanceCell.Options.UseTextOptions = true;
                            vlpMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            vlpMaColonne.MaxWidth = vlpMaColonne.MinWidth = 70;
                        }
                    }
                    vlpMaColonne.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;

                    vppXtrGid.Columns.Add(vlpMaColonne);
                }

                //Assignation des resumés de groupes
                //if (vlpGroupSummaryFooter)
                //    vppXtrGid.GroupSummary.Assign(gsiDisplaySummaryDetails);

                if (vppTable.GetType() != typeof(DataSet)) return;
                DataSet vppDataSet;
                vppDataSet = (DataSet)vppTable;
                vppXtrGid.GridControl.DataSource = vppDataSet.Tables[0];
                //vppXtrGid.ShowEditor();
                //vppXtrGid.OptionsCustomization.AllowRowSizing = true;
                //vppXtrGid.OptionsCustomization.AllowColumnMoving = true;
                //vppXtrGid.ShowPrintPreview();
                vppXtrGid.Appearance.Card.Font = new System.Drawing.Font("Tahoma", 7.90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //vppXtrGid.RowHeight = 6;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pvgXtraGridFormatColonne(CardView vppXtrGid, GridColumn vppMaColonne, string vppTypeFormat)
        {
            string[] vlpTabFormat = vppTypeFormat.Split('@');
            vlpTypeTotal = "";
            vlpTypeFormat = "";
            vlpHalign = vlpCalign = "";
            vlpTypeFormat = vlpTabFormat[0].ToString();
            if (vlpTabFormat.Length == 2)
                vlpTypeTotal = vlpTabFormat[1].ToString();

            if (vlpTabFormat.Length == 3)
            {
                vlpHalign = vlpCalign = vlpTabFormat[2].Substring(0, 1);
                if (vlpTabFormat[2].Length == 2)
                    vlpCalign = vlpTabFormat[2].Substring(1, 1);
            }

            switch (vlpTypeFormat)
            {
                case "d":
                case "D":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    vppMaColonne.DisplayFormat.FormatString = vppTypeFormat;
                    vppMaColonne.DisplayFormat.FormatType = FormatType.DateTime;
                    vppMaColonne.MaxWidth = vppMaColonne.MinWidth = 75;
                    break;
                case "P":
                    vppMaColonne.DisplayFormat.FormatString = "p";
                    vppMaColonne.DisplayFormat.FormatType = FormatType.Numeric;
                    break;
                case "N":
                    vppMaColonne.DisplayFormat.FormatString = "{0:N0}";
                    vppMaColonne.DisplayFormat.FormatType = FormatType.Numeric;
                    break;
            }
            switch (vlpHalign)
            {
                case "G":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Default;
                    break;
                case "D":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case "M":
                    vppMaColonne.AppearanceHeader.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
            }
            switch (vlpCalign)
            {
                case "G":
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case "D":
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case "M":
                    vppMaColonne.AppearanceCell.Options.UseTextOptions = true;
                    vppMaColonne.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
            }

            if (!string.IsNullOrEmpty(vlpTypeTotal))
            {
                vppMaColonne.SummaryItem.DisplayFormat = "{0:N0}";
                switch (vlpTypeTotal)
                {
                    case "C":
                        vppMaColonne.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        if (vlpGroupSummaryFooter)
                            gsiDisplaySummaryDetails.Add(SummaryItemType.Count, vppMaColonne.FieldName, vppMaColonne, "{0}");
                        break;
                    case "S":
                        vppMaColonne.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        if (vlpGroupSummaryFooter)
                            gsiDisplaySummaryDetails.Add(SummaryItemType.Sum, vppMaColonne.FieldName, vppMaColonne, "{0:N0}");
                        break;
                }
            }

        }
        public void pvgViderGrille(CardView vppXtrGid)
        {
            vppXtrGid.GridControl.DataSource = null;
            vppXtrGid.Columns.Clear();
            vppXtrGid.GridControl.RepositoryItems.Clear(); //ajoute pour supprimer les controle positionnee sur les colonnes;

        }
        public void DeleteSelectedRows(CardView vppXtrGid)
        {
            if (vppXtrGid == null || vppXtrGid.SelectedRowsCount == 0) return;

            DataRow[] rows = new DataRow[vppXtrGid.SelectedRowsCount];
            for (int i = 0; i < vppXtrGid.SelectedRowsCount; i++)
                rows[i] = vppXtrGid.GetDataRow(vppXtrGid.GetSelectedRows()[i]);

            vppXtrGid.BeginSort();
            try
            {
                foreach (DataRow row in rows)
                    row.Delete();
            }
            finally
            {
                vppXtrGid.EndSort();
            }
        }
        #endregion



        #endregion

    }
}
