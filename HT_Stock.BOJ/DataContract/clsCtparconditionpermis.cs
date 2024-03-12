using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparconditionpermis : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _CD_CODECONDITION = "";
		private string _CD_LIBELLECONDITION = "";
		private string _CD_ACTIF = "";
		private int _CD_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string CD_CODECONDITION
		{
			get { return _CD_CODECONDITION; }
			set {  _CD_CODECONDITION = value; }
		}

		public string CD_LIBELLECONDITION
		{
			get { return _CD_LIBELLECONDITION; }
			set {  _CD_LIBELLECONDITION = value; }
		}

		public string CD_ACTIF
		{
			get { return _CD_ACTIF; }
			set {  _CD_ACTIF = value; }
		}

		public int CD_NUMEROORDRE
		{
			get { return _CD_NUMEROORDRE; }
			set {  _CD_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparconditionpermis(){}
		public clsCtparconditionpermis( string CD_CODECONDITION,string CD_LIBELLECONDITION,string CD_ACTIF,int CD_NUMEROORDRE)
		{
			this.CD_CODECONDITION = CD_CODECONDITION;
			this.CD_LIBELLECONDITION = CD_LIBELLECONDITION;
			this.CD_ACTIF = CD_ACTIF;
			this.CD_NUMEROORDRE = CD_NUMEROORDRE;
		}
		public clsCtparconditionpermis(clsCtparconditionpermis clsCtparconditionpermis)
		{
			this.CD_CODECONDITION = clsCtparconditionpermis.CD_CODECONDITION;
			this.CD_LIBELLECONDITION = clsCtparconditionpermis.CD_LIBELLECONDITION;
			this.CD_ACTIF = clsCtparconditionpermis.CD_ACTIF;
			this.CD_NUMEROORDRE = clsCtparconditionpermis.CD_NUMEROORDRE;
		}

		#endregion

	}
}
