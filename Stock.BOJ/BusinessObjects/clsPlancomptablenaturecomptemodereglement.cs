using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPlancomptablenaturecomptemodereglement
	{
		#region VARIABLES LOCALES

		private string _MR_CODEMODEREGLEMENT = "";
		private string _NC_CODENATURECOMPTE = "";

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


		#endregion

		#region INSTANCIATEURS

		public clsPlancomptablenaturecomptemodereglement(){}
		public clsPlancomptablenaturecomptemodereglement( string MR_CODEMODEREGLEMENT,string NC_CODENATURECOMPTE)
		{
			this.MR_CODEMODEREGLEMENT = MR_CODEMODEREGLEMENT;
			this.NC_CODENATURECOMPTE = NC_CODENATURECOMPTE;
		}
		public clsPlancomptablenaturecomptemodereglement(clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement)
		{
			this.MR_CODEMODEREGLEMENT = clsPlancomptablenaturecomptemodereglement.MR_CODEMODEREGLEMENT;
			this.NC_CODENATURECOMPTE = clsPlancomptablenaturecomptemodereglement.NC_CODENATURECOMPTE;
		}

		#endregion

	}
}
