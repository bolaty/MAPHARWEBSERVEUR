using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparnaturesinistre : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _NS_CODENATURESINISTRE = "";
		private string _NS_LIBELLENATURESINISTRE = "";
		private string _NS_ACTIF = "";
		private string _NS_NUMEROORDRE = "0";

		#endregion

		#region ACCESSEURS

		public string NS_CODENATURESINISTRE
		{
			get { return _NS_CODENATURESINISTRE; }
			set {  _NS_CODENATURESINISTRE = value; }
		}

		public string NS_LIBELLENATURESINISTRE
		{
			get { return _NS_LIBELLENATURESINISTRE; }
			set {  _NS_LIBELLENATURESINISTRE = value; }
		}

		public string NS_ACTIF
		{
			get { return _NS_ACTIF; }
			set {  _NS_ACTIF = value; }
		}

		public string NS_NUMEROORDRE
		{
			get { return _NS_NUMEROORDRE; }
			set {  _NS_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparnaturesinistre(){}
		
		public clsCtparnaturesinistre(clsCtparnaturesinistre clsCtparnaturesinistre)
		{
			this.NS_CODENATURESINISTRE = clsCtparnaturesinistre.NS_CODENATURESINISTRE;
			this.NS_LIBELLENATURESINISTRE = clsCtparnaturesinistre.NS_LIBELLENATURESINISTRE;
			this.NS_ACTIF = clsCtparnaturesinistre.NS_ACTIF;
			this.NS_NUMEROORDRE = clsCtparnaturesinistre.NS_NUMEROORDRE;
		}

		#endregion

	}
}
