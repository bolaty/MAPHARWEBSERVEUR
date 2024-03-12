using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhamouvementstockcommandefacture
	{
		#region VARIABLES LOCALES

        private string _MC_NUMPIECE = "";
		private string _AG_CODEAGENCE = "";
		private string _MR_CODEMODEREGLEMENT = "";
		private string _NO_CODENATUREOPERATION = "";
		private string _MK_NUMPIECE = "";
		private double _MC_MONTANTDEBIT = 0;
		private double _MC_MONTANTCREDIT = 0;
		private DateTime _MC_DATEPIECE = DateTime.Parse("01/01/1900");
		private string _MC_ANNULATIONPIECE = "";
		private string _MC_REFERENCEPIECE = "";
		private string _MC_LIBELLEOPERATION = "";
		private string _MC_NOMTIERS = "";
        private string _TYPEOPERATION = "";
        private string _MC_NUMEROPIECE = "";
		#endregion

		#region ACCESSEURS

        public string MC_NUMPIECE
		{
			get { return _MC_NUMPIECE; }
			set {  _MC_NUMPIECE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string MR_CODEMODEREGLEMENT
		{
			get { return _MR_CODEMODEREGLEMENT; }
			set {  _MR_CODEMODEREGLEMENT = value; }
		}

		public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set {  _NO_CODENATUREOPERATION = value; }
		}

		public string MK_NUMPIECE
		{
			get { return _MK_NUMPIECE; }
			set {  _MK_NUMPIECE = value; }
		}

		public double MC_MONTANTDEBIT
		{
			get { return _MC_MONTANTDEBIT; }
			set {  _MC_MONTANTDEBIT = value; }
		}

		public double MC_MONTANTCREDIT
		{
			get { return _MC_MONTANTCREDIT; }
			set {  _MC_MONTANTCREDIT = value; }
		}

		public DateTime MC_DATEPIECE
		{
			get { return _MC_DATEPIECE; }
			set {  _MC_DATEPIECE = value; }
		}

		public string MC_ANNULATIONPIECE
		{
			get { return _MC_ANNULATIONPIECE; }
			set {  _MC_ANNULATIONPIECE = value; }
		}

		public string MC_REFERENCEPIECE
		{
			get { return _MC_REFERENCEPIECE; }
			set {  _MC_REFERENCEPIECE = value; }
		}

		public string MC_LIBELLEOPERATION
		{
			get { return _MC_LIBELLEOPERATION; }
			set {  _MC_LIBELLEOPERATION = value; }
		}

		public string MC_NOMTIERS
		{
			get { return _MC_NOMTIERS; }
			set {  _MC_NOMTIERS = value; }
		}
        public string TYPEOPERATION
		{
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
		}

        public string MC_NUMEROPIECE 
		{
            get { return _MC_NUMEROPIECE; }
            set { _MC_NUMEROPIECE = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockcommandefacture(){}
		
		public clsPhamouvementstockcommandefacture(clsPhamouvementstockcommandefacture clsPhamouvementstockcommandefacture)
		{
			this.MC_NUMPIECE = clsPhamouvementstockcommandefacture.MC_NUMPIECE;
			this.AG_CODEAGENCE = clsPhamouvementstockcommandefacture.AG_CODEAGENCE;
			this.MR_CODEMODEREGLEMENT = clsPhamouvementstockcommandefacture.MR_CODEMODEREGLEMENT;
			this.NO_CODENATUREOPERATION = clsPhamouvementstockcommandefacture.NO_CODENATUREOPERATION;
			this.MK_NUMPIECE = clsPhamouvementstockcommandefacture.MK_NUMPIECE;
			this.MC_MONTANTDEBIT = clsPhamouvementstockcommandefacture.MC_MONTANTDEBIT;
			this.MC_MONTANTCREDIT = clsPhamouvementstockcommandefacture.MC_MONTANTCREDIT;
			this.MC_DATEPIECE = clsPhamouvementstockcommandefacture.MC_DATEPIECE;
			this.MC_ANNULATIONPIECE = clsPhamouvementstockcommandefacture.MC_ANNULATIONPIECE;
			this.MC_REFERENCEPIECE = clsPhamouvementstockcommandefacture.MC_REFERENCEPIECE;
			this.MC_LIBELLEOPERATION = clsPhamouvementstockcommandefacture.MC_LIBELLEOPERATION;
			this.MC_NOMTIERS = clsPhamouvementstockcommandefacture.MC_NOMTIERS;
            this.TYPEOPERATION = clsPhamouvementstockcommandefacture.TYPEOPERATION;
            this.MC_NUMEROPIECE = clsPhamouvementstockcommandefacture.MC_NUMEROPIECE;


		}

		#endregion

	}
}
