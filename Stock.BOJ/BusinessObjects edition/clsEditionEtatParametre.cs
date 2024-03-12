using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsEditionEtatParametre
	{



        private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUREDITION = "";
        private string _BT_CODETYPEBUDGET = "";
        private string _ET_TYPEETAT = "";
        private string _ET_TYPERETOURS = "";

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string OP_CODEOPERATEUREDITION
		{
			get { return _OP_CODEOPERATEUREDITION; }
			set { _OP_CODEOPERATEUREDITION = value; }
		}

        public string BT_CODETYPEBUDGET
		{
            get { return _BT_CODETYPEBUDGET; }
            set { _BT_CODETYPEBUDGET = value; }
		}


        public string ET_TYPEETAT
		{
            get { return _ET_TYPEETAT; }
            set { _ET_TYPEETAT = value; }
		}
        public string ET_TYPERETOURS
		{
            get { return _ET_TYPERETOURS; }
            set { _ET_TYPERETOURS = value; }
		}


        public clsEditionEtatParametre() {} 

		

		public clsEditionEtatParametre(clsEditionEtatParametre clsEditionEtatParametre)
		{

            BT_CODETYPEBUDGET = clsEditionEtatParametre.BT_CODETYPEBUDGET;
            AG_CODEAGENCE = clsEditionEtatParametre.AG_CODEAGENCE;
			OP_CODEOPERATEUREDITION = clsEditionEtatParametre.OP_CODEOPERATEUREDITION;
            ET_TYPEETAT = clsEditionEtatParametre.ET_TYPEETAT;
            ET_TYPERETOURS = clsEditionEtatParametre.ET_TYPERETOURS;

		}
        }
}