using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress;

namespace Stock.TOOLS
{
    public class clsPatienteur
    {
        private static clsPatienteur s_Instance;
        private static object s_InstanceLocker = new object();

        private DevExpress.Utils.WaitDialogForm Dlg = null;

        private string _Titre = "";
        private string _SousTitre = "";
        private long _Compteur = 0;
        private long _Total = 0;
        private bool _Afficher = true;
        private bool _Arreter = false;


        public string Titre
        {
            get { return _Titre; }
            set { _Titre = value; }
        }
        public string SousTitre
        {
            get { return _SousTitre; }
            set { _SousTitre = value; }
        }
        public long Compteur
        {
            get { return _Compteur; }
            set { _Compteur = value; }
        }
        public long Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public bool Afficher
        {
            get { return _Afficher; }
            set { _Afficher = value; }
        }
        public bool Arreter
        {
            get { return _Arreter; }
            set { _Arreter = value; }
        }

        // Singleton 
        public static clsPatienteur Instance
        {
            get
            {
                lock (s_InstanceLocker)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new clsPatienteur();
                    }
                    return s_Instance;
                }
            }
        }

        public void Initiatialiser()
        {
            this.Afficher = true;
            this.Arreter = false;
            this.Compteur = 0;
            this.SousTitre = "";
            this.Titre = "";
            this.Total = 0;
        }

        //Création du patienteur
        public void CreateWaitDialog()
        {
            CreateWaitDialog("", "Chargement en cours...,Veuillez Patienter svp");
        }
        //Création du patienteur,surchargé
        public void CreateWaitDialog(string Caption, string Title)
        {

            if (string.IsNullOrEmpty(Title))
            {
                Dlg = new DevExpress.Utils.WaitDialogForm(Caption,new System.Drawing.Size(400, 75));
           }
            else
            {
                Dlg = new DevExpress.Utils.WaitDialogForm(Caption, Title,new System.Drawing.Size(400,75));
            }
        }
        //Fermerture du patienteur
        public void CloseWaitDialog()
        {
            Dlg.Close();
        }
        //
        public void SetWaitDialogCaption(string fCaption)
        {
            if (Dlg != null)
            {
                Dlg.Caption = fCaption;
            }
        }

    }
}
