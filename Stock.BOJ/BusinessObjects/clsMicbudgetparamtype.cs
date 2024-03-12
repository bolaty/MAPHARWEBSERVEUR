using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
    public class clsMicbudgetparamtype
    {
        #region VARIABLES LOCALES

        private string _BT_CODETYPEBUDGET = "";
        private string _BT_LIBELLE = "";

        #endregion

        #region ACCESSEURS

        public string BT_CODETYPEBUDGET
        {
            get { return _BT_CODETYPEBUDGET; }
            set { _BT_CODETYPEBUDGET = value; }
        }

        public string BT_LIBELLE
        {
            get { return _BT_LIBELLE; }
            set { _BT_LIBELLE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsMicbudgetparamtype() { }
        public clsMicbudgetparamtype(clsMicbudgetparamtype clsMicbudgetparamtype)
        {
            this.BT_CODETYPEBUDGET = clsMicbudgetparamtype.BT_CODETYPEBUDGET;
            this.BT_LIBELLE = clsMicbudgetparamtype.BT_LIBELLE;
        }

        #endregion

    }
}
