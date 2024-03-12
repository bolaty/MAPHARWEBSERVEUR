using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsEscompte : clsEntitieBase
    {

        private string _TI_ESCOMPTE = "";
		private string _TI_ESCOMPTELIBELLE = "";



        public string TI_ESCOMPTE
		{
			get { return _TI_ESCOMPTE; }
			set { _TI_ESCOMPTE = value; }
		}
		public string TI_ESCOMPTELIBELLE
		{
			get { return _TI_ESCOMPTELIBELLE; }
			set { _TI_ESCOMPTELIBELLE = value; }
		}
      


        public clsEscompte() {}

        public clsEscompte(clsEscompte clsEscompte)
        {
            TI_ESCOMPTE = clsEscompte.TI_ESCOMPTE;
            TI_ESCOMPTELIBELLE = clsEscompte.TI_ESCOMPTELIBELLE;
        }


    }
}