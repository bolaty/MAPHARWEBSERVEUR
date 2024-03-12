using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhaparnatureoperation : clsEntitieBase
    {

        private string _NO_CODENATUREOPERATION = "";
		private string _NO_LIBELLE = "";
		private string _NO_PROJET = "";



        public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set { _NO_CODENATUREOPERATION = value; }
		}
		public string NO_LIBELLE
		{
			get { return _NO_LIBELLE; }
			set { _NO_LIBELLE = value; }
		}
		public string NO_PROJET
		{
			get { return _NO_PROJET; }
			set { _NO_PROJET = value; }
		}



        public clsPhaparnatureoperation() {} 

		public clsPhaparnatureoperation(string NO_CODENATUREOPERATION,string NO_LIBELLE,string NO_PROJET)
		{
			this.NO_CODENATUREOPERATION = NO_CODENATUREOPERATION;
			this.NO_LIBELLE = NO_LIBELLE;
			this.NO_PROJET = NO_PROJET;
		}

		public clsPhaparnatureoperation(clsPhaparnatureoperation clsPhaparnatureoperation)
		{
			NO_CODENATUREOPERATION = clsPhaparnatureoperation.NO_CODENATUREOPERATION;
			NO_LIBELLE = clsPhaparnatureoperation.NO_LIBELLE;
			NO_PROJET = clsPhaparnatureoperation.NO_PROJET;
		}
        }
}