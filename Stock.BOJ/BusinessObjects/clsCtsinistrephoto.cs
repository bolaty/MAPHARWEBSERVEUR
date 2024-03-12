using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtsinistrephoto
	{
		#region VARIABLES LOCALES

		private string _SI_CODESINISTRE = "";
		private string _SI_NUMSEQUENCEPHOTO = "";
		private string _SI_CHEMINPHOTO = "";
		private string _SI_LIBELLEPHOTO = "";
		private string _TYPEOPERATION = "";

		#endregion

		#region ACCESSEURS

		public string SI_CODESINISTRE
		{
			get { return _SI_CODESINISTRE; }
			set {  _SI_CODESINISTRE = value; }
		}

		public string SI_NUMSEQUENCEPHOTO
		{
			get { return _SI_NUMSEQUENCEPHOTO; }
			set {  _SI_NUMSEQUENCEPHOTO = value; }
		}

		public string SI_CHEMINPHOTO
		{
			get { return _SI_CHEMINPHOTO; }
			set {  _SI_CHEMINPHOTO = value; }
		}

		public string SI_LIBELLEPHOTO
		{
			get { return _SI_LIBELLEPHOTO; }
			set {  _SI_LIBELLEPHOTO = value; }
		}
		public string TYPEOPERATION
        {
			get { return _TYPEOPERATION; }
			set { _TYPEOPERATION = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsCtsinistrephoto(){}
		
		public clsCtsinistrephoto(clsCtsinistrephoto clsCtsinistrephoto)
		{
			this.SI_CODESINISTRE = clsCtsinistrephoto.SI_CODESINISTRE;
			this.SI_NUMSEQUENCEPHOTO = clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO;
			this.SI_CHEMINPHOTO = clsCtsinistrephoto.SI_CHEMINPHOTO;
			this.SI_LIBELLEPHOTO = clsCtsinistrephoto.SI_LIBELLEPHOTO;
			this.TYPEOPERATION = clsCtsinistrephoto.TYPEOPERATION;
		}

		#endregion

	}
}
