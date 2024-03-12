using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Stock.BOJ
{

    public partial class clsHttoken
    {
        #region VARIABLES LOCALES

        private string _TK_TOKEN;
        private string _SL_RESULTAT;
        private string _SL_CODEMESSAGE;
        private string _SL_MESSAGE;
        private string _SL_MESSAGECLIENT;

      #endregion

      #region ACCESSEURS
      public string TK_TOKEN
      {
          get { return _TK_TOKEN; }
          set { _TK_TOKEN = value; }
      }

      public string SL_RESULTAT
      {
          get { return _SL_RESULTAT; }
          set { _SL_RESULTAT = value; }
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

        public string SL_MESSAGECLIENT
        {
            get { return _SL_MESSAGECLIENT; }
            set { _SL_MESSAGECLIENT = value; }
        }


   
      #endregion

       #region INSTANCIATEURS

     public clsHttoken() { }
		
      public clsHttoken(clsHttoken clsHttoken)
		{
            this.TK_TOKEN = clsHttoken.TK_TOKEN;
            this.SL_RESULTAT = clsHttoken.SL_RESULTAT;
            this.SL_CODEMESSAGE = clsHttoken.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsHttoken.SL_MESSAGE;  
            this.SL_MESSAGECLIENT = clsHttoken.SL_MESSAGECLIENT;      
        }

        #endregion

  }
}
