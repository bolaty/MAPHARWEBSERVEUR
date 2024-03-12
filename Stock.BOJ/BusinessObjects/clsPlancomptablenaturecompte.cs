using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPlancomptablenaturecompte
	{
		#region VARIABLES LOCALES

		private string _NC_CODENATURECOMPTE = "";
		private string _NC_LIBELLENATURECOMPTE = "";
		private int _NC_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string NC_CODENATURECOMPTE
		{
			get { return _NC_CODENATURECOMPTE; }
			set {  _NC_CODENATURECOMPTE = value; }
		}

		public string NC_LIBELLENATURECOMPTE
		{
			get { return _NC_LIBELLENATURECOMPTE; }
			set {  _NC_LIBELLENATURECOMPTE = value; }
		}

		public int NC_NUMEROORDRE
		{
			get { return _NC_NUMEROORDRE; }
			set {  _NC_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPlancomptablenaturecompte(){}
		public clsPlancomptablenaturecompte( string NC_CODENATURECOMPTE,string NC_LIBELLENATURECOMPTE,int NC_NUMEROORDRE)
		{
			this.NC_CODENATURECOMPTE = NC_CODENATURECOMPTE;
			this.NC_LIBELLENATURECOMPTE = NC_LIBELLENATURECOMPTE;
			this.NC_NUMEROORDRE = NC_NUMEROORDRE;
		}
		public clsPlancomptablenaturecompte(clsPlancomptablenaturecompte clsPlancomptablenaturecompte)
		{
			this.NC_CODENATURECOMPTE = clsPlancomptablenaturecompte.NC_CODENATURECOMPTE;
			this.NC_LIBELLENATURECOMPTE = clsPlancomptablenaturecompte.NC_LIBELLENATURECOMPTE;
			this.NC_NUMEROORDRE = clsPlancomptablenaturecompte.NC_NUMEROORDRE;
		}

		#endregion

	}
}
