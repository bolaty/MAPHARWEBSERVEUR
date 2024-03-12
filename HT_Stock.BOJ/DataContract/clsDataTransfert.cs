using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HT_Stock.BOJ
{

    public partial class clsDataTransferts 
  {
        #region VARIABLES LOCALES

        private string _code;
        private string _message;
        private List <clsCinetpayMoneyContac>  _data ;
      


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
      

      public List<clsCinetpayMoneyContac> data
        {
            get { return _data; }
            set { _data = value; }
        }

   
      #endregion

       #region INSTANCIATEURS

     public clsDataTransferts() { }
		
      public clsDataTransferts(clsDataTransferts clsDataTransferts)
		{
            this.code = clsDataTransferts.code;
            this.message = clsDataTransferts.message;
            this.data = clsDataTransferts.data;
           

           
        }

        #endregion

  }
}
