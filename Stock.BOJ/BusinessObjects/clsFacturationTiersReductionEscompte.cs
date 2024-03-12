using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsFacturationTiersReductionEscompte
	{

        private double _PRIXARTICLETTC = 0;
        public double PRIXARTICLETTC
        {
            get { return _PRIXARTICLETTC; }
            set { _PRIXARTICLETTC = value; }
        }

        private double _PRIXARTICLEHT = 0;
        public double PRIXARTICLEHT
        {
            get { return _PRIXARTICLEHT; }
            set { _PRIXARTICLEHT = value; }
        }

        private double _PRIXARTICLEAPRESREDUCTIONOUESCOMPTE = 0;
        public double PRIXARTICLEAPRESREDUCTIONOUESCOMPTE
        {
            get { return _PRIXARTICLEAPRESREDUCTIONOUESCOMPTE; }
            set { _PRIXARTICLEAPRESREDUCTIONOUESCOMPTE = value; }
        }


        private double _MONTANTREMISE = 0;
        public double MONTANTREMISE
        {
            get { return _MONTANTREMISE; }
            set { _MONTANTREMISE = value; }
        }

        private double _MONTANTESCOMPTE = 0;
        public double MONTANTESCOMPTE
        {
            get { return _MONTANTESCOMPTE; }
            set { _MONTANTESCOMPTE = value; }
        }


        private double _TOTALREMISE = 0;
        public double TOTALREMISE
        {
            get { return _TOTALREMISE; }
            set { _TOTALREMISE = value; }
        }


        private double _TOTALESCOMPTE = 0;
        public double TOTALESCOMPTE
        {
            get { return _TOTALESCOMPTE; }
            set { _TOTALESCOMPTE = value; }
        }

        private double _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = 0;
        public double MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE
        {
            get { return _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE; }
            set { _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = value; }
        }



        public clsFacturationTiersReductionEscompte() {}

       
		public clsFacturationTiersReductionEscompte(clsFacturationTiersReductionEscompte clsFacturationTiersReductionEscompte)
		{
            PRIXARTICLETTC = clsFacturationTiersReductionEscompte.PRIXARTICLETTC;
            PRIXARTICLEHT = clsFacturationTiersReductionEscompte.PRIXARTICLEHT;
            PRIXARTICLEAPRESREDUCTIONOUESCOMPTE = clsFacturationTiersReductionEscompte.PRIXARTICLEAPRESREDUCTIONOUESCOMPTE;
            TOTALREMISE = clsFacturationTiersReductionEscompte.TOTALREMISE;
            TOTALESCOMPTE = clsFacturationTiersReductionEscompte.TOTALESCOMPTE;
            MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = clsFacturationTiersReductionEscompte.MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE;
        }
        }
}