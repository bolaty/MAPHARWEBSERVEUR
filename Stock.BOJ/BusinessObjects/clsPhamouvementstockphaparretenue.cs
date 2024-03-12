using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockphaparretenue
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _MS_NUMPIECE = "";
		private string _RE_CODERETENUE = "";
		private double _RE_MONTANT = 0;
        private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE = value; }
		}

		public string RE_CODERETENUE
		{
			get { return _RE_CODERETENUE; }
			set {  _RE_CODERETENUE = value; }
		}

		public double RE_MONTANT
		{
			get { return _RE_MONTANT; }
			set {  _RE_MONTANT = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockphaparretenue(){}
		
		public clsPhamouvementstockphaparretenue(clsPhamouvementstockphaparretenue clsPhamouvementstockphaparretenue)
		{
            this.AG_CODEAGENCE = clsPhamouvementstockphaparretenue.AG_CODEAGENCE;
            this.MS_NUMPIECE = clsPhamouvementstockphaparretenue.MS_NUMPIECE;
			this.RE_CODERETENUE = clsPhamouvementstockphaparretenue.RE_CODERETENUE;
			this.RE_MONTANT = clsPhamouvementstockphaparretenue.RE_MONTANT;
            this.OP_CODEOPERATEUR = clsPhamouvementstockphaparretenue.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
