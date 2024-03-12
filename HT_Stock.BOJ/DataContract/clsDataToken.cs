using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HT_Stock.BOJ
{

    public partial class clsDataToken 
  {
        #region VARIABLES LOCALES

        private string _token;
        //private string _Message;
        //private string _Data = "";
      


      #endregion

      #region ACCESSEURS
      public string token
      {
          get { return _token; }
          set { _token = value; }
      }

      //public string Message
      //{
      //    get { return _Message; }
      //    set { _Message = value; }
      //}
      

      //public string Data
      //  {
      //      get { return _Data; }
      //      set { _Data = value; }
      //  }

   
      #endregion

       #region INSTANCIATEURS

     public clsDataToken() { }
		
      public clsDataToken(clsDataToken clsDataToken)
		{
            this.token = clsDataToken.token;
            //this.Message = clsCinetpay.Message;
            //this.Data = clsCinetpay.Data;
           

           
        }

        #endregion

  }
}
