using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsZonevoyage
	{
		#region VARIABLES LOCALES

		private string _ZM_CODEZONEVOYAGE = "";
		private string _ZM_NOMZONEVOYAGE = "";
		private string _ZM_DESCRIPTIONZONEVOYAGE = "";

		#endregion

		#region ACCESSEURS

		public string ZM_CODEZONEVOYAGE
		{
			get { return _ZM_CODEZONEVOYAGE; }
			set {  _ZM_CODEZONEVOYAGE = value; }
		}

		public string ZM_NOMZONEVOYAGE
		{
			get { return _ZM_NOMZONEVOYAGE; }
			set {  _ZM_NOMZONEVOYAGE = value; }
		}

		public string ZM_DESCRIPTIONZONEVOYAGE
		{
			get { return _ZM_DESCRIPTIONZONEVOYAGE; }
			set {  _ZM_DESCRIPTIONZONEVOYAGE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsZonevoyage(){}
		public clsZonevoyage( string ZM_CODEZONEVOYAGE,string ZM_NOMZONEVOYAGE,string ZM_DESCRIPTIONZONEVOYAGE)
		{
			this.ZM_CODEZONEVOYAGE = ZM_CODEZONEVOYAGE;
			this.ZM_NOMZONEVOYAGE = ZM_NOMZONEVOYAGE;
			this.ZM_DESCRIPTIONZONEVOYAGE = ZM_DESCRIPTIONZONEVOYAGE;
		}
		public clsZonevoyage(clsZonevoyage clsZonevoyage)
		{
			this.ZM_CODEZONEVOYAGE = clsZonevoyage.ZM_CODEZONEVOYAGE;
			this.ZM_NOMZONEVOYAGE = clsZonevoyage.ZM_NOMZONEVOYAGE;
			this.ZM_DESCRIPTIONZONEVOYAGE = clsZonevoyage.ZM_DESCRIPTIONZONEVOYAGE;
		}

		#endregion

	}
}
