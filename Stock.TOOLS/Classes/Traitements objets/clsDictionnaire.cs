using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors;
using DevExpress.Utils.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting.Localization;

namespace Stock.TOOLS
{
    public class clsXtraGridTraducteur : GridLocalizer
    {
        public override string Language { get { return "French"; } }
        public override string GetLocalizedString(GridStringId id)
        {
            //string ret = "";
            switch (id)
            {
                // ... 
//Menu colonne
                case GridStringId.MenuColumnSortAscending: return "Tri croissant";
                case GridStringId.MenuColumnSortDescending: return "Tri Décroissant";
                case GridStringId.MenuColumnClearSorting: return "Annuler le Tri";

                case GridStringId.MenuColumnGroup: return "Definir cette colonne comme groupe";
                case GridStringId.MenuColumnUnGroup: return "Annuler le Groupe";
                case GridStringId.MenuGroupPanelClearGrouping: return "Effacer le groupe";
                case GridStringId.MenuGroupPanelHide: return "Cacher la zone de groupe";
                case GridStringId.MenuGroupPanelShow: return "Afficher la zone de groupe";
                case GridStringId.MenuGroupPanelFullExpand: return "Derouler le groupe";
                case GridStringId.MenuGroupPanelFullCollapse: return "Reduire le groupe";
                case GridStringId.MenuColumnColumnCustomization: return "Choix des Colonnes";
                //case GridStringId.MenuColumnColumnCustomization:return "Laufzeit benutzerdefinierte Spalte";
                case GridStringId.MenuColumnBestFit: return "Largeur Optimale";
                case GridStringId.MenuColumnFilter: return "Definir Filtre";
                case GridStringId.MenuColumnFilterEditor: return "Editeur de Filtre";
                //case GridStringId.MenuColumnExpressionEditor: return "Editeur de d'expression";
                case GridStringId.MenuColumnClearFilter: return "Effacer Filtre";
                case GridStringId.MenuColumnBestFitAllColumns: return "Largeur Optimale (Toutes les colonnes)";
                case GridStringId.MenuColumnAutoFilterRowShow: return "Afficher ligne de tri automatique";
                case GridStringId.MenuColumnAutoFilterRowHide: return "Cacher ligne de tri automatique";
                //case GridStringId.MenuColumnExpressionEditor: return "MenuColumnExpressionEditor";
                //case GridStringId.MenuColumnFilterModeDisplayText: return "Effacer Filtre";
                //Menu Filtre
                case GridStringId.PopupFilterBlanks: return "Vide";
                case GridStringId.PopupFilterAll: return "Tout";
                case GridStringId.PopupFilterCustom: return "Definir Filtre";
                case GridStringId.PopupFilterNonBlanks: return "Non Vide";
                //Menu Rechercher
                case GridStringId.MenuColumnFindFilterHide: return "Cacher Zone de Recherche";
                case GridStringId.MenuColumnFindFilterShow: return "Afficher Zone de Recherche";
                case GridStringId.FindControlFindButton: return "Rechercher";
                case GridStringId.FindControlClearButton: return "Effacer";
                case GridStringId.CustomFilterDialogCaption: return "Definir Filtre";
                // ... 
                default:
                    return base.GetLocalizedString(id);
            }
            //return ret;
        }

    }


    public class clsXtraEditorsTraducteur : Localizer
    {
        public override string Language { get { return "French"; } }
        public override string GetLocalizedString(StringId id)
        {
            
            switch (id)
            {
                // ... 
                case StringId.NavigatorTextStringFormat: return "N° {0} Sur {1}";
                case StringId.PictureEditMenuCut: return "Couper";
                case StringId.PictureEditMenuCopy: return "Copier";
                case StringId.PictureEditMenuPaste: return "Coller";
                case StringId.PictureEditMenuDelete: return "Supprimer";
                case StringId.PictureEditMenuLoad: return "Charger";
                case StringId.PictureEditMenuSave: return "Enregistrer";
                case StringId.Cancel: return "Annuler";
                case StringId.DateEditClear: return "Effacer";
                case StringId.DateEditToday: return "Aujourd'hui";
                case StringId.TextEditMenuCopy: return "Copier";
                case StringId.TextEditMenuCut: return "Couper";
                case StringId.TextEditMenuDelete: return "Supprimer";
                case StringId.TextEditMenuPaste: return "Coller";
                case StringId.TextEditMenuSelectAll: return "Sélectionner Tout";
                case StringId.TextEditMenuUndo: return "Annuler";
                case StringId.XtraMessageBoxAbortButtonText: return "Arrêter";
                case StringId.XtraMessageBoxCancelButtonText: return "Annuler";
                case StringId.XtraMessageBoxIgnoreButtonText: return "Ignorer";
                case StringId.XtraMessageBoxNoButtonText: return "Non";
                case StringId.XtraMessageBoxOkButtonText: return "OK";
                case StringId.XtraMessageBoxRetryButtonText: return "Reprendre";
                case StringId.XtraMessageBoxYesButtonText: return "Oui";
                case StringId.Apply: return "Appliquer";
                case StringId.CheckChecked: return "Coché";
                case StringId.CheckUnchecked: return "décoché";
                case StringId.CheckIndeterminate: return "Indéterminé";
                case StringId.FilterCriteriaToStringFunctionReplace: return "Remplacer";
                case StringId.FilterCriteriaToStringFunctionReverse: return "Inverser";
                case StringId.FilterCriteriaToStringFunctionRound: return "Arrondir";
                default: return base.GetLocalizedString(id);
                // ... 
            }
            //return "";
        }
    }

    public class clsPrintingPreview : DevExpress.XtraPrinting.Localization.PreviewLocalizer
    {
        
        public override string Language { get { return "French"; } }
        public override string GetLocalizedString(PreviewStringId id)
        {
            switch (id)
            {
                // ...
                case PreviewStringId.RibbonPreview_ShowNextPage_Caption: return "Suivant";
                case PreviewStringId.RibbonPreview_ShowPrevPage_Caption: return "Précédent";
                case PreviewStringId.RibbonPreview_ExportPdf_Caption: return "Fichier PDF";
                case PreviewStringId.RibbonPreview_ExportPdf_Description: return "Fichier PDF";
                case PreviewStringId.RibbonPreview_ExportPdf_STipContent: return "Fichier PDF";
                case PreviewStringId.RibbonPreview_ExportPdf_STipTitle: return "Fichier PDF";
                case PreviewStringId.MenuItem_Background: return "Arrière plan";

                default: return GetLocalizedString(id);
                // ... 
            }
            //return "";
        }
    }

}
