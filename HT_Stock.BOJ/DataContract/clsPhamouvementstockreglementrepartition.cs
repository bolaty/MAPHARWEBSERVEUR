using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhamouvementstockreglementrepartition
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
        private DateTime _RP_DATEREPARTION =DateTime.Parse("01/01/1900");
		private string _MV_NUMPIECE = "";
		private string _TA_CODETYPEARTICLE = "";
		private string _NA_CODENATUREOPERATION = "";
		private double _RP_MONTANTDEBIT = 0;
		private double _RP_MONTANTCREDIT = 0;
		private string _RP_ANNULATIONPIECE = "";

		#endregion

		#region ACCESSEURS

        //private string _AG_CODEAGENCE = "";
        //private DateTime _RP_DATEREPARTION = DateTime.Parse("01/01/1900");

        public string AG_CODEAGENCE
		{
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
		}
        public DateTime RP_DATEREPARTION 
        {
            get { return _RP_DATEREPARTION; }
            set { _RP_DATEREPARTION = value; }
        }

		public string MV_NUMPIECE
		{
			get { return _MV_NUMPIECE; }
			set {  _MV_NUMPIECE = value; }
		}

		public string TA_CODETYPEARTICLE
		{
			get { return _TA_CODETYPEARTICLE; }
			set {  _TA_CODETYPEARTICLE = value; }
		}

		public string NA_CODENATUREOPERATION
		{
			get { return _NA_CODENATUREOPERATION; }
			set {  _NA_CODENATUREOPERATION = value; }
		}

		public double RP_MONTANTDEBIT
		{
			get { return _RP_MONTANTDEBIT; }
			set {  _RP_MONTANTDEBIT = value; }
		}

		public double RP_MONTANTCREDIT
		{
			get { return _RP_MONTANTCREDIT; }
			set {  _RP_MONTANTCREDIT = value; }
		}

		public string RP_ANNULATIONPIECE
		{
			get { return _RP_ANNULATIONPIECE; }
			set {  _RP_ANNULATIONPIECE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockreglementrepartition(){}
		
		public clsPhamouvementstockreglementrepartition(clsPhamouvementstockreglementrepartition clsPhamouvementstockreglementrepartition)
		{

            

            this.AG_CODEAGENCE = clsPhamouvementstockreglementrepartition.AG_CODEAGENCE;
            this.RP_DATEREPARTION = clsPhamouvementstockreglementrepartition.RP_DATEREPARTION;
			this.MV_NUMPIECE = clsPhamouvementstockreglementrepartition.MV_NUMPIECE;
			this.TA_CODETYPEARTICLE = clsPhamouvementstockreglementrepartition.TA_CODETYPEARTICLE;
			this.NA_CODENATUREOPERATION = clsPhamouvementstockreglementrepartition.NA_CODENATUREOPERATION;
			this.RP_MONTANTDEBIT = clsPhamouvementstockreglementrepartition.RP_MONTANTDEBIT;
			this.RP_MONTANTCREDIT = clsPhamouvementstockreglementrepartition.RP_MONTANTCREDIT;
			this.RP_ANNULATIONPIECE = clsPhamouvementstockreglementrepartition.RP_ANNULATIONPIECE;
		}

		#endregion

	}
}
