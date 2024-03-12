using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsLogicielobjetweb
	{
		#region VARIABLES LOCALES

		private string _OT_CODETYPEOBJET = "";
		private string _OB_CODEOBJET = "";
		private string _OB_NOMOBJET = "";
		private string _LO_CODELOGICIEL = "";
		private string _OB_LIBELLE = "";
		private string _OB_STATUT = "";
		private int _OB_RATTACHEA = 0;

		#endregion

		#region ACCESSEURS

		public string OT_CODETYPEOBJET
		{
			get { return _OT_CODETYPEOBJET; }
			set {  _OT_CODETYPEOBJET = value; }
		}

		public string OB_CODEOBJET
		{
			get { return _OB_CODEOBJET; }
			set {  _OB_CODEOBJET = value; }
		}

		public string OB_NOMOBJET
		{
			get { return _OB_NOMOBJET; }
			set {  _OB_NOMOBJET = value; }
		}

		public string LO_CODELOGICIEL
		{
			get { return _LO_CODELOGICIEL; }
			set {  _LO_CODELOGICIEL = value; }
		}

		public string OB_LIBELLE
		{
			get { return _OB_LIBELLE; }
			set {  _OB_LIBELLE = value; }
		}

		public string OB_STATUT
		{
			get { return _OB_STATUT; }
			set {  _OB_STATUT = value; }
		}

		public int OB_RATTACHEA
		{
			get { return _OB_RATTACHEA; }
			set {  _OB_RATTACHEA = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsLogicielobjetweb(){}
		public clsLogicielobjetweb( string OT_CODETYPEOBJET,string OB_CODEOBJET,string OB_NOMOBJET,string LO_CODELOGICIEL,string OB_LIBELLE,string OB_STATUT,int OB_RATTACHEA)
		{
			this.OT_CODETYPEOBJET = OT_CODETYPEOBJET;
			this.OB_CODEOBJET = OB_CODEOBJET;
			this.OB_NOMOBJET = OB_NOMOBJET;
			this.LO_CODELOGICIEL = LO_CODELOGICIEL;
			this.OB_LIBELLE = OB_LIBELLE;
			this.OB_STATUT = OB_STATUT;
			this.OB_RATTACHEA = OB_RATTACHEA;
		}
		public clsLogicielobjetweb(clsLogicielobjetweb clsLogicielobjetweb)
		{
			this.OT_CODETYPEOBJET = clsLogicielobjetweb.OT_CODETYPEOBJET;
			this.OB_CODEOBJET = clsLogicielobjetweb.OB_CODEOBJET;
			this.OB_NOMOBJET = clsLogicielobjetweb.OB_NOMOBJET;
			this.LO_CODELOGICIEL = clsLogicielobjetweb.LO_CODELOGICIEL;
			this.OB_LIBELLE = clsLogicielobjetweb.OB_LIBELLE;
			this.OB_STATUT = clsLogicielobjetweb.OB_STATUT;
			this.OB_RATTACHEA = clsLogicielobjetweb.OB_RATTACHEA;
		}

		#endregion

	}
}
