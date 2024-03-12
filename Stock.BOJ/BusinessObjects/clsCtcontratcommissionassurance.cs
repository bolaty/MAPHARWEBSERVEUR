using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratcommissionassurance
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private DateTime _CM_DATEPIECE = DateTime.Parse("01/01/1900");
		private string _CM_NUMPIECE = "";
		private string _CM_NUMSEQUENCE = "";
		private string _CM_REFERENCEPIECE = "";
		private string _CA_CODECONTRAT = "";
		private string _CM_LIBELLEOPERATION = "";
		private double _CM_MONTANTDEBIT = 0;
		private double _CM_MONTANTCREDIT = 0;
		private string _CM_ANNULER = "";
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public DateTime CM_DATEPIECE
		{
			get { return _CM_DATEPIECE; }
			set {  _CM_DATEPIECE = value; }
		}

		public string CM_NUMPIECE
		{
			get { return _CM_NUMPIECE; }
			set {  _CM_NUMPIECE = value; }
		}

		public string CM_NUMSEQUENCE
		{
			get { return _CM_NUMSEQUENCE; }
			set {  _CM_NUMSEQUENCE = value; }
		}

		public string CM_REFERENCEPIECE
		{
			get { return _CM_REFERENCEPIECE; }
			set {  _CM_REFERENCEPIECE = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string CM_LIBELLEOPERATION
		{
			get { return _CM_LIBELLEOPERATION; }
			set {  _CM_LIBELLEOPERATION = value; }
		}

		public double CM_MONTANTDEBIT
		{
			get { return _CM_MONTANTDEBIT; }
			set {  _CM_MONTANTDEBIT = value; }
		}

		public double CM_MONTANTCREDIT
		{
			get { return _CM_MONTANTCREDIT; }
			set {  _CM_MONTANTCREDIT = value; }
		}

		public string CM_ANNULER
		{
			get { return _CM_ANNULER; }
			set {  _CM_ANNULER = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratcommissionassurance(){}
		public clsCtcontratcommissionassurance( string AG_CODEAGENCE,string EN_CODEENTREPOT,DateTime CM_DATEPIECE,string CM_NUMPIECE,string CM_NUMSEQUENCE,string CM_REFERENCEPIECE,string CA_CODECONTRAT,string CM_LIBELLEOPERATION,double CM_MONTANTDEBIT,double CM_MONTANTCREDIT,string CM_ANNULER,string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
			this.CM_DATEPIECE = CM_DATEPIECE;
			this.CM_NUMPIECE = CM_NUMPIECE;
			this.CM_NUMSEQUENCE = CM_NUMSEQUENCE;
			this.CM_REFERENCEPIECE = CM_REFERENCEPIECE;
			this.CA_CODECONTRAT = CA_CODECONTRAT;
			this.CM_LIBELLEOPERATION = CM_LIBELLEOPERATION;
			this.CM_MONTANTDEBIT = CM_MONTANTDEBIT;
			this.CM_MONTANTCREDIT = CM_MONTANTCREDIT;
			this.CM_ANNULER = CM_ANNULER;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsCtcontratcommissionassurance(clsCtcontratcommissionassurance clsCtcontratcommissionassurance)
		{
			this.AG_CODEAGENCE = clsCtcontratcommissionassurance.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratcommissionassurance.EN_CODEENTREPOT;
			this.CM_DATEPIECE = clsCtcontratcommissionassurance.CM_DATEPIECE;
			this.CM_NUMPIECE = clsCtcontratcommissionassurance.CM_NUMPIECE;
			this.CM_NUMSEQUENCE = clsCtcontratcommissionassurance.CM_NUMSEQUENCE;
			this.CM_REFERENCEPIECE = clsCtcontratcommissionassurance.CM_REFERENCEPIECE;
			this.CA_CODECONTRAT = clsCtcontratcommissionassurance.CA_CODECONTRAT;
			this.CM_LIBELLEOPERATION = clsCtcontratcommissionassurance.CM_LIBELLEOPERATION;
			this.CM_MONTANTDEBIT = clsCtcontratcommissionassurance.CM_MONTANTDEBIT;
			this.CM_MONTANTCREDIT = clsCtcontratcommissionassurance.CM_MONTANTCREDIT;
			this.CM_ANNULER = clsCtcontratcommissionassurance.CM_ANNULER;
			this.OP_CODEOPERATEUR = clsCtcontratcommissionassurance.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
