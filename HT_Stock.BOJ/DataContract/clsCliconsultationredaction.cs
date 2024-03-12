using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliconsultationredaction
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CO_CODECONSULTATION = "";
		private string _RE_NUMSEQUENCE = "";
		private DateTime _RE_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _TL_CODETYPEREDACTION = "";
		private string _OP_CODEOPERATEUR = "";
		private string _TI_IDTIERSMEDECINEMETTEURE = "";
		private string _TI_IDTIERSMEDECINDESTINATAIRE = "";
		private string _RE_LIBELLEREDACTION = "";

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

		public string RE_NUMSEQUENCE
		{
			get { return _RE_NUMSEQUENCE; }
			set {  _RE_NUMSEQUENCE = value; }
		}

		public DateTime RE_DATESAISIE
		{
			get { return _RE_DATESAISIE; }
			set {  _RE_DATESAISIE = value; }
		}

		public string TL_CODETYPEREDACTION
		{
			get { return _TL_CODETYPEREDACTION; }
			set {  _TL_CODETYPEREDACTION = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string TI_IDTIERSMEDECINEMETTEURE
		{
			get { return _TI_IDTIERSMEDECINEMETTEURE; }
			set {  _TI_IDTIERSMEDECINEMETTEURE = value; }
		}

		public string TI_IDTIERSMEDECINDESTINATAIRE
		{
			get { return _TI_IDTIERSMEDECINDESTINATAIRE; }
			set {  _TI_IDTIERSMEDECINDESTINATAIRE = value; }
		}

		public string RE_LIBELLEREDACTION
		{
			get { return _RE_LIBELLEREDACTION; }
			set {  _RE_LIBELLEREDACTION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationredaction(){}
		public clsCliconsultationredaction( string AG_CODEAGENCE,string CO_CODECONSULTATION,string RE_NUMSEQUENCE,DateTime RE_DATESAISIE,string TL_CODETYPEREDACTION,string OP_CODEOPERATEUR,string TI_IDTIERSMEDECINEMETTEURE,string TI_IDTIERSMEDECINDESTINATAIRE,string RE_LIBELLEREDACTION)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_CODECONSULTATION = CO_CODECONSULTATION;
			this.RE_NUMSEQUENCE = RE_NUMSEQUENCE;
			this.RE_DATESAISIE = RE_DATESAISIE;
			this.TL_CODETYPEREDACTION = TL_CODETYPEREDACTION;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.TI_IDTIERSMEDECINEMETTEURE = TI_IDTIERSMEDECINEMETTEURE;
			this.TI_IDTIERSMEDECINDESTINATAIRE = TI_IDTIERSMEDECINDESTINATAIRE;
			this.RE_LIBELLEREDACTION = RE_LIBELLEREDACTION;
		}
		public clsCliconsultationredaction(clsCliconsultationredaction clsCliconsultationredaction)
		{
			this.AG_CODEAGENCE = clsCliconsultationredaction.AG_CODEAGENCE;
			this.CO_CODECONSULTATION = clsCliconsultationredaction.CO_CODECONSULTATION;
			this.RE_NUMSEQUENCE = clsCliconsultationredaction.RE_NUMSEQUENCE;
			this.RE_DATESAISIE = clsCliconsultationredaction.RE_DATESAISIE;
			this.TL_CODETYPEREDACTION = clsCliconsultationredaction.TL_CODETYPEREDACTION;
			this.OP_CODEOPERATEUR = clsCliconsultationredaction.OP_CODEOPERATEUR;
			this.TI_IDTIERSMEDECINEMETTEURE = clsCliconsultationredaction.TI_IDTIERSMEDECINEMETTEURE;
			this.TI_IDTIERSMEDECINDESTINATAIRE = clsCliconsultationredaction.TI_IDTIERSMEDECINDESTINATAIRE;
			this.RE_LIBELLEREDACTION = clsCliconsultationredaction.RE_LIBELLEREDACTION;
		}

		#endregion

	}
}
