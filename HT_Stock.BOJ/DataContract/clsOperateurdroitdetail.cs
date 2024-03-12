using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsOperateurdroitdetail
	{
		#region VARIABLES LOCALES

		private string _OP_CODEOBJET = "";
		private string _OP_CODEOPERATEUR = "";
		private double _AG_CODEAGENCE = 0;
		private string _OD_AUTORISER = "";
		private int _OD_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string OP_CODEOBJET
		{
			get { return _OP_CODEOBJET; }
			set {  _OP_CODEOBJET = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public double AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string OD_AUTORISER
		{
			get { return _OD_AUTORISER; }
			set {  _OD_AUTORISER = value; }
		}

		public int OD_NUMEROORDRE
		{
			get { return _OD_NUMEROORDRE; }
			set {  _OD_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsOperateurdroitdetail(){}
		public clsOperateurdroitdetail( string OP_CODEOBJET,string OP_CODEOPERATEUR,double AG_CODEAGENCE,string OD_AUTORISER,int OD_NUMEROORDRE)
		{
			this.OP_CODEOBJET = OP_CODEOBJET;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.OD_AUTORISER = OD_AUTORISER;
			this.OD_NUMEROORDRE = OD_NUMEROORDRE;
		}
		public clsOperateurdroitdetail(clsOperateurdroitdetail clsOperateurdroitdetail)
		{
			this.OP_CODEOBJET = clsOperateurdroitdetail.OP_CODEOBJET;
			this.OP_CODEOPERATEUR = clsOperateurdroitdetail.OP_CODEOPERATEUR;
			this.AG_CODEAGENCE = clsOperateurdroitdetail.AG_CODEAGENCE;
			this.OD_AUTORISER = clsOperateurdroitdetail.OD_AUTORISER;
			this.OD_NUMEROORDRE = clsOperateurdroitdetail.OD_NUMEROORDRE;
		}

		#endregion

	}
}
