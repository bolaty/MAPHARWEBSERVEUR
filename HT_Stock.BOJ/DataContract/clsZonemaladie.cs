using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsZonemaladie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _ZM_CODEZONEMALADIE = "";
		private string _ZM_NOMZONEMALADIE = "";
		private string _ZM_DESCRIPTIONZONEMALADIE = "";

		#endregion

		#region ACCESSEURS

		public string ZM_CODEZONEMALADIE
		{
			get { return _ZM_CODEZONEMALADIE; }
			set {  _ZM_CODEZONEMALADIE = value; }
		}

		public string ZM_NOMZONEMALADIE
		{
			get { return _ZM_NOMZONEMALADIE; }
			set {  _ZM_NOMZONEMALADIE = value; }
		}

		public string ZM_DESCRIPTIONZONEMALADIE
		{
			get { return _ZM_DESCRIPTIONZONEMALADIE; }
			set {  _ZM_DESCRIPTIONZONEMALADIE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsZonemaladie(){}
		
		public clsZonemaladie(clsZonemaladie clsZonemaladie)
		{
			this.ZM_CODEZONEMALADIE = clsZonemaladie.ZM_CODEZONEMALADIE;
			this.ZM_NOMZONEMALADIE = clsZonemaladie.ZM_NOMZONEMALADIE;
			this.ZM_DESCRIPTIONZONEMALADIE = clsZonemaladie.ZM_DESCRIPTIONZONEMALADIE;
		}

		#endregion

	}
}
