using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPlancomptablenaturecomptemodereglement : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _MR_CODEMODEREGLEMENT = "";
		private string _NC_CODENATURECOMPTE = "";
		private string _NC_LIBELLENATURECOMPTE = "";
		#endregion

		#region ACCESSEURS

		public string MR_CODEMODEREGLEMENT
		{
			get { return _MR_CODEMODEREGLEMENT; }
			set {  _MR_CODEMODEREGLEMENT = value; }
		}

		public string NC_CODENATURECOMPTE
		{
			get { return _NC_CODENATURECOMPTE; }
			set {  _NC_CODENATURECOMPTE = value; }
		}
		public string NC_LIBELLENATURECOMPTE
        {
			get { return _NC_LIBELLENATURECOMPTE; }
			set { _NC_LIBELLENATURECOMPTE = value; }
		}



		#endregion

		#region INSTANCIATEURS

		public clsPlancomptablenaturecomptemodereglement(){}

		public clsPlancomptablenaturecomptemodereglement(clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement)
		{
			this.MR_CODEMODEREGLEMENT = clsPlancomptablenaturecomptemodereglement.MR_CODEMODEREGLEMENT;
			this.NC_CODENATURECOMPTE = clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE;
			this.NC_LIBELLENATURECOMPTE = clsPlancomptablenaturecomptemodereglement.NC_LIBELLENATURECOMPTE;
		}

		#endregion

	}
}
