using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
    public class clsMicbudgetparampostebudgetaire : clsEntitieBase
    {
        #region VARIABLES LOCALES

        private string _BG_CODEPOSTEBUDGETAIRE = "";
        private string _BT_CODETYPEBUDGET = "";
        private string _BD_CODETYPEBUDGETDETAIL = "";
        private string _BN_CODENATUREPOSTEBUDGETAIRE = "";
        private string _SR_CODESERVICE = "";
        private string _BG_LIBELLE = "";
        private string _BT_LIBELLE = "";
        private string _BD_LIBELLE = "";
        private string _BN_LIBELLE = "";


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
        public string BT_LIBELLE
        {
            get { return _BT_LIBELLE; }
            set { _BT_LIBELLE = value; }
        }
        public string BD_LIBELLE
        {
            get { return _BD_LIBELLE; }
            set { _BD_LIBELLE = value; }
        }
        public string BN_LIBELLE
        {
            get { return _BN_LIBELLE; }
            set { _BN_LIBELLE = value; }
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
            this.BT_LIBELLE = clsMicbudgetparampostebudgetaire.BT_LIBELLE;
            this.BD_LIBELLE = clsMicbudgetparampostebudgetaire.BD_LIBELLE;
            this.BN_LIBELLE = clsMicbudgetparampostebudgetaire.BN_LIBELLE;
        }

        #endregion

    }
}
