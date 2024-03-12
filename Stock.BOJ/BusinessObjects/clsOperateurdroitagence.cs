using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsOperateurdroitagence
	{
		#region VARIABLES LOCALES

		private string _OP_CODEOPERATEUR = "";
		private string _AG_CODEAGENCE = "";
        private string _COCHER = "";
		#endregion

		#region ACCESSEURS

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

        public string COCHER
		{
            get { return _COCHER; }
            set { _COCHER = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsOperateurdroitagence(){}
		public clsOperateurdroitagence( string OP_CODEOPERATEUR,string AG_CODEAGENCE)
		{
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
		}
		public clsOperateurdroitagence(clsOperateurdroitagence clsOperateurdroitagence)
		{
			this.OP_CODEOPERATEUR = clsOperateurdroitagence.OP_CODEOPERATEUR;
			this.AG_CODEAGENCE = clsOperateurdroitagence.AG_CODEAGENCE;
            this.COCHER = clsOperateurdroitagence.COCHER;


		}

		#endregion

	}
}
