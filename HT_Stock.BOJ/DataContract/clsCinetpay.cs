using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HT_Stock.BOJ
{

    public partial class clsCinetpay 
  {
        #region VARIABLES LOCALES

        private string _code;
        private string _message;
        private clsDataToken _data ;
      


      #endregion

      #region ACCESSEURS
      public string code
      {
          get { return _code; }
          set { _code = value; }
      }

      public string message
      {
          get { return _message; }
          set { _message = value; }
      }
      

      public clsDataToken data
        {
            get { return _data; }
            set { _data = value; }
        }

   
      #endregion

       #region INSTANCIATEURS

     public clsCinetpay() { }
		
      public clsCinetpay(clsCinetpay clsCinetpay)
		{
            this.code = clsCinetpay.code;
            this.message = clsCinetpay.message;
            this.data = clsCinetpay.data;
           

           
        }

        #endregion

  }
}
