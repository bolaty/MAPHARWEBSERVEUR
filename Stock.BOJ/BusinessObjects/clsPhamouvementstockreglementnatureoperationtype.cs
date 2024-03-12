using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockreglementnatureoperationtype
	{
		#region VARIABLES LOCALES

		private string _RO_CODENATUREOPERATIONTYPE = "";
		private string _RO_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string RO_CODENATUREOPERATIONTYPE
		{
			get { return _RO_CODENATUREOPERATIONTYPE; }
			set {  _RO_CODENATUREOPERATIONTYPE = value; }
		}

		public string RO_LIBELLE
		{
			get { return _RO_LIBELLE; }
			set {  _RO_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockreglementnatureoperationtype(){}
		public clsPhamouvementstockreglementnatureoperationtype( string RO_CODENATUREOPERATIONTYPE,string RO_LIBELLE)
		{
			this.RO_CODENATUREOPERATIONTYPE = RO_CODENATUREOPERATIONTYPE;
			this.RO_LIBELLE = RO_LIBELLE;
		}
		public clsPhamouvementstockreglementnatureoperationtype(clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype)
		{
			this.RO_CODENATUREOPERATIONTYPE = clsPhamouvementstockreglementnatureoperationtype.RO_CODENATUREOPERATIONTYPE;
			this.RO_LIBELLE = clsPhamouvementstockreglementnatureoperationtype.RO_LIBELLE;
		}

		#endregion

	}
}
