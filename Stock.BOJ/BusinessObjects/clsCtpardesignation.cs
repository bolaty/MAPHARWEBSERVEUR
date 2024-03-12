using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpardesignation
	{
		#region VARIABLES LOCALES

		private string _DI_CODEDESIGNATION = "";
		private string _DI_LIBELLEDESIGNATION = "";
		private int _DI_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string DI_CODEDESIGNATION
		{
			get { return _DI_CODEDESIGNATION; }
			set {  _DI_CODEDESIGNATION = value; }
		}

		public string DI_LIBELLEDESIGNATION
		{
			get { return _DI_LIBELLEDESIGNATION; }
			set {  _DI_LIBELLEDESIGNATION = value; }
		}

		public int DI_NUMEROORDRE
		{
			get { return _DI_NUMEROORDRE; }
			set {  _DI_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpardesignation(){}
		public clsCtpardesignation( string DI_CODEDESIGNATION,string DI_LIBELLEDESIGNATION,int DI_NUMEROORDRE)
		{
			this.DI_CODEDESIGNATION = DI_CODEDESIGNATION;
			this.DI_LIBELLEDESIGNATION = DI_LIBELLEDESIGNATION;
			this.DI_NUMEROORDRE = DI_NUMEROORDRE;
		}
		public clsCtpardesignation(clsCtpardesignation clsCtpardesignation)
		{
			this.DI_CODEDESIGNATION = clsCtpardesignation.DI_CODEDESIGNATION;
			this.DI_LIBELLEDESIGNATION = clsCtpardesignation.DI_LIBELLEDESIGNATION;
			this.DI_NUMEROORDRE = clsCtpardesignation.DI_NUMEROORDRE;
		}

		#endregion

	}
}
