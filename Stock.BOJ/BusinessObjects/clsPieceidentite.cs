using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPieceidentite
	{
		#region VARIABLES LOCALES

		private string _PI_CODEPIECE = "";
		private string _PI_PIECECODE = "";
		private string _PI_LIBELLEPIECE = "";
		private int _PI_DUREEPIECE = 0;

		#endregion

		#region ACCESSEURS

		public string PI_CODEPIECE
		{
			get { return _PI_CODEPIECE; }
			set {  _PI_CODEPIECE = value; }
		}

		public string PI_PIECECODE
		{
			get { return _PI_PIECECODE; }
			set {  _PI_PIECECODE = value; }
		}

		public string PI_LIBELLEPIECE
		{
			get { return _PI_LIBELLEPIECE; }
			set {  _PI_LIBELLEPIECE = value; }
		}

		public int PI_DUREEPIECE
		{
			get { return _PI_DUREEPIECE; }
			set {  _PI_DUREEPIECE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPieceidentite(){}
		public clsPieceidentite( string PI_CODEPIECE,string PI_PIECECODE,string PI_LIBELLEPIECE,int PI_DUREEPIECE)
		{
			this.PI_CODEPIECE = PI_CODEPIECE;
			this.PI_PIECECODE = PI_PIECECODE;
			this.PI_LIBELLEPIECE = PI_LIBELLEPIECE;
			this.PI_DUREEPIECE = PI_DUREEPIECE;
		}
		public clsPieceidentite(clsPieceidentite clsPieceidentite)
		{
			this.PI_CODEPIECE = clsPieceidentite.PI_CODEPIECE;
			this.PI_PIECECODE = clsPieceidentite.PI_PIECECODE;
			this.PI_LIBELLEPIECE = clsPieceidentite.PI_LIBELLEPIECE;
			this.PI_DUREEPIECE = clsPieceidentite.PI_DUREEPIECE;
		}

		#endregion

	}
}
