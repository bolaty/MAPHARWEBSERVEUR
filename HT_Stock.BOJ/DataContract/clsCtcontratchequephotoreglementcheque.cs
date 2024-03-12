using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratchequephotoreglementcaisse : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CHC_DATESAISIECHEQUE = "";
		private string _CHC_IDEXCHEQUE = "";
		private string _CHC_NUMSEQUENCEPHOTO = "";
		private string _CHC_CHEMINPHOTOCHEQUE = "";
		private string _CHC_LIBELLEPHOTOCHEQUE = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CHC_DATESAISIECHEQUE
		{
			get { return _CHC_DATESAISIECHEQUE; }
			set {  _CHC_DATESAISIECHEQUE = value; }
		}

		public string CHC_IDEXCHEQUE
		{
			get { return _CHC_IDEXCHEQUE; }
			set {  _CHC_IDEXCHEQUE = value; }
		}

		public string CHC_NUMSEQUENCEPHOTO
		{
			get { return _CHC_NUMSEQUENCEPHOTO; }
			set {  _CHC_NUMSEQUENCEPHOTO = value; }
		}

		public string CHC_CHEMINPHOTOCHEQUE
		{
			get { return _CHC_CHEMINPHOTOCHEQUE; }
			set {  _CHC_CHEMINPHOTOCHEQUE = value; }
		}

		public string CHC_LIBELLEPHOTOCHEQUE
		{
			get { return _CHC_LIBELLEPHOTOCHEQUE; }
			set {  _CHC_LIBELLEPHOTOCHEQUE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratchequephotoreglementcaisse(){}

		public clsCtcontratchequephotoreglementcaisse(clsCtcontratchequephotoreglementcaisse clsCtcontratchequephotoreglementcaisse)
		{
			this.AG_CODEAGENCE = clsCtcontratchequephotoreglementcaisse.AG_CODEAGENCE;
			this.CHC_DATESAISIECHEQUE = clsCtcontratchequephotoreglementcaisse.CHC_DATESAISIECHEQUE;
			this.CHC_IDEXCHEQUE = clsCtcontratchequephotoreglementcaisse.CHC_IDEXCHEQUE;
			this.CHC_NUMSEQUENCEPHOTO = clsCtcontratchequephotoreglementcaisse.CHC_NUMSEQUENCEPHOTO;
			this.CHC_CHEMINPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisse.CHC_CHEMINPHOTOCHEQUE;
			this.CHC_LIBELLEPHOTOCHEQUE = clsCtcontratchequephotoreglementcaisse.CHC_LIBELLEPHOTOCHEQUE;
		}

		#endregion

	}
}
