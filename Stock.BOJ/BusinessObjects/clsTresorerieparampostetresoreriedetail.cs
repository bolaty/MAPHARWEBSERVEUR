using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
    public class clsTresorerieparampostetresoreriedetail 
    {
        #region VARIABLES LOCALES

        private string _TP_CODEPOSTETRESORERIE = "";
        private string _PL_CODENUMCOMPTE = "";
        private string _TL_SIGNECOMPTE = "";

        #endregion

        #region ACCESSEURS

        public string TP_CODEPOSTETRESORERIE
        {
            get { return _TP_CODEPOSTETRESORERIE; }
            set { _TP_CODEPOSTETRESORERIE = value; }
        }

        public string PL_CODENUMCOMPTE
        {
            get { return _PL_CODENUMCOMPTE; }
            set { _PL_CODENUMCOMPTE = value; }
        }

        public string TL_SIGNECOMPTE
        {
            get { return _TL_SIGNECOMPTE; }
            set { _TL_SIGNECOMPTE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsTresorerieparampostetresoreriedetail () { }

        public clsTresorerieparampostetresoreriedetail (clsTresorerieparampostetresoreriedetail  clsTresorerieparampostetresoreriedetail )
        {
            this.TP_CODEPOSTETRESORERIE = clsTresorerieparampostetresoreriedetail .TP_CODEPOSTETRESORERIE;
            this.PL_CODENUMCOMPTE = clsTresorerieparampostetresoreriedetail .PL_CODENUMCOMPTE;
            this.TL_SIGNECOMPTE = clsTresorerieparampostetresoreriedetail .TL_SIGNECOMPTE;
        }

        #endregion

    }
}
