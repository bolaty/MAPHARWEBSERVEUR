using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
    public class clsMobiledetailoperationtontine
    {

        private string _DT_NUMEROTRANSACTION = "";
        private string _DT_DATEVALIDATION= "";
        private string _AG_CODEAGENCE= "";

        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";

        public string DT_NUMEROTRANSACTION
        {
            get { return _DT_NUMEROTRANSACTION; }
            set { _DT_NUMEROTRANSACTION = value; }
        }
        public string DT_DATEVALIDATION
        {
            get { return _DT_DATEVALIDATION; }
            set { _DT_DATEVALIDATION= value; }
        }
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE= value; }
        }

        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }


        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }



        public clsMobiledetailoperationtontine() { }


        public clsMobiledetailoperationtontine(clsMobiledetailoperationtontine clsMobiledetailoperationtontine)
        {
            DT_NUMEROTRANSACTION = clsMobiledetailoperationtontine.DT_NUMEROTRANSACTION;
            DT_DATEVALIDATION= clsMobiledetailoperationtontine.DT_DATEVALIDATION;
            AG_CODEAGENCE= clsMobiledetailoperationtontine.AG_CODEAGENCE;
            this.SL_CODEMESSAGE = clsMobiledetailoperationtontine.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsMobiledetailoperationtontine.SL_MESSAGE;
            this.SL_RESULTAT = clsMobiledetailoperationtontine.SL_RESULTAT;
        }
    }
}