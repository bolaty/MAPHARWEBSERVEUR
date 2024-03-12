using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparusageauto
	{
		#region VARIABLES LOCALES

		private string _US_CODEUSAGE = "";
		private string _US_LIBELLEUSAGE = "";
		private string _US_ACTIF = "";
		private int _US_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string US_CODEUSAGE
		{
			get { return _US_CODEUSAGE; }
			set {  _US_CODEUSAGE = value; }
		}

		public string US_LIBELLEUSAGE
		{
			get { return _US_LIBELLEUSAGE; }
			set {  _US_LIBELLEUSAGE = value; }
		}

		public string US_ACTIF
		{
			get { return _US_ACTIF; }
			set {  _US_ACTIF = value; }
		}

		public int US_NUMEROORDRE
		{
			get { return _US_NUMEROORDRE; }
			set {  _US_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparusageauto(){}
		public clsCtparusageauto( string US_CODEUSAGE,string US_LIBELLEUSAGE,string US_ACTIF,int US_NUMEROORDRE)
		{
			this.US_CODEUSAGE = US_CODEUSAGE;
			this.US_LIBELLEUSAGE = US_LIBELLEUSAGE;
			this.US_ACTIF = US_ACTIF;
			this.US_NUMEROORDRE = US_NUMEROORDRE;
		}
		public clsCtparusageauto(clsCtparusageauto clsCtparusageauto)
		{
			this.US_CODEUSAGE = clsCtparusageauto.US_CODEUSAGE;
			this.US_LIBELLEUSAGE = clsCtparusageauto.US_LIBELLEUSAGE;
			this.US_ACTIF = clsCtparusageauto.US_ACTIF;
			this.US_NUMEROORDRE = clsCtparusageauto.US_NUMEROORDRE;
		}

		#endregion

	}
}
