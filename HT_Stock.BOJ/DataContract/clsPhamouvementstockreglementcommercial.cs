using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhamouvementstockreglementcommercial
	{
		#region VARIABLES LOCALES

		private string _MC_NUMPIECE = "";
		private string _AG_CODEAGENCE = "";
		private string _MR_CODEMODEREGLEMENT = "";
		private string _NO_CODENATUREOPERATION = "";
		private string _MS_NUMPIECE = "";
		private double _MC_MONTANTDEBIT = 0;
		private double _MC_MONTANTCREDIT = 0;
		private DateTime _MC_DATEPIECE = DateTime.Parse("01/01/1900");
		private string _MC_ANNULATIONPIECE = "";
		private string _MC_REFERENCEPIECE = "";
		private string _MC_LIBELLEOPERATION = "";
		private string _MC_NOMTIERS = "";
		private string _CO_IDCOMMERCIAL = "";
		private double _MC_NUMEROPIECE = 0;
		private double _MC_NUMSEQUENCE = 0;
		private string _OP_CODEOPERATEUR = "";

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

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE = value; }
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

		public string CO_IDCOMMERCIAL
		{
			get { return _CO_IDCOMMERCIAL; }
			set {  _CO_IDCOMMERCIAL = value; }
		}

		public double MC_NUMEROPIECE
		{
			get { return _MC_NUMEROPIECE; }
			set {  _MC_NUMEROPIECE = value; }
		}

		public double MC_NUMSEQUENCE
		{
			get { return _MC_NUMSEQUENCE; }
			set {  _MC_NUMSEQUENCE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockreglementcommercial(){}
		public clsPhamouvementstockreglementcommercial( string MC_NUMPIECE,string AG_CODEAGENCE,string MR_CODEMODEREGLEMENT,string NO_CODENATUREOPERATION,string MS_NUMPIECE,double MC_MONTANTDEBIT,double MC_MONTANTCREDIT,DateTime MC_DATEPIECE,string MC_ANNULATIONPIECE,string MC_REFERENCEPIECE,string MC_LIBELLEOPERATION,string MC_NOMTIERS,string CO_IDCOMMERCIAL,double MC_NUMEROPIECE,double MC_NUMSEQUENCE,string OP_CODEOPERATEUR)
		{
			this.MC_NUMPIECE = MC_NUMPIECE;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.MR_CODEMODEREGLEMENT = MR_CODEMODEREGLEMENT;
			this.NO_CODENATUREOPERATION = NO_CODENATUREOPERATION;
			this.MS_NUMPIECE = MS_NUMPIECE;
			this.MC_MONTANTDEBIT = MC_MONTANTDEBIT;
			this.MC_MONTANTCREDIT = MC_MONTANTCREDIT;
			this.MC_DATEPIECE = MC_DATEPIECE;
			this.MC_ANNULATIONPIECE = MC_ANNULATIONPIECE;
			this.MC_REFERENCEPIECE = MC_REFERENCEPIECE;
			this.MC_LIBELLEOPERATION = MC_LIBELLEOPERATION;
			this.MC_NOMTIERS = MC_NOMTIERS;
			this.CO_IDCOMMERCIAL = CO_IDCOMMERCIAL;
			this.MC_NUMEROPIECE = MC_NUMEROPIECE;
			this.MC_NUMSEQUENCE = MC_NUMSEQUENCE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsPhamouvementstockreglementcommercial(clsPhamouvementstockreglementcommercial clsPhamouvementstockreglementcommercial)
		{
			this.MC_NUMPIECE = clsPhamouvementstockreglementcommercial.MC_NUMPIECE;
			this.AG_CODEAGENCE = clsPhamouvementstockreglementcommercial.AG_CODEAGENCE;
			this.MR_CODEMODEREGLEMENT = clsPhamouvementstockreglementcommercial.MR_CODEMODEREGLEMENT;
			this.NO_CODENATUREOPERATION = clsPhamouvementstockreglementcommercial.NO_CODENATUREOPERATION;
			this.MS_NUMPIECE = clsPhamouvementstockreglementcommercial.MS_NUMPIECE;
			this.MC_MONTANTDEBIT = clsPhamouvementstockreglementcommercial.MC_MONTANTDEBIT;
			this.MC_MONTANTCREDIT = clsPhamouvementstockreglementcommercial.MC_MONTANTCREDIT;
			this.MC_DATEPIECE = clsPhamouvementstockreglementcommercial.MC_DATEPIECE;
			this.MC_ANNULATIONPIECE = clsPhamouvementstockreglementcommercial.MC_ANNULATIONPIECE;
			this.MC_REFERENCEPIECE = clsPhamouvementstockreglementcommercial.MC_REFERENCEPIECE;
			this.MC_LIBELLEOPERATION = clsPhamouvementstockreglementcommercial.MC_LIBELLEOPERATION;
			this.MC_NOMTIERS = clsPhamouvementstockreglementcommercial.MC_NOMTIERS;
			this.CO_IDCOMMERCIAL = clsPhamouvementstockreglementcommercial.CO_IDCOMMERCIAL;
			this.MC_NUMEROPIECE = clsPhamouvementstockreglementcommercial.MC_NUMEROPIECE;
			this.MC_NUMSEQUENCE = clsPhamouvementstockreglementcommercial.MC_NUMSEQUENCE;
			this.OP_CODEOPERATEUR = clsPhamouvementstockreglementcommercial.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
