using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
    public class clsCtcontratMobileEnvoi : clsEntitieBase
    {
        #region VARIABLES LOCALES
        private string _CA_CODECONTRAT = "";
        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private string _CA_NUMPOLICE = "";
        private string _TI_IDTIERS = "";
        private String _TI_NUMTIERS = "";
        private String _TI_DENOMINATION = "";
        private String _LO_CODELOGICIEL = "";
        private string _CA_STATUT = "";
        #endregion

        #region ACCESSEURS

        public string CA_CODECONTRAT
        {
            get { return _CA_CODECONTRAT; }
            set { _CA_CODECONTRAT = value; }
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

        public string CA_NUMPOLICE
        {
            get { return _CA_NUMPOLICE; }
            set { _CA_NUMPOLICE = value; }
        }

        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }

        public String TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
        public String TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }
        public String LO_CODELOGICIEL
        {
            get { return _LO_CODELOGICIEL; }
            set { _LO_CODELOGICIEL = value; }
        }
        public String CA_STATUT
        {
            get { return _CA_STATUT; }
            set { _CA_STATUT = value; }
        }



        #endregion

        #region INSTANCIATEURS

        public clsCtcontratMobileEnvoi() { }

        public clsCtcontratMobileEnvoi(clsCtcontratMobileEnvoi clsCtcontratMobileEnvoi)
        {
            this.CA_CODECONTRAT = clsCtcontratMobileEnvoi.CA_CODECONTRAT;
            this.AG_CODEAGENCE = clsCtcontratMobileEnvoi.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsCtcontratMobileEnvoi.EN_CODEENTREPOT;
            this.CA_NUMPOLICE = clsCtcontratMobileEnvoi.CA_NUMPOLICE;
            this.TI_IDTIERS = clsCtcontratMobileEnvoi.TI_IDTIERS;
            this.TI_NUMTIERS = clsCtcontratMobileEnvoi.TI_NUMTIERS;
            this.TI_DENOMINATION = clsCtcontratMobileEnvoi.TI_DENOMINATION;
            this.LO_CODELOGICIEL = clsCtcontratMobileEnvoi.LO_CODELOGICIEL;
            this.CA_STATUT = clsCtcontratMobileEnvoi.CA_STATUT;



        }

        #endregion

    }
}
