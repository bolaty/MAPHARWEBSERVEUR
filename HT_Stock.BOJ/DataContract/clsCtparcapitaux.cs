using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparcapitaux
	{
		#region VARIABLES LOCALES

		private string _CP_CODECAPITAUX = "";
		private string _CP_LIBELLECAPITAUX = "";
		private string _CP_ACTIF = "";
		private int _CP_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string CP_CODECAPITAUX
		{
			get { return _CP_CODECAPITAUX; }
			set {  _CP_CODECAPITAUX = value; }
		}

		public string CP_LIBELLECAPITAUX
		{
			get { return _CP_LIBELLECAPITAUX; }
			set {  _CP_LIBELLECAPITAUX = value; }
		}

		public string CP_ACTIF
		{
			get { return _CP_ACTIF; }
			set {  _CP_ACTIF = value; }
		}

		public int CP_NUMEROORDRE
		{
			get { return _CP_NUMEROORDRE; }
			set {  _CP_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparcapitaux(){}
		public clsCtparcapitaux( string CP_CODECAPITAUX,string CP_LIBELLECAPITAUX,string CP_ACTIF,int CP_NUMEROORDRE)
		{
			this.CP_CODECAPITAUX = CP_CODECAPITAUX;
			this.CP_LIBELLECAPITAUX = CP_LIBELLECAPITAUX;
			this.CP_ACTIF = CP_ACTIF;
			this.CP_NUMEROORDRE = CP_NUMEROORDRE;
		}
		public clsCtparcapitaux(clsCtparcapitaux clsCtparcapitaux)
		{
			this.CP_CODECAPITAUX = clsCtparcapitaux.CP_CODECAPITAUX;
			this.CP_LIBELLECAPITAUX = clsCtparcapitaux.CP_LIBELLECAPITAUX;
			this.CP_ACTIF = clsCtparcapitaux.CP_ACTIF;
			this.CP_NUMEROORDRE = clsCtparcapitaux.CP_NUMEROORDRE;
		}

		#endregion

	}
}
