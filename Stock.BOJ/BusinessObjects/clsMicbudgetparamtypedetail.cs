using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
    public class clsMicbudgetparamtypedetail
    {
        #region VARIABLES LOCALES

        private string _BT_CODETYPEBUDGET = "";
        private string _BD_CODETYPEBUDGETDETAIL = "";
        private string _BD_LIBELLE = "";

        #endregion

        #region ACCESSEURS

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

        public string BD_LIBELLE
        {
            get { return _BD_LIBELLE; }
            set { _BD_LIBELLE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsMicbudgetparamtypedetail() { }

        public clsMicbudgetparamtypedetail(clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail)
        {
            this.BT_CODETYPEBUDGET = clsMicbudgetparamtypedetail.BT_CODETYPEBUDGET;
            this.BD_CODETYPEBUDGETDETAIL = clsMicbudgetparamtypedetail.BD_CODETYPEBUDGETDETAIL;
            this.BD_LIBELLE = clsMicbudgetparamtypedetail.BD_LIBELLE;
        }

        #endregion

    }
}