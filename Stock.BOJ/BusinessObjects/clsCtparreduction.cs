using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparreduction
	{
		#region VARIABLES LOCALES

		private string _RD_CODEREDUCTION = "";
		private string _RD_LIBELLEREDUCTION = "";
		private string _RD_ACTIF = "";
		private int _RD_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string RD_CODEREDUCTION
		{
			get { return _RD_CODEREDUCTION; }
			set {  _RD_CODEREDUCTION = value; }
		}

		public string RD_LIBELLEREDUCTION
		{
			get { return _RD_LIBELLEREDUCTION; }
			set {  _RD_LIBELLEREDUCTION = value; }
		}

		public string RD_ACTIF
		{
			get { return _RD_ACTIF; }
			set {  _RD_ACTIF = value; }
		}

		public int RD_NUMEROORDRE
		{
			get { return _RD_NUMEROORDRE; }
			set {  _RD_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparreduction(){}
		public clsCtparreduction( string RD_CODEREDUCTION,string RD_LIBELLEREDUCTION,string RD_ACTIF,int RD_NUMEROORDRE)
		{
			this.RD_CODEREDUCTION = RD_CODEREDUCTION;
			this.RD_LIBELLEREDUCTION = RD_LIBELLEREDUCTION;
			this.RD_ACTIF = RD_ACTIF;
			this.RD_NUMEROORDRE = RD_NUMEROORDRE;
		}
		public clsCtparreduction(clsCtparreduction clsCtparreduction)
		{
			this.RD_CODEREDUCTION = clsCtparreduction.RD_CODEREDUCTION;
			this.RD_LIBELLEREDUCTION = clsCtparreduction.RD_LIBELLEREDUCTION;
			this.RD_ACTIF = clsCtparreduction.RD_ACTIF;
			this.RD_NUMEROORDRE = clsCtparreduction.RD_NUMEROORDRE;
		}

		#endregion

	}
}
