using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsTresorerieparamrubriquetresorerie
	{
		#region VARIABLES LOCALES

		private string _TR_CODERUBRIQUETRESORERIE = "";
		private string _TE_CODEEXPLOITATION ="";
		private string _TR_LIBELLE = "";
        private string _TF_CODEFORMULE = "";
		private int _TR_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string TR_CODERUBRIQUETRESORERIE
		{
			get { return _TR_CODERUBRIQUETRESORERIE; }
			set {  _TR_CODERUBRIQUETRESORERIE = value; }
		}

		public string TE_CODEEXPLOITATION
		{
			get { return _TE_CODEEXPLOITATION; }
			set {  _TE_CODEEXPLOITATION = value; }
		}

		public string TR_LIBELLE
		{
			get { return _TR_LIBELLE; }
			set {  _TR_LIBELLE = value; }
		}

        public string TF_CODEFORMULE
        {
	        get { return _TF_CODEFORMULE; }
	        set { _TF_CODEFORMULE = value; }
        }

		public int TR_NUMEROORDRE
		{
			get { return _TR_NUMEROORDRE; }
			set {  _TR_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieparamrubriquetresorerie(){}
		
		public clsTresorerieparamrubriquetresorerie(clsTresorerieparamrubriquetresorerie clsTresorerieparamrubriquetresorerie)
		{
			this.TR_CODERUBRIQUETRESORERIE = clsTresorerieparamrubriquetresorerie.TR_CODERUBRIQUETRESORERIE;
			this.TE_CODEEXPLOITATION = clsTresorerieparamrubriquetresorerie.TE_CODEEXPLOITATION;
			this.TR_LIBELLE = clsTresorerieparamrubriquetresorerie.TR_LIBELLE;
            this.TF_CODEFORMULE = clsTresorerieparamrubriquetresorerie.TF_CODEFORMULE;
			this.TR_NUMEROORDRE = clsTresorerieparamrubriquetresorerie.TR_NUMEROORDRE;
		}

		#endregion

	}
}
