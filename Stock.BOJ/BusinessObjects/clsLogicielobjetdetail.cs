using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLogicielobjetdetail
	{
		#region VARIABLES LOCALES

		private string _OB_CODEOBJET = "";
		private string _OP_CODEOBJET = "";
		private string _OP_NOMOBJET = "";
		private string _LO_CODELOGICIEL = "";
		private string _OT_CODETYPEOBJET = "";
		private string _OP_LIBELLE = "";
		private string _OP_STATUT = "";
		private string _OP_RATTACHEA = "";

		#endregion

		#region ACCESSEURS

		public string OB_CODEOBJET
		{
			get { return _OB_CODEOBJET; }
			set {  _OB_CODEOBJET = value; }
		}

		public string OP_CODEOBJET
		{
			get { return _OP_CODEOBJET; }
			set {  _OP_CODEOBJET = value; }
		}

		public string OP_NOMOBJET
		{
			get { return _OP_NOMOBJET; }
			set {  _OP_NOMOBJET = value; }
		}

		public string LO_CODELOGICIEL
		{
			get { return _LO_CODELOGICIEL; }
			set {  _LO_CODELOGICIEL = value; }
		}

		public string OT_CODETYPEOBJET
		{
			get { return _OT_CODETYPEOBJET; }
			set {  _OT_CODETYPEOBJET = value; }
		}

		public string OP_LIBELLE
		{
			get { return _OP_LIBELLE; }
			set {  _OP_LIBELLE = value; }
		}

		public string OP_STATUT
		{
			get { return _OP_STATUT; }
			set {  _OP_STATUT = value; }
		}

		public string OP_RATTACHEA
		{
			get { return _OP_RATTACHEA; }
			set {  _OP_RATTACHEA = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsLogicielobjetdetail(){}
		public clsLogicielobjetdetail( string OB_CODEOBJET,string OP_CODEOBJET,string OP_NOMOBJET,string LO_CODELOGICIEL,string OT_CODETYPEOBJET,string OP_LIBELLE,string OP_STATUT,string OP_RATTACHEA)
		{
			this.OB_CODEOBJET = OB_CODEOBJET;
			this.OP_CODEOBJET = OP_CODEOBJET;
			this.OP_NOMOBJET = OP_NOMOBJET;
			this.LO_CODELOGICIEL = LO_CODELOGICIEL;
			this.OT_CODETYPEOBJET = OT_CODETYPEOBJET;
			this.OP_LIBELLE = OP_LIBELLE;
			this.OP_STATUT = OP_STATUT;
			this.OP_RATTACHEA = OP_RATTACHEA;
		}
		public clsLogicielobjetdetail(clsLogicielobjetdetail clsLogicielobjetdetail)
		{
			this.OB_CODEOBJET = clsLogicielobjetdetail.OB_CODEOBJET;
			this.OP_CODEOBJET = clsLogicielobjetdetail.OP_CODEOBJET;
			this.OP_NOMOBJET = clsLogicielobjetdetail.OP_NOMOBJET;
			this.LO_CODELOGICIEL = clsLogicielobjetdetail.LO_CODELOGICIEL;
			this.OT_CODETYPEOBJET = clsLogicielobjetdetail.OT_CODETYPEOBJET;
			this.OP_LIBELLE = clsLogicielobjetdetail.OP_LIBELLE;
			this.OP_STATUT = clsLogicielobjetdetail.OP_STATUT;
			this.OP_RATTACHEA = clsLogicielobjetdetail.OP_RATTACHEA;
		}

		#endregion

	}
}
