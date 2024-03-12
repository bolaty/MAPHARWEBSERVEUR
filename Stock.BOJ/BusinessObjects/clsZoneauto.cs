using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsZoneauto
	{
		#region VARIABLES LOCALES

		private string _ZA_CODEZONEAUTO = "";
		private string _ZA_NOMZONEAUTO = "";
		private string _ZA_DESCRIPTIONZONEAUTO = "";

		#endregion

		#region ACCESSEURS

		public string ZA_CODEZONEAUTO
		{
			get { return _ZA_CODEZONEAUTO; }
			set {  _ZA_CODEZONEAUTO = value; }
		}

		public string ZA_NOMZONEAUTO
		{
			get { return _ZA_NOMZONEAUTO; }
			set {  _ZA_NOMZONEAUTO = value; }
		}

		public string ZA_DESCRIPTIONZONEAUTO
		{
			get { return _ZA_DESCRIPTIONZONEAUTO; }
			set {  _ZA_DESCRIPTIONZONEAUTO = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsZoneauto(){}
		public clsZoneauto( string ZA_CODEZONEAUTO,string ZA_NOMZONEAUTO,string ZA_DESCRIPTIONZONEAUTO)
		{
			this.ZA_CODEZONEAUTO = ZA_CODEZONEAUTO;
			this.ZA_NOMZONEAUTO = ZA_NOMZONEAUTO;
			this.ZA_DESCRIPTIONZONEAUTO = ZA_DESCRIPTIONZONEAUTO;
		}
		public clsZoneauto(clsZoneauto clsZoneauto)
		{
			this.ZA_CODEZONEAUTO = clsZoneauto.ZA_CODEZONEAUTO;
			this.ZA_NOMZONEAUTO = clsZoneauto.ZA_NOMZONEAUTO;
			this.ZA_DESCRIPTIONZONEAUTO = clsZoneauto.ZA_DESCRIPTIONZONEAUTO;
		}

		#endregion

	}
}
