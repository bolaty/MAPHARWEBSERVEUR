using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLettrage
	{
		#region VARIABLES LOCALES

		private int _LT_CODELETTRAGE = 0;
		private string _LT_LIBELLELETTRAGE = "";

		#endregion

		#region ACCESSEURS

		public int LT_CODELETTRAGE
		{
			get { return _LT_CODELETTRAGE; }
			set {  _LT_CODELETTRAGE = value; }
		}

		public string LT_LIBELLELETTRAGE
		{
			get { return _LT_LIBELLELETTRAGE; }
			set {  _LT_LIBELLELETTRAGE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsLettrage(){}
		public clsLettrage( int LT_CODELETTRAGE,string LT_LIBELLELETTRAGE)
		{
			this.LT_CODELETTRAGE = LT_CODELETTRAGE;
			this.LT_LIBELLELETTRAGE = LT_LIBELLELETTRAGE;
		}
		public clsLettrage(clsLettrage clsLettrage)
		{
			this.LT_CODELETTRAGE = clsLettrage.LT_CODELETTRAGE;
			this.LT_LIBELLELETTRAGE = clsLettrage.LT_LIBELLELETTRAGE;
		}

		#endregion

	}
}
