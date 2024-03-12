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
    public class clsReseaux1
    {
        #region  Reseaux unique de la classe

        //Reseaux unique de la classe clsReseaux1 pour tout le projet
        private readonly static clsReseaux1 ClassesReseaux = new clsReseaux1();

        //constructeur privé de la classe clsReseaux1
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsReseaux1()
        {
        }
        //constructeur public de la classe fonction 

        public static clsReseaux1 ClasseReseaux
        {
            get { return ClassesReseaux; }
        }

        #endregion

        //Chargé de lister les noms des adaptateur réseau.
        //et de chercher l'addresse MAC d'une 
        //carte réseau sur la machine locale.
        public List<string[]> GetMACAddress()
        {
            List<string[]> maList = new List<string[]>();

            ManagementClass mc;
            //Creation d'une classe de gestion pour les adaptateurs de réseau
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //Collection des adaptateurs gérés par la classe de gestion.
            ManagementObjectCollection moc = mc.GetInstances();
            //Recherche des éléments actives qui ont des adresses IP.
            foreach (ManagementObject o in moc)
            {
                if ((bool)o.GetPropertyValue("IPEnabled") == true)
                {
                    string strAdapter; string strAdresseMac;
                    // Prendre le nom de l'adaptateur.
                    strAdapter = o.GetPropertyValue("Caption").ToString();
                    //Prendre l'adresse MAC de l'adaptateur.
                    strAdresseMac = o.GetPropertyValue("MacAddress").ToString();
                    // Ajout dans le Listbox
                    maList.Add(new string[] { strAdapter, strAdresseMac });
                }
            }
            return maList;
        }
    }
}
