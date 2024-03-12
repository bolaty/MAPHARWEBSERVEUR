using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliconsultationrendevous
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CO_CODECONSULTATION = "";
		private string _RD_NUMSEQUENCE = "";
		private DateTime _RD_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _TI_IDTIERSMEDECIN = "";
		private string _OP_CODEOPERATEUR = "";
		private string _SR_CODESERVICE = "";
		private DateTime _RD_DATERDV = DateTime.Parse("01/01/1900");
		private DateTime _RD_HEURERDV = DateTime.Parse("01/01/1900");
		private string _RD_MOTIFRDV = "";
		private DateTime _RD_DATEPRESENCERDV = DateTime.Parse("01/01/1900");
		private DateTime _RD_HEUREPRESENCERDV = DateTime.Parse("01/01/1900");

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CO_CODECONSULTATION
		{
			get { return _CO_CODECONSULTATION; }
			set {  _CO_CODECONSULTATION = value; }
		}

		public string RD_NUMSEQUENCE
		{
			get { return _RD_NUMSEQUENCE; }
			set {  _RD_NUMSEQUENCE = value; }
		}

		public DateTime RD_DATESAISIE
		{
			get { return _RD_DATESAISIE; }
			set {  _RD_DATESAISIE = value; }
		}

		public string TI_IDTIERSMEDECIN
		{
			get { return _TI_IDTIERSMEDECIN; }
			set {  _TI_IDTIERSMEDECIN = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public DateTime RD_DATERDV
		{
			get { return _RD_DATERDV; }
			set {  _RD_DATERDV = value; }
		}

		public DateTime RD_HEURERDV
		{
			get { return _RD_HEURERDV; }
			set {  _RD_HEURERDV = value; }
		}

		public string RD_MOTIFRDV
		{
			get { return _RD_MOTIFRDV; }
			set {  _RD_MOTIFRDV = value; }
		}

		public DateTime RD_DATEPRESENCERDV
		{
			get { return _RD_DATEPRESENCERDV; }
			set {  _RD_DATEPRESENCERDV = value; }
		}

		public DateTime RD_HEUREPRESENCERDV
		{
			get { return _RD_HEUREPRESENCERDV; }
			set {  _RD_HEUREPRESENCERDV = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationrendevous(){}
		public clsCliconsultationrendevous( string AG_CODEAGENCE,string CO_CODECONSULTATION,string RD_NUMSEQUENCE,DateTime RD_DATESAISIE,string TI_IDTIERSMEDECIN,string OP_CODEOPERATEUR,string SR_CODESERVICE,DateTime RD_DATERDV,DateTime RD_HEURERDV,string RD_MOTIFRDV,DateTime RD_DATEPRESENCERDV,DateTime RD_HEUREPRESENCERDV)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_CODECONSULTATION = CO_CODECONSULTATION;
			this.RD_NUMSEQUENCE = RD_NUMSEQUENCE;
			this.RD_DATESAISIE = RD_DATESAISIE;
			this.TI_IDTIERSMEDECIN = TI_IDTIERSMEDECIN;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.SR_CODESERVICE = SR_CODESERVICE;
			this.RD_DATERDV = RD_DATERDV;
			this.RD_HEURERDV = RD_HEURERDV;
			this.RD_MOTIFRDV = RD_MOTIFRDV;
			this.RD_DATEPRESENCERDV = RD_DATEPRESENCERDV;
			this.RD_HEUREPRESENCERDV = RD_HEUREPRESENCERDV;
		}
		public clsCliconsultationrendevous(clsCliconsultationrendevous clsCliconsultationrendevous)
		{
			this.AG_CODEAGENCE = clsCliconsultationrendevous.AG_CODEAGENCE;
			this.CO_CODECONSULTATION = clsCliconsultationrendevous.CO_CODECONSULTATION;
			this.RD_NUMSEQUENCE = clsCliconsultationrendevous.RD_NUMSEQUENCE;
			this.RD_DATESAISIE = clsCliconsultationrendevous.RD_DATESAISIE;
			this.TI_IDTIERSMEDECIN = clsCliconsultationrendevous.TI_IDTIERSMEDECIN;
			this.OP_CODEOPERATEUR = clsCliconsultationrendevous.OP_CODEOPERATEUR;
			this.SR_CODESERVICE = clsCliconsultationrendevous.SR_CODESERVICE;
			this.RD_DATERDV = clsCliconsultationrendevous.RD_DATERDV;
			this.RD_HEURERDV = clsCliconsultationrendevous.RD_HEURERDV;
			this.RD_MOTIFRDV = clsCliconsultationrendevous.RD_MOTIFRDV;
			this.RD_DATEPRESENCERDV = clsCliconsultationrendevous.RD_DATEPRESENCERDV;
			this.RD_HEUREPRESENCERDV = clsCliconsultationrendevous.RD_HEUREPRESENCERDV;
		}

		#endregion

	}
}
