using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
    public class clsBusinessplanparampostedetail
    {
        #region VARIABLES LOCALES

        private string _PO_CODEPOSTEBUSINESSPLAN = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _PL_SIGNECOMPTE = "";

        #endregion

        #region ACCESSEURS

        public string PO_CODEPOSTEBUSINESSPLAN
        {
            get { return _PO_CODEPOSTEBUSINESSPLAN; }
            set { _PO_CODEPOSTEBUSINESSPLAN = value; }
        }

        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }

        public string PL_SIGNECOMPTE
        {
            get { return _PL_SIGNECOMPTE; }
            set { _PL_SIGNECOMPTE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsBusinessplanparampostedetail() { }

        public clsBusinessplanparampostedetail(clsBusinessplanparampostedetail clsBusinessplanparampostedetail)
        {
            this.PO_CODEPOSTEBUSINESSPLAN = clsBusinessplanparampostedetail.PO_CODEPOSTEBUSINESSPLAN;
            this.PL_CODENUMCOMPTE = clsBusinessplanparampostedetail.PL_CODENUMCOMPTE;
            this.PL_SIGNECOMPTE = clsBusinessplanparampostedetail.PL_SIGNECOMPTE;
        }

        #endregion

    }
}
