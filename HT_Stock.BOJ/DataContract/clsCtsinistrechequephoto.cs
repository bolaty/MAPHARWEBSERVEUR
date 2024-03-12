using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtsinistrechequephoto : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CH_DATESAISIECHEQUE = "";
		private string _CH_IDEXCHEQUE = "";
		private string _CH_NUMSEQUENCEPHOTO = "";
		private string _CH_CHEMINPHOTOCHEQUE = "";
		private string _CH_LIBELLEPHOTOCHEQUE = "";
		private string _CA_CODECONTRAT = "";
		private string _SI_CODESINISTRE = "";
		private string _OP_CODEOPERATEUR = "";
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CH_DATESAISIECHEQUE
		{
			get { return _CH_DATESAISIECHEQUE; }
			set {  _CH_DATESAISIECHEQUE = value; }
		}

		public string CH_IDEXCHEQUE
		{
			get { return _CH_IDEXCHEQUE; }
			set {  _CH_IDEXCHEQUE = value; }
		}

		public string CH_NUMSEQUENCEPHOTO
		{
			get { return _CH_NUMSEQUENCEPHOTO; }
			set {  _CH_NUMSEQUENCEPHOTO = value; }
		}

		public string CH_CHEMINPHOTOCHEQUE
		{
			get { return _CH_CHEMINPHOTOCHEQUE; }
			set {  _CH_CHEMINPHOTOCHEQUE = value; }
		}

		public string CH_LIBELLEPHOTOCHEQUE
		{
			get { return _CH_LIBELLEPHOTOCHEQUE; }
			set {  _CH_LIBELLEPHOTOCHEQUE = value; }
		}
		public string CA_CODECONTRAT
        {
			get { return _CA_CODECONTRAT; }
			set { _CA_CODECONTRAT = value; }
		}
		public string SI_CODESINISTRE
        {
			get { return _SI_CODESINISTRE; }
			set { _SI_CODESINISTRE = value; }
		}
        public string OP_CODEOPERATEUR
        {
	        get { return _OP_CODEOPERATEUR; }
	        set { _OP_CODEOPERATEUR = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsCtsinistrechequephoto(){}

		public clsCtsinistrechequephoto(clsCtsinistrechequephoto clsCtsinistrechequephoto)
		{
			this.AG_CODEAGENCE = clsCtsinistrechequephoto.AG_CODEAGENCE;
			this.CH_DATESAISIECHEQUE = clsCtsinistrechequephoto.CH_DATESAISIECHEQUE;
			this.CH_IDEXCHEQUE = clsCtsinistrechequephoto.CH_IDEXCHEQUE;
			this.CH_NUMSEQUENCEPHOTO = clsCtsinistrechequephoto.CH_NUMSEQUENCEPHOTO;
			this.CH_CHEMINPHOTOCHEQUE = clsCtsinistrechequephoto.CH_CHEMINPHOTOCHEQUE;
			this.CH_LIBELLEPHOTOCHEQUE = clsCtsinistrechequephoto.CH_LIBELLEPHOTOCHEQUE;
			this.CA_CODECONTRAT = clsCtsinistrechequephoto.CA_CODECONTRAT;
			this.SI_CODESINISTRE = clsCtsinistrechequephoto.SI_CODESINISTRE;
			this.OP_CODEOPERATEUR = clsCtsinistrechequephoto.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
