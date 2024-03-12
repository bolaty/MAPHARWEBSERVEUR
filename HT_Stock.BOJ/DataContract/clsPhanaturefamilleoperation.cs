using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhanaturefamilleoperation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _NF_CODENATUREFAMILLEOPERATION = "";
		private string _NF_LIBELLENATUREFAMILLEOPERATION1 = "";

		#endregion

		#region ACCESSEURS

		public string NF_CODENATUREFAMILLEOPERATION
		{
			get { return _NF_CODENATUREFAMILLEOPERATION; }
			set {  _NF_CODENATUREFAMILLEOPERATION = value; }
		}

		public string NF_LIBELLENATUREFAMILLEOPERATION1
		{
			get { return _NF_LIBELLENATUREFAMILLEOPERATION1; }
			set {  _NF_LIBELLENATUREFAMILLEOPERATION1 = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhanaturefamilleoperation(){}
		public clsPhanaturefamilleoperation( string NF_CODENATUREFAMILLEOPERATION,string NF_LIBELLENATUREFAMILLEOPERATION1)
		{
			this.NF_CODENATUREFAMILLEOPERATION = NF_CODENATUREFAMILLEOPERATION;
			this.NF_LIBELLENATUREFAMILLEOPERATION1 = NF_LIBELLENATUREFAMILLEOPERATION1;
		}
		public clsPhanaturefamilleoperation(clsPhanaturefamilleoperation clsPhanaturefamilleoperation)
		{
			this.NF_CODENATUREFAMILLEOPERATION = clsPhanaturefamilleoperation.NF_CODENATUREFAMILLEOPERATION;
			this.NF_LIBELLENATUREFAMILLEOPERATION1 = clsPhanaturefamilleoperation.NF_LIBELLENATUREFAMILLEOPERATION1;
		}

		#endregion

	}
}
