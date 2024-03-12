using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.TOOLS
{
    public class clsLicenceUtilisation1
    {

        #region  declaration unique de la classe

        //declaration unique de la classe clsLicenceUtilisation1 pour tout le projet
        private readonly static clsLicenceUtilisation1 ClasseLicenceUtilisation = new clsLicenceUtilisation1();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsLicenceUtilisation1()
        {
        }
        //constructeur public de la classe fonction 
        public static clsLicenceUtilisation1 ClassecLicenceUtilisation
        {
            get { return ClasseLicenceUtilisation; }
        }

        #endregion

        ///<summary>Cette fonction permet de recupérer la valeur de la garantie d'un véhicule donnée,et aussi toutes les réductions liées à la garantie</summary>
        ///<returns>Un clsPrimeauto comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        public bool pvgControlAdressesMACs
        (List<string[]> maList)
        {
            if (maList.Count > 0)
            {
                string[] vlpAdresseMac;
                for (int i = 0; i < maList.Count; i++)
                {
                    vlpAdresseMac = maList[i];
                    if (pvgTestAdresseMAC(vlpAdresseMac[1].ToString())) return true;
                }
            }
            return false;
        }


        ///<summary>Cette fonction permet de recupérer la valeur de la garantie 
        ///d'un véhicule donnée,et aussi toutes les réductions liées à la garantie</summary>
        ///<returns>Un clsPrimeauto comme valeur du résultat de la requete</returns>
        ///<author>Home Technologie</author>
        private bool pvgTestAdresseMAC
        (string vppAdresseMAC)
        {
            if (vppAdresseMAC == "00:12:")//MON PROPRE PC
            {
                return true;
            }

            if (vppAdresseMAC == "00:12:F0:E1:3A:3E" ||
                vppAdresseMAC == "00:0F:B0:9C:0C:1F")//1-MON PROPRE PC
            {
                return true;
            }
            else if (vppAdresseMAC == "")//2-PC DE YAO BRICE
            {
                return true;
            }

            return false;
        }

    }
}
