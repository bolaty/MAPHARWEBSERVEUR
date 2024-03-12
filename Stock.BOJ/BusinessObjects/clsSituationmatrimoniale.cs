using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsSituationmatrimoniale
	{

        private string _SM_CODESITUATIONMATRIMONIALE = "";
		private string _SX_CODESEXE = "";
		private string _SM_LIBELLE = "";
		private double _SM_NOMBREPARTPARENFANTS = 0;
		private double _SM_LIMITENOMBREPARTPARENFANTS = 0;
		private double _SM_NOMBREPARTSANSENFANT = 0;
		private double _SM_NOMBREPARTAVECENFANT = 0;



        public string SM_CODESITUATIONMATRIMONIALE
		{
			get { return _SM_CODESITUATIONMATRIMONIALE; }
			set { _SM_CODESITUATIONMATRIMONIALE = value; }
		}
		public string SX_CODESEXE
		{
			get { return _SX_CODESEXE; }
			set { _SX_CODESEXE = value; }
		}
		public string SM_LIBELLE
		{
			get { return _SM_LIBELLE; }
			set { _SM_LIBELLE = value; }
		}
		public double SM_NOMBREPARTPARENFANTS
		{
			get { return _SM_NOMBREPARTPARENFANTS; }
			set { _SM_NOMBREPARTPARENFANTS = value; }
		}
		public double SM_LIMITENOMBREPARTPARENFANTS
		{
			get { return _SM_LIMITENOMBREPARTPARENFANTS; }
			set { _SM_LIMITENOMBREPARTPARENFANTS = value; }
		}
		public double SM_NOMBREPARTSANSENFANT
		{
			get { return _SM_NOMBREPARTSANSENFANT; }
			set { _SM_NOMBREPARTSANSENFANT = value; }
		}
		public double SM_NOMBREPARTAVECENFANT
		{
			get { return _SM_NOMBREPARTAVECENFANT; }
			set { _SM_NOMBREPARTAVECENFANT = value; }
		}



        public clsSituationmatrimoniale() {} 

		public clsSituationmatrimoniale(string SM_CODESITUATIONMATRIMONIALE,string SX_CODESEXE,string SM_LIBELLE,double SM_NOMBREPARTPARENFANTS,double SM_LIMITENOMBREPARTPARENFANTS,double SM_NOMBREPARTSANSENFANT,double SM_NOMBREPARTAVECENFANT)
		{
			this.SM_CODESITUATIONMATRIMONIALE = SM_CODESITUATIONMATRIMONIALE;
			this.SX_CODESEXE = SX_CODESEXE;
			this.SM_LIBELLE = SM_LIBELLE;
			this.SM_NOMBREPARTPARENFANTS = SM_NOMBREPARTPARENFANTS;
			this.SM_LIMITENOMBREPARTPARENFANTS = SM_LIMITENOMBREPARTPARENFANTS;
			this.SM_NOMBREPARTSANSENFANT = SM_NOMBREPARTSANSENFANT;
			this.SM_NOMBREPARTAVECENFANT = SM_NOMBREPARTAVECENFANT;
		}

		public clsSituationmatrimoniale(clsSituationmatrimoniale clsSituationmatrimoniale)
		{
			SM_CODESITUATIONMATRIMONIALE = clsSituationmatrimoniale.SM_CODESITUATIONMATRIMONIALE;
			SX_CODESEXE = clsSituationmatrimoniale.SX_CODESEXE;
			SM_LIBELLE = clsSituationmatrimoniale.SM_LIBELLE;
			SM_NOMBREPARTPARENFANTS = clsSituationmatrimoniale.SM_NOMBREPARTPARENFANTS;
			SM_LIMITENOMBREPARTPARENFANTS = clsSituationmatrimoniale.SM_LIMITENOMBREPARTPARENFANTS;
			SM_NOMBREPARTSANSENFANT = clsSituationmatrimoniale.SM_NOMBREPARTSANSENFANT;
			SM_NOMBREPARTAVECENFANT = clsSituationmatrimoniale.SM_NOMBREPARTAVECENFANT;
		}
        }
}