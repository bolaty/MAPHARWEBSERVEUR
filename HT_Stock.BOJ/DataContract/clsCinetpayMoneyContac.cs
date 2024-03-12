using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace HT_Stock.BOJ
{

    public partial class clsCinetpayMoneyContac 
  {
        #region VARIABLES LOCALES

        private string _prefix;
        private string _phone;
        private string _amount = "";
        private string _notify_url = "";
        private string _client_transaction_id = "";


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


        public string amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string notify_url
        {
            get { return _notify_url; }
            set { _notify_url = value; }
        }


        public string client_transaction_id
        {
            get { return _client_transaction_id; }
            set { _client_transaction_id = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsCinetpayMoneyContac() { }
		
      public clsCinetpayMoneyContac(clsCinetpayMoneyContac clsCinetpayMoneyContac)
		{
            this.prefix = clsCinetpayMoneyContac.prefix;
            this.phone = clsCinetpayMoneyContac.phone;
            this.amount = clsCinetpayMoneyContac.amount;           
            this.notify_url = clsCinetpayMoneyContac.notify_url;
            this.client_transaction_id= clsCinetpayMoneyContac.client_transaction_id;

        }

        #endregion

  }
}
