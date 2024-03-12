using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtsinistrephoto : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _SI_CODESINISTRE = "";
		private string _SI_NUMSEQUENCEPHOTO = "";
		private string _SI_CHEMINPHOTO = "";
		private string _SI_LIBELLEPHOTO = "";
		private string _DATEJOURNEE = "";
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
		public string DATEJOURNEE
        {
			get { return _DATEJOURNEE; }
			set { _DATEJOURNEE = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsCtsinistrephoto(){}
		public clsCtsinistrephoto( string SI_CODESINISTRE,string SI_NUMSEQUENCEPHOTO,string SI_CHEMINPHOTO,string SI_LIBELLEPHOTO,string DATEJOURNEE)
		{
			this.SI_CODESINISTRE = SI_CODESINISTRE;
			this.SI_NUMSEQUENCEPHOTO = SI_NUMSEQUENCEPHOTO;
			this.SI_CHEMINPHOTO = SI_CHEMINPHOTO;
			this.SI_LIBELLEPHOTO = SI_LIBELLEPHOTO;
			this.DATEJOURNEE = DATEJOURNEE;
		}
		public clsCtsinistrephoto(clsCtsinistrephoto clsCtsinistrephoto)
		{
			this.SI_CODESINISTRE = clsCtsinistrephoto.SI_CODESINISTRE;
			this.SI_NUMSEQUENCEPHOTO = clsCtsinistrephoto.SI_NUMSEQUENCEPHOTO;
			this.SI_CHEMINPHOTO = clsCtsinistrephoto.SI_CHEMINPHOTO;
			this.SI_LIBELLEPHOTO = clsCtsinistrephoto.SI_LIBELLEPHOTO;
			this.DATEJOURNEE = clsCtsinistrephoto.DATEJOURNEE;
		}

		#endregion

	}
}
