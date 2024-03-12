using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HT_Stock.BOJ
{

    public partial class clsDataContact 
  {
        #region VARIABLES LOCALES

        private string _code;
        private string _message;
        private List <clsCinetpayContact>  _data ;
      


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
      

      public List<clsCinetpayContact> data
        {
            get { return _data; }
            set { _data = value; }
        }

   
      #endregion

       #region INSTANCIATEURS

     public clsDataContact() { }
		
      public clsDataContact(clsDataContact clsDataContact)
		{
            this.code = clsDataContact.code;
            this.message = clsDataContact.message;
            this.data = clsDataContact.data;
           

           
        }

        #endregion

  }
}
