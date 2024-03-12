using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsBusinessplanparamposte
	{
		#region VARIABLES LOCALES

		private string _PO_CODEPOSTEBUSINESSPLAN = "";
		private string _PD_CODEDOCUMENTDETAIL = "";
		private string _PN_CODENATUREPOSTEBUSINESSPLAN = "";
		private string _PP_CODEPOLICE = "";
		private string _PS_CODESIGNE = "";
		private decimal _PO_TAUX = 0;
		private string _PO_LIBELLE = "";
		private int _PO_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string PO_CODEPOSTEBUSINESSPLAN
		{
			get { return _PO_CODEPOSTEBUSINESSPLAN; }
			set {  _PO_CODEPOSTEBUSINESSPLAN = value; }
		}

		public string PD_CODEDOCUMENTDETAIL
		{
			get { return _PD_CODEDOCUMENTDETAIL; }
			set {  _PD_CODEDOCUMENTDETAIL = value; }
		}

		public string PN_CODENATUREPOSTEBUSINESSPLAN
		{
			get { return _PN_CODENATUREPOSTEBUSINESSPLAN; }
			set {  _PN_CODENATUREPOSTEBUSINESSPLAN = value; }
		}

		public string PP_CODEPOLICE
		{
			get { return _PP_CODEPOLICE; }
			set {  _PP_CODEPOLICE = value; }
		}

		public string PS_CODESIGNE
		{
			get { return _PS_CODESIGNE; }
			set {  _PS_CODESIGNE = value; }
		}

		public decimal PO_TAUX
		{
			get { return _PO_TAUX; }
			set {  _PO_TAUX = value; }
		}

		public string PO_LIBELLE
		{
			get { return _PO_LIBELLE; }
			set {  _PO_LIBELLE = value; }
		}

		public int PO_NUMEROORDRE
		{
			get { return _PO_NUMEROORDRE; }
			set {  _PO_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamposte(){}
		public clsBusinessplanparamposte( string PO_CODEPOSTEBUSINESSPLAN,string PD_CODEDOCUMENTDETAIL,string PN_CODENATUREPOSTEBUSINESSPLAN,string PP_CODEPOLICE,string PS_CODESIGNE,decimal PO_TAUX,string PO_LIBELLE,int PO_NUMEROORDRE)
		{
			this.PO_CODEPOSTEBUSINESSPLAN = PO_CODEPOSTEBUSINESSPLAN;
			this.PD_CODEDOCUMENTDETAIL = PD_CODEDOCUMENTDETAIL;
			this.PN_CODENATUREPOSTEBUSINESSPLAN = PN_CODENATUREPOSTEBUSINESSPLAN;
			this.PP_CODEPOLICE = PP_CODEPOLICE;
			this.PS_CODESIGNE = PS_CODESIGNE;
			this.PO_TAUX = PO_TAUX;
			this.PO_LIBELLE = PO_LIBELLE;
			this.PO_NUMEROORDRE = PO_NUMEROORDRE;
		}
		public clsBusinessplanparamposte(clsBusinessplanparamposte clsBusinessplanparamposte)
		{
			this.PO_CODEPOSTEBUSINESSPLAN = clsBusinessplanparamposte.PO_CODEPOSTEBUSINESSPLAN;
			this.PD_CODEDOCUMENTDETAIL = clsBusinessplanparamposte.PD_CODEDOCUMENTDETAIL;
			this.PN_CODENATUREPOSTEBUSINESSPLAN = clsBusinessplanparamposte.PN_CODENATUREPOSTEBUSINESSPLAN;
			this.PP_CODEPOLICE = clsBusinessplanparamposte.PP_CODEPOLICE;
			this.PS_CODESIGNE = clsBusinessplanparamposte.PS_CODESIGNE;
			this.PO_TAUX = clsBusinessplanparamposte.PO_TAUX;
			this.PO_LIBELLE = clsBusinessplanparamposte.PO_LIBELLE;
			this.PO_NUMEROORDRE = clsBusinessplanparamposte.PO_NUMEROORDRE;
		}

		#endregion

	}
}
