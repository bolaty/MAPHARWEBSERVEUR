using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Stock.TOOLS
{
    public class clsFichier
    {
       #region  declaration unique de la classe
        //declaration unique de la classe clsFichierText pour tout le projet
        private readonly static clsFichier ClassesFichier = new clsFichier();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsFichier()
        {
        }
        //constructeur public de la classe fonction 
        public static clsFichier ClasseFichier
        {
            get { return ClassesFichier; }
        }
        #endregion


        public String pvgLireScripts(string vppLeFichier)
        {
            string path = @"c:\test.sql";//chemin de ton fichier
            //
            StreamReader sr = null;
            //
            String line = null;

            try
            {
                sr = new StreamReader(path);
                line = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return line;//lcette variable stocke le contenu  de ton fichier .sql
        }

        public bool pvgTestExistenceFichier(string vppLeFichier)
        {
            return Microsoft.VisualBasic.FileIO.FileSystem.FileExists(vppLeFichier);
        }

        //Permet de connaitre la taille d'un repertoire ,contenant des fichiers
        public double pvgTailleRepertoireMo(string vppRepertoire)
        {
            DirectoryInfo vppRepertoireInfo = new DirectoryInfo(vppRepertoire);
            double vppTaille = 0;
            // TAILLE DES FICHIERS DU REPERTOIRES
            FileInfo[] fichierInfo = vppRepertoireInfo.GetFiles();
            foreach (FileInfo fichier in fichierInfo)
            {
                vppTaille += fichier.Length;
            }
            // TAILLE DES SOUS REPERTOIRES.
            DirectoryInfo[] dis = vppRepertoireInfo.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                vppTaille += pvgTailleRepertoireMo(di.FullName);
            }
            //return (vppTaille);
            return (vppTaille / (1024 * 1024));
        }

    }
}
