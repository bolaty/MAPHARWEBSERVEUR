using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HT_Stock.BOJ
{

    public partial class clsCinetpayContact 
  {
        #region VARIABLES LOCALES

        private string _prefix;
        private string _phone;
        private string _name = "";
        private string _surname= "";
        private string _email = "";


        #endregion

        #region ACCESSEURS
        public string prefix
      {
          get { return _prefix; }
          set { _prefix = value; }
      }

      public string phone
      {
          get { return _phone; }
          set { _phone = value; }
      }
      

      public string name
        {
            get { return _name; }
            set { _name = value; }
        }

    public string surname
        {
        get { return _surname; }
        set { _surname= value; }
    }


        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsCinetpayContact() { }
		
      public clsCinetpayContact(clsCinetpayContact clsCinetpayContact)
		{
            this.prefix = clsCinetpayContact.prefix;
            this.phone = clsCinetpayContact.phone;
            this.name = clsCinetpayContact.name;
            this.surname = clsCinetpayContact.surname;

           
        }

        #endregion

  }
}
