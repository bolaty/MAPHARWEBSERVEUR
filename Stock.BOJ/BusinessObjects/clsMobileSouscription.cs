using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace Stock.BOJ
{
    public class clsMobileSouscription 
    {
        #region VARIABLES LOCALES

        private string _TI_IDTIERS = "";
        private string _PY_CODEPAYS = "";
        private string _TI_TELEPHONE = "";
        private string _TI_EMAIL = "";
        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private String _LO_CODELOGICIEL = "";
        private string _DATEJOURNEE = "";
        #endregion

        #region ACCESSEURS
        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string TI_TELEPHONE
        {
            get { return _TI_TELEPHONE; }
            set { _TI_TELEPHONE = value; }
        }
        public string TI_EMAIL
        {
            get { return _TI_EMAIL; }
            set { _TI_EMAIL = value; }
        }


        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }







        public String LO_CODELOGICIEL
        {
            get { return _LO_CODELOGICIEL; }
            set { _LO_CODELOGICIEL = value; }
        }
        public String DATEJOURNEE
        {
            get { return _DATEJOURNEE; }
            set { _DATEJOURNEE = value; }
        }




        #endregion

        #region INSTANCIATEURS

        public clsMobileSouscription() { }

        public clsMobileSouscription(clsMobileSouscription clsMobileSouscription)
        {
            this.TI_IDTIERS = clsMobileSouscription.TI_IDTIERS;
            this.PY_CODEPAYS = clsMobileSouscription.PY_CODEPAYS;
            this.TI_TELEPHONE = clsMobileSouscription.TI_TELEPHONE;
            this.TI_EMAIL = clsMobileSouscription.TI_EMAIL;
            this.AG_CODEAGENCE = clsMobileSouscription.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsMobileSouscription.EN_CODEENTREPOT;
            this.LO_CODELOGICIEL = clsMobileSouscription.LO_CODELOGICIEL;
            this.DATEJOURNEE = clsMobileSouscription.DATEJOURNEE;



        }

        #endregion

    }
}
