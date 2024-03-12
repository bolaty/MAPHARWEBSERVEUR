using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparcategorieordonnance
	{
		#region VARIABLES LOCALES

		private string _CT_CODECATEGORIEORDONNANCE = "";
		private string _CT_LIBELLECATEGORIE = "";

		#endregion

		#region ACCESSEURS

		public string CT_CODECATEGORIEORDONNANCE
		{
			get { return _CT_CODECATEGORIEORDONNANCE; }
			set {  _CT_CODECATEGORIEORDONNANCE = value; }
		}

		public string CT_LIBELLECATEGORIE
		{
			get { return _CT_LIBELLECATEGORIE; }
			set {  _CT_LIBELLECATEGORIE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparcategorieordonnance(){}
		public clsCliparcategorieordonnance( string CT_CODECATEGORIEORDONNANCE,string CT_LIBELLECATEGORIE)
		{
			this.CT_CODECATEGORIEORDONNANCE = CT_CODECATEGORIEORDONNANCE;
			this.CT_LIBELLECATEGORIE = CT_LIBELLECATEGORIE;
		}
		public clsCliparcategorieordonnance(clsCliparcategorieordonnance clsCliparcategorieordonnance)
		{
			this.CT_CODECATEGORIEORDONNANCE = clsCliparcategorieordonnance.CT_CODECATEGORIEORDONNANCE;
			this.CT_LIBELLECATEGORIE = clsCliparcategorieordonnance.CT_LIBELLECATEGORIE;
		}

		#endregion

	}
}
