using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparnaturesinistre
	{
		#region VARIABLES LOCALES

		private string _NS_CODENATURESINISTRE = "";
		private string _NS_LIBELLENATURESINISTRE = "";
		private string _NS_ACTIF = "";
		private int _NS_NUMEROORDRE = 0;

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

		public int NS_NUMEROORDRE
		{
			get { return _NS_NUMEROORDRE; }
			set {  _NS_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparnaturesinistre(){}
		public clsCtparnaturesinistre( string NS_CODENATURESINISTRE,string NS_LIBELLENATURESINISTRE,string NS_ACTIF,int NS_NUMEROORDRE)
		{
			this.NS_CODENATURESINISTRE = NS_CODENATURESINISTRE;
			this.NS_LIBELLENATURESINISTRE = NS_LIBELLENATURESINISTRE;
			this.NS_ACTIF = NS_ACTIF;
			this.NS_NUMEROORDRE = NS_NUMEROORDRE;
		}
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
