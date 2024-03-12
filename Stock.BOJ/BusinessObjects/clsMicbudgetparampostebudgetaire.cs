using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
    public class clsMicbudgetparampostebudgetaire
    {
        #region VARIABLES LOCALES

        private string _BG_CODEPOSTEBUDGETAIRE = "";
        private string _BT_CODETYPEBUDGET = "";
        private string _BD_CODETYPEBUDGETDETAIL = "";
        private string _BN_CODENATUREPOSTEBUDGETAIRE = "";
        private string _SR_CODESERVICE = "";
        private string _BG_LIBELLE = "";

        #endregion

        #region ACCESSEURS

        public string BG_CODEPOSTEBUDGETAIRE
        {
            get { return _BG_CODEPOSTEBUDGETAIRE; }
            set { _BG_CODEPOSTEBUDGETAIRE = value; }
        }

        public string BT_CODETYPEBUDGET
        {
            get { return _BT_CODETYPEBUDGET; }
            set { _BT_CODETYPEBUDGET = value; }
        }

        public string BD_CODETYPEBUDGETDETAIL
        {
            get { return _BD_CODETYPEBUDGETDETAIL; }
            set { _BD_CODETYPEBUDGETDETAIL = value; }
        }
        public string BN_CODENATUREPOSTEBUDGETAIRE
        {
            get { return _BN_CODENATUREPOSTEBUDGETAIRE; }
            set { _BN_CODENATUREPOSTEBUDGETAIRE = value; }
        }
        public string SR_CODESERVICE
        {
            get { return _SR_CODESERVICE; }
            set { _SR_CODESERVICE = value; }
        }
        public string BG_LIBELLE
        {
            get { return _BG_LIBELLE; }
            set { _BG_LIBELLE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsMicbudgetparampostebudgetaire() { }

        public clsMicbudgetparampostebudgetaire(clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire)
        {
            this.BG_CODEPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetaire.BG_CODEPOSTEBUDGETAIRE;
            this.BT_CODETYPEBUDGET = clsMicbudgetparampostebudgetaire.BT_CODETYPEBUDGET;
            this.BD_CODETYPEBUDGETDETAIL = clsMicbudgetparampostebudgetaire.BD_CODETYPEBUDGETDETAIL;
            this.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetaire.BN_CODENATUREPOSTEBUDGETAIRE;
            this.SR_CODESERVICE = clsMicbudgetparampostebudgetaire.SR_CODESERVICE;
            this.BG_LIBELLE = clsMicbudgetparampostebudgetaire.BG_LIBELLE;
        }

        #endregion

    }
}
