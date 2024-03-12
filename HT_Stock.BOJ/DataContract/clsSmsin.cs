using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsSmsin
	{
		#region VARIABLES LOCALES

		private DateTime _ST_DATEPIECE = DateTime.Parse("01/01/1900");
		private string _ST_NUMPIECE = "";
		private string _ST_NUMSEQUENCE = "";
		private string _NUMEROCOMPTE = "";
		private string _TE_CODESMSTYPEOPERATION = "";
		private string _ST_LOGIN = "";
		private string _ST_MOTPASSE = "";
        private string _ST_EMETTEUR = "";

		#endregion

		#region ACCESSEURS

		public DateTime ST_DATEPIECE
		{
			get { return _ST_DATEPIECE; }
			set {  _ST_DATEPIECE = value; }
		}

		public string ST_NUMPIECE
		{
			get { return _ST_NUMPIECE; }
			set {  _ST_NUMPIECE = value; }
		}

		public string ST_NUMSEQUENCE
		{
			get { return _ST_NUMSEQUENCE; }
			set {  _ST_NUMSEQUENCE = value; }
		}

		public string NUMEROCOMPTE
		{
			get { return _NUMEROCOMPTE; }
			set {  _NUMEROCOMPTE = value; }
		}

		public string TE_CODESMSTYPEOPERATION
		{
			get { return _TE_CODESMSTYPEOPERATION; }
			set {  _TE_CODESMSTYPEOPERATION = value; }
		}

		public string ST_LOGIN
		{
			get { return _ST_LOGIN; }
			set {  _ST_LOGIN = value; }
		}

		public string ST_MOTPASSE
		{
			get { return _ST_MOTPASSE; }
			set {  _ST_MOTPASSE = value; }
		}

        public string ST_EMETTEUR
		{
            get { return _ST_EMETTEUR; }
            set { _ST_EMETTEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsSmsin(){}
		public clsSmsin(clsSmsin clsSmsin)
		{
			this.ST_DATEPIECE = clsSmsin.ST_DATEPIECE;
			this.ST_NUMPIECE = clsSmsin.ST_NUMPIECE;
			this.ST_NUMSEQUENCE = clsSmsin.ST_NUMSEQUENCE;
			this.NUMEROCOMPTE = clsSmsin.NUMEROCOMPTE;
			this.TE_CODESMSTYPEOPERATION = clsSmsin.TE_CODESMSTYPEOPERATION;
			this.ST_LOGIN = clsSmsin.ST_LOGIN;
			this.ST_MOTPASSE = clsSmsin.ST_MOTPASSE;
            this.ST_EMETTEUR = clsSmsin.ST_EMETTEUR;
		}

		#endregion

	}
}
