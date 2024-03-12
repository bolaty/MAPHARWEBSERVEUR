using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhaparnaturetiers : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _TP_CODETYPETIERS = "";
		private string _NT_CODENATURETIERS = "";
		private string _NT_LIBELLE = "";
		private string _NT_DESCRIPTION = "";
        private string _NT_INVENTAIRE = "";
		private string _NT_NUMEROORDRE ="";

		#endregion

		#region ACCESSEURS

		public string TP_CODETYPETIERS
		{
			get { return _TP_CODETYPETIERS; }
			set {  _TP_CODETYPETIERS = value; }
		}

		public string NT_CODENATURETIERS
		{
			get { return _NT_CODENATURETIERS; }
			set {  _NT_CODENATURETIERS = value; }
		}

		public string NT_LIBELLE
		{
			get { return _NT_LIBELLE; }
			set {  _NT_LIBELLE = value; }
		}

		public string NT_DESCRIPTION
		{
			get { return _NT_DESCRIPTION; }
			set {  _NT_DESCRIPTION = value; }
		}
        public string NT_INVENTAIRE
        {
            get { return _NT_INVENTAIRE; }
            set { _NT_INVENTAIRE = value; }
        }


		public string NT_NUMEROORDRE
		{
			get { return _NT_NUMEROORDRE; }
			set {  _NT_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparnaturetiers(){}
		
		public clsPhaparnaturetiers(clsPhaparnaturetiers clsPhaparnaturetiers)
		{
			this.TP_CODETYPETIERS = clsPhaparnaturetiers.TP_CODETYPETIERS;
			this.NT_CODENATURETIERS = clsPhaparnaturetiers.NT_CODENATURETIERS;
			this.NT_LIBELLE = clsPhaparnaturetiers.NT_LIBELLE;
			this.NT_DESCRIPTION = clsPhaparnaturetiers.NT_DESCRIPTION;
            this.NT_INVENTAIRE = clsPhaparnaturetiers.NT_INVENTAIRE;
			this.NT_NUMEROORDRE = clsPhaparnaturetiers.NT_NUMEROORDRE;
		}

		#endregion

	}
}
