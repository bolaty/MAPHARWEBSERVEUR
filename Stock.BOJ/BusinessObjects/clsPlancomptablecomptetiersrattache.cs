using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPlancomptablecomptetiersrattache
	{
		#region VARIABLES LOCALES

		private string _TI_IDTIERS = "";
		private string _PL_CODENUMCOMPTE = "";
		private string _COCHER = "";

		#endregion

		#region ACCESSEURS

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}

		public string COCHER
		{
			get { return _COCHER; }
			set {  _COCHER = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPlancomptablecomptetiersrattache(){}
		public clsPlancomptablecomptetiersrattache( string TI_IDTIERS,string PL_CODENUMCOMPTE,string COCHER)
		{
			this.TI_IDTIERS = TI_IDTIERS;
			this.PL_CODENUMCOMPTE = PL_CODENUMCOMPTE;
			this.COCHER = COCHER;
		}
		public clsPlancomptablecomptetiersrattache(clsPlancomptablecomptetiersrattache clsPlancomptablecomptetiersrattache)
		{
			this.TI_IDTIERS = clsPlancomptablecomptetiersrattache.TI_IDTIERS;
			this.PL_CODENUMCOMPTE = clsPlancomptablecomptetiersrattache.PL_CODENUMCOMPTE;
			this.COCHER = clsPlancomptablecomptetiersrattache.COCHER;
		}

		#endregion

	}
}
