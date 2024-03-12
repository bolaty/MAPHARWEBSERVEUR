using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockphaparqualite
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _MS_NUMPIECE = "";
		private string _QT_CODEQUALITE = "";
		private double _QT_MONTANT = 0;
		private string _QT_DESCRIPTION = "";
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

		public string QT_CODEQUALITE
		{
			get { return _QT_CODEQUALITE; }
			set {  _QT_CODEQUALITE = value; }
		}

		public double QT_MONTANT
		{
			get { return _QT_MONTANT; }
			set {  _QT_MONTANT = value; }
		}

		public string QT_DESCRIPTION
		{
			get { return _QT_DESCRIPTION; }
			set {  _QT_DESCRIPTION = value; }
		}
        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockphaparqualite(){}
		
		public clsPhamouvementstockphaparqualite(clsPhamouvementstockphaparqualite clsPhamouvementstockphaparqualite)
		{
            this.AG_CODEAGENCE = clsPhamouvementstockphaparqualite.AG_CODEAGENCE;
			this.MS_NUMPIECE = clsPhamouvementstockphaparqualite.MS_NUMPIECE;
			this.QT_CODEQUALITE = clsPhamouvementstockphaparqualite.QT_CODEQUALITE;
			this.QT_MONTANT = clsPhamouvementstockphaparqualite.QT_MONTANT;
			this.QT_DESCRIPTION = clsPhamouvementstockphaparqualite.QT_DESCRIPTION;
            this.OP_CODEOPERATEUR = clsPhamouvementstockphaparqualite.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
