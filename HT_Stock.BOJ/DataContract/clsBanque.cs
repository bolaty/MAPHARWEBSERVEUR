using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsBanque : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _BQ_CODEBANQUE = "";
		private string _BQ_BANQUECODE = "";
		private string _BQ_RAISONSOCIAL = "";
		private string _BQ_SIGLE = "";

		#endregion

		#region ACCESSEURS

		public string BQ_CODEBANQUE
		{
			get { return _BQ_CODEBANQUE; }
			set {  _BQ_CODEBANQUE = value; }
		}

		public string BQ_BANQUECODE
		{
			get { return _BQ_BANQUECODE; }
			set {  _BQ_BANQUECODE = value; }
		}

		public string BQ_RAISONSOCIAL
		{
			get { return _BQ_RAISONSOCIAL; }
			set {  _BQ_RAISONSOCIAL = value; }
		}

		public string BQ_SIGLE
		{
			get { return _BQ_SIGLE; }
			set {  _BQ_SIGLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBanque(){}
		
		public clsBanque(clsBanque clsBanque)
		{
			this.BQ_CODEBANQUE = clsBanque.BQ_CODEBANQUE;
			this.BQ_BANQUECODE = clsBanque.BQ_BANQUECODE;
			this.BQ_RAISONSOCIAL = clsBanque.BQ_RAISONSOCIAL;
			this.BQ_SIGLE = clsBanque.BQ_SIGLE;
		}

		#endregion

	}
}
