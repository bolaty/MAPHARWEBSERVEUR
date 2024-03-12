using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
    public class clsMicbudgetparampostebudgetairedetail
    {
        #region VARIABLES LOCALES

        private string _BG_CODEPOSTEBUDGETAIRE = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _BL_SIGNECOMPTE = "";

        #endregion

        #region ACCESSEURS

        public string BG_CODEPOSTEBUDGETAIRE
        {
            get { return _BG_CODEPOSTEBUDGETAIRE; }
            set { _BG_CODEPOSTEBUDGETAIRE = value; }
        }

        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }

        public string BL_SIGNECOMPTE
        {
            get { return _BL_SIGNECOMPTE; }
            set { _BL_SIGNECOMPTE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsMicbudgetparampostebudgetairedetail() { }

        public clsMicbudgetparampostebudgetairedetail(clsMicbudgetparampostebudgetairedetail clsMicbudgetparampostebudgetairedetail)
        {
            this.BG_CODEPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetairedetail.BG_CODEPOSTEBUDGETAIRE;
            this.PL_CODENUMCOMPTE = clsMicbudgetparampostebudgetairedetail.PL_CODENUMCOMPTE;
            this.BL_SIGNECOMPTE = clsMicbudgetparampostebudgetairedetail.BL_SIGNECOMPTE;
        }

        #endregion

    }
}
