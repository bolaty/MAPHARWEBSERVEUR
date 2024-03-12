using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsBusinessplanparamdocumentdetail
	{
		#region VARIABLES LOCALES

		private string _PD_CODEDOCUMENTDETAIL = "";
		private string _PB_CODEDOCUMENT = "";
		private string _PP_CODEPOLICE = "";
		private string _PC_CODECOULEUR = "";
		private string _PF_CODEFORMULE = "";
		private string _PA_CODEDOCUMENTDETAILFAMILLE = "";
		private string _PD_LIBELLE = "";
		private int _PD_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string PD_CODEDOCUMENTDETAIL
		{
			get { return _PD_CODEDOCUMENTDETAIL; }
			set {  _PD_CODEDOCUMENTDETAIL = value; }
		}

		public string PB_CODEDOCUMENT
		{
			get { return _PB_CODEDOCUMENT; }
			set {  _PB_CODEDOCUMENT = value; }
		}

		public string PP_CODEPOLICE
		{
			get { return _PP_CODEPOLICE; }
			set {  _PP_CODEPOLICE = value; }
		}

		public string PC_CODECOULEUR
		{
			get { return _PC_CODECOULEUR; }
			set {  _PC_CODECOULEUR = value; }
		}

		public string PF_CODEFORMULE
		{
			get { return _PF_CODEFORMULE; }
			set {  _PF_CODEFORMULE = value; }
		}

		public string PA_CODEDOCUMENTDETAILFAMILLE
		{
			get { return _PA_CODEDOCUMENTDETAILFAMILLE; }
			set {  _PA_CODEDOCUMENTDETAILFAMILLE = value; }
		}

		public string PD_LIBELLE
		{
			get { return _PD_LIBELLE; }
			set {  _PD_LIBELLE = value; }
		}

		public int PD_NUMEROORDRE
		{
			get { return _PD_NUMEROORDRE; }
			set {  _PD_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamdocumentdetail(){}
		public clsBusinessplanparamdocumentdetail( string PD_CODEDOCUMENTDETAIL,string PB_CODEDOCUMENT,string PP_CODEPOLICE,string PC_CODECOULEUR,string PF_CODEFORMULE,string PA_CODEDOCUMENTDETAILFAMILLE,string PD_LIBELLE,int PD_NUMEROORDRE)
		{
			this.PD_CODEDOCUMENTDETAIL = PD_CODEDOCUMENTDETAIL;
			this.PB_CODEDOCUMENT = PB_CODEDOCUMENT;
			this.PP_CODEPOLICE = PP_CODEPOLICE;
			this.PC_CODECOULEUR = PC_CODECOULEUR;
			this.PF_CODEFORMULE = PF_CODEFORMULE;
			this.PA_CODEDOCUMENTDETAILFAMILLE = PA_CODEDOCUMENTDETAILFAMILLE;
			this.PD_LIBELLE = PD_LIBELLE;
			this.PD_NUMEROORDRE = PD_NUMEROORDRE;
		}
		public clsBusinessplanparamdocumentdetail(clsBusinessplanparamdocumentdetail clsBusinessplanparamdocumentdetail)
		{
			this.PD_CODEDOCUMENTDETAIL = clsBusinessplanparamdocumentdetail.PD_CODEDOCUMENTDETAIL;
			this.PB_CODEDOCUMENT = clsBusinessplanparamdocumentdetail.PB_CODEDOCUMENT;
			this.PP_CODEPOLICE = clsBusinessplanparamdocumentdetail.PP_CODEPOLICE;
			this.PC_CODECOULEUR = clsBusinessplanparamdocumentdetail.PC_CODECOULEUR;
			this.PF_CODEFORMULE = clsBusinessplanparamdocumentdetail.PF_CODEFORMULE;
			this.PA_CODEDOCUMENTDETAILFAMILLE = clsBusinessplanparamdocumentdetail.PA_CODEDOCUMENTDETAILFAMILLE;
			this.PD_LIBELLE = clsBusinessplanparamdocumentdetail.PD_LIBELLE;
			this.PD_NUMEROORDRE = clsBusinessplanparamdocumentdetail.PD_NUMEROORDRE;
		}

		#endregion

	}
}
