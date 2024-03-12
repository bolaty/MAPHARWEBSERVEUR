using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaclientphoto
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CL_IDCLIENT = "";
        private Byte[] _PH_PHOTO = null;

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CL_IDCLIENT
		{
			get { return _CL_IDCLIENT; }
			set {  _CL_IDCLIENT = value; }
		}

        public Byte[] PH_PHOTO
		{
			get { return _PH_PHOTO; }
			set {  _PH_PHOTO = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaclientphoto(){}
        public clsPhaclientphoto(string AG_CODEAGENCE, string CL_IDCLIENT, Byte[] PH_PHOTO)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CL_IDCLIENT = CL_IDCLIENT;
			this.PH_PHOTO = PH_PHOTO;
		}
		public clsPhaclientphoto(clsPhaclientphoto clsPhaclientphoto)
		{
			this.AG_CODEAGENCE = clsPhaclientphoto.AG_CODEAGENCE;
			this.CL_IDCLIENT = clsPhaclientphoto.CL_IDCLIENT;
			this.PH_PHOTO = clsPhaclientphoto.PH_PHOTO;
		}

		#endregion

	}
}
