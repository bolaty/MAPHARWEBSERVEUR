using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratrendezvousclient
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _RD_INDEXRENDEZVOUS = "";
		private DateTime _RD_DATESAISIERENDEZVOUS = DateTime.Parse("01/01/1900");
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private DateTime _RD_DATERENDEZVOUS = DateTime.Parse("01/01/1900");
		private string _RD_OBJETRENDEZVOUS = "";
		private string _OP_CODEOPERATEUR = "";
		private string _TYPEOPERATION = "";
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string RD_INDEXRENDEZVOUS
		{
			get { return _RD_INDEXRENDEZVOUS; }
			set {  _RD_INDEXRENDEZVOUS = value; }
		}

		public DateTime RD_DATESAISIERENDEZVOUS
		{
			get { return _RD_DATESAISIERENDEZVOUS; }
			set {  _RD_DATESAISIERENDEZVOUS = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public DateTime RD_DATERENDEZVOUS
		{
			get { return _RD_DATERENDEZVOUS; }
			set {  _RD_DATERENDEZVOUS = value; }
		}

		public string RD_OBJETRENDEZVOUS
		{
			get { return _RD_OBJETRENDEZVOUS; }
			set {  _RD_OBJETRENDEZVOUS = value; }
		}

        public string OP_CODEOPERATEUR
        {
	        get { return _OP_CODEOPERATEUR; }
	        set { _OP_CODEOPERATEUR = value; }
        }

        public string TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratrendezvousclient(){}
		
		public clsCtcontratrendezvousclient(clsCtcontratrendezvousclient clsCtcontratrendezvousclient)
		{
			this.AG_CODEAGENCE = clsCtcontratrendezvousclient.AG_CODEAGENCE;
			this.RD_INDEXRENDEZVOUS = clsCtcontratrendezvousclient.RD_INDEXRENDEZVOUS;
			this.RD_DATESAISIERENDEZVOUS = clsCtcontratrendezvousclient.RD_DATESAISIERENDEZVOUS;
			this.EN_CODEENTREPOT = clsCtcontratrendezvousclient.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratrendezvousclient.CA_CODECONTRAT;
			this.RD_DATERENDEZVOUS = clsCtcontratrendezvousclient.RD_DATERENDEZVOUS;
			this.RD_OBJETRENDEZVOUS = clsCtcontratrendezvousclient.RD_OBJETRENDEZVOUS;
			this.OP_CODEOPERATEUR = clsCtcontratrendezvousclient.OP_CODEOPERATEUR;
			this.TYPEOPERATION = clsCtcontratrendezvousclient.TYPEOPERATION;

		}

		#endregion

	}
}
