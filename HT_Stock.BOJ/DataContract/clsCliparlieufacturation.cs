using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCliparlieufacturation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _LF_CODELIEUFACTURATION = "";
		private string _LF_LIBELLELIEUFACTURATION = "";
		private string _LF_ACTIF = "";
		private int _LF_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string LF_CODELIEUFACTURATION
		{
			get { return _LF_CODELIEUFACTURATION; }
			set {  _LF_CODELIEUFACTURATION = value; }
		}

		public string LF_LIBELLELIEUFACTURATION
		{
			get { return _LF_LIBELLELIEUFACTURATION; }
			set {  _LF_LIBELLELIEUFACTURATION = value; }
		}

		public string LF_ACTIF
		{
			get { return _LF_ACTIF; }
			set {  _LF_ACTIF = value; }
		}

		public int LF_NUMEROORDRE
		{
			get { return _LF_NUMEROORDRE; }
			set {  _LF_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparlieufacturation(){}
		public clsCliparlieufacturation( string LF_CODELIEUFACTURATION,string LF_LIBELLELIEUFACTURATION,string LF_ACTIF,int LF_NUMEROORDRE)
		{
			this.LF_CODELIEUFACTURATION = LF_CODELIEUFACTURATION;
			this.LF_LIBELLELIEUFACTURATION = LF_LIBELLELIEUFACTURATION;
			this.LF_ACTIF = LF_ACTIF;
			this.LF_NUMEROORDRE = LF_NUMEROORDRE;
		}
		public clsCliparlieufacturation(clsCliparlieufacturation clsCliparlieufacturation)
		{
			this.LF_CODELIEUFACTURATION = clsCliparlieufacturation.LF_CODELIEUFACTURATION;
			this.LF_LIBELLELIEUFACTURATION = clsCliparlieufacturation.LF_LIBELLELIEUFACTURATION;
			this.LF_ACTIF = clsCliparlieufacturation.LF_ACTIF;
			this.LF_NUMEROORDRE = clsCliparlieufacturation.LF_NUMEROORDRE;
		}

		#endregion

	}
}
