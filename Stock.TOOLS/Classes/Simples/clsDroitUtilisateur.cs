using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Management;

namespace Stock.TOOLS
{
    public class clsDroitUtilisateur
    {
        #region  Droit Utilisateur unique de la classe
        //Reseaux unique de la classe clsDroitUtilisateur pour tout le projet
        private readonly static clsDroitUtilisateur ClassesDroitUtilisateur = new clsDroitUtilisateur();

        //constructeur privé de la classe clsDroitUtilisateur
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsDroitUtilisateur()
        {
        }
        //constructeur public de la classe fonction 
        public static clsDroitUtilisateur ClasseDroitUtilisateur
        {
            get { return ClassesDroitUtilisateur; }
        }
        #endregion

        /// <summary>
        /// Cette procedure permet d'activer un menu si son nom est contenu 
        /// dans la liste "vppListeMenu" ou le desactiver dans le cas contraire 
        /// </summary>
        /// <param name="vppMenu"> ToolStripMenuItem </param>
        /// <param name="vppListeMenu"> liste contenant le nom des menus autorisés </param>
        public void pvpDroitAccesMenu(ToolStripMenuItem vppMenu, List<string> vppListeMenu)
        {
            for (int Idx = 0; Idx < vppMenu.DropDownItems.Count; Idx++)
            {
                //if (vppMenu.DropDownItems[Idx] is ToolStripMenuItem)
                //    vppMenu.DropDownItems[Idx].Enabled = vppListeMenu.Contains(vppMenu.DropDownItems[Idx].Name) ? true : false;
                if (vppMenu.DropDownItems[Idx] is ToolStripMenuItem)
                    if (vppListeMenu.Contains(vppMenu.DropDownItems[Idx].Name))
                        vppMenu.DropDownItems[Idx].Enabled = false;
            }
        }
    }
}
