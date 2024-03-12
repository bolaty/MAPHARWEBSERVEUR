using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HT_Stock.BOJ
{

    public partial class clsCinetpaytoken
    {
        #region VARIABLES LOCALES

        private string _Apikey;
        private string _Password;
      
      


      #endregion

      #region ACCESSEURS
      public string Apikey
      {
          get { return _Apikey; }
          set { _Apikey = value; }
      }

      public string Password
      {
          get { return _Password; }
          set { _Password = value; }
      }
      

   
      #endregion

       #region INSTANCIATEURS

     public clsCinetpaytoken() { }
		
      public clsCinetpaytoken(clsCinetpaytoken clsCinetpaytoken)
		{
            this.Apikey = clsCinetpaytoken.Apikey;
            this.Password = clsCinetpaytoken.Password;
          
           

           
        }

        #endregion

  }
}
