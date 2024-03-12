using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsClipartypeantecedant
	{
		#region VARIABLES LOCALES

		private string _TA_CODETYPEANTECEDANT = "";
		private string _TA_LIBELLEANTECEDANT = "";

		#endregion

		#region ACCESSEURS

		public string TA_CODETYPEANTECEDANT
		{
			get { return _TA_CODETYPEANTECEDANT; }
			set {  _TA_CODETYPEANTECEDANT = value; }
		}

		public string TA_LIBELLEANTECEDANT
		{
			get { return _TA_LIBELLEANTECEDANT; }
			set {  _TA_LIBELLEANTECEDANT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClipartypeantecedant(){}
		public clsClipartypeantecedant( string TA_CODETYPEANTECEDANT,string TA_LIBELLEANTECEDANT)
		{
			this.TA_CODETYPEANTECEDANT = TA_CODETYPEANTECEDANT;
			this.TA_LIBELLEANTECEDANT = TA_LIBELLEANTECEDANT;
		}
		public clsClipartypeantecedant(clsClipartypeantecedant clsClipartypeantecedant)
		{
			this.TA_CODETYPEANTECEDANT = clsClipartypeantecedant.TA_CODETYPEANTECEDANT;
			this.TA_LIBELLEANTECEDANT = clsClipartypeantecedant.TA_LIBELLEANTECEDANT;
		}

		#endregion

	}
}
