using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhapartypepneu
	{
		#region VARIABLES LOCALES

		private string _TP_CODETYPEPNEU = "";
		private string _TP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TP_CODETYPEPNEU
		{
			get { return _TP_CODETYPEPNEU; }
			set {  _TP_CODETYPEPNEU = value; }
		}

		public string TP_LIBELLE
		{
			get { return _TP_LIBELLE; }
			set {  _TP_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypepneu(){}
		public clsPhapartypepneu( string TP_CODETYPEPNEU,string TP_LIBELLE)
		{
			this.TP_CODETYPEPNEU = TP_CODETYPEPNEU;
			this.TP_LIBELLE = TP_LIBELLE;
		}
		public clsPhapartypepneu(clsPhapartypepneu clsPhapartypepneu)
		{
			this.TP_CODETYPEPNEU = clsPhapartypepneu.TP_CODETYPEPNEU;
			this.TP_LIBELLE = clsPhapartypepneu.TP_LIBELLE;
		}

		#endregion

	}
}
