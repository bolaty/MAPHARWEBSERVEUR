using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparstatutsocioprofessionnel : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _ST_CODESTATUTSOCIOPROF = "";
		private string _ST_LIBELLESTATUTSOCIOPROF1 = "";
		private string _ST_ACTIF = "";
		private int _ST_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string ST_CODESTATUTSOCIOPROF
		{
			get { return _ST_CODESTATUTSOCIOPROF; }
			set {  _ST_CODESTATUTSOCIOPROF = value; }
		}

		public string ST_LIBELLESTATUTSOCIOPROF1
		{
			get { return _ST_LIBELLESTATUTSOCIOPROF1; }
			set {  _ST_LIBELLESTATUTSOCIOPROF1 = value; }
		}

		public string ST_ACTIF
		{
			get { return _ST_ACTIF; }
			set {  _ST_ACTIF = value; }
		}

		public int ST_NUMEROORDRE
		{
			get { return _ST_NUMEROORDRE; }
			set {  _ST_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparstatutsocioprofessionnel(){}
		public clsCtparstatutsocioprofessionnel( string ST_CODESTATUTSOCIOPROF,string ST_LIBELLESTATUTSOCIOPROF1,string ST_ACTIF,int ST_NUMEROORDRE)
		{
			this.ST_CODESTATUTSOCIOPROF = ST_CODESTATUTSOCIOPROF;
			this.ST_LIBELLESTATUTSOCIOPROF1 = ST_LIBELLESTATUTSOCIOPROF1;
			this.ST_ACTIF = ST_ACTIF;
			this.ST_NUMEROORDRE = ST_NUMEROORDRE;
		}
		public clsCtparstatutsocioprofessionnel(clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel)
		{
			this.ST_CODESTATUTSOCIOPROF = clsCtparstatutsocioprofessionnel.ST_CODESTATUTSOCIOPROF;
			this.ST_LIBELLESTATUTSOCIOPROF1 = clsCtparstatutsocioprofessionnel.ST_LIBELLESTATUTSOCIOPROF1;
			this.ST_ACTIF = clsCtparstatutsocioprofessionnel.ST_ACTIF;
			this.ST_NUMEROORDRE = clsCtparstatutsocioprofessionnel.ST_NUMEROORDRE;
		}

		#endregion

	}
}
