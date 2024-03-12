using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.TOOLS
{
    public class clsLicenceUtilisation
    {

        #region  declaration unique de la classe

        //declaration unique de la classe clsLicenceUtilisation pour tout le projet
        private readonly static clsLicenceUtilisation ClasseLicenceUtilisation = new clsLicenceUtilisation();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsLicenceUtilisation()
        {
        }
        //constructeur public de la classe fonction 
        public static clsLicenceUtilisation ClassecLicenceUtilisation
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
        private bool pvgTestAdresseMAC(string vppAdresseMAC)
        {
            
            //1-MON PROPRE PC
            if (vppAdresseMAC == "08:00:27:00:80:4D" || vppAdresseMAC == "F0:BF:97:02:79:5D"
                || vppAdresseMAC == "00:0F:B0:9C:0C:1F" || vppAdresseMAC == "64:27:37:A6:7A:C9")
            {
      
                return true;
            }


            //1-PC SERVICE COMMERCIAL
            else if (
                vppAdresseMAC == "08:00:27:00:60:0E" || vppAdresseMAC == "88:AE:1D:AC:78:13" || vppAdresseMAC == "00:27:10:0D:DB:D0" || vppAdresseMAC == "68:B5:99:FA:31:15"
                || vppAdresseMAC == "58:94:6B:B1:0E:EC" || vppAdresseMAC == "08:00:27:00:C0:5F" || vppAdresseMAC == "08:00:27:00:90:A8" || vppAdresseMAC == "08:00:27:00:CC:6B"

                //ACHAT DU 20-01-2018 HP-NOUVEL ORDINATEUR
                || vppAdresseMAC == "10:1F:74:E4:71:D6" || vppAdresseMAC == "A0:88:B4:C4:B9:34" || vppAdresseMAC == "0A:00:27:00:00:0A"
                )
            {
                return true;
            }
            //2-PC HOTEL MIRABEL
            else if (
                vppAdresseMAC == "B0:83:FE:86:65:68" || vppAdresseMAC == "08:00:27:00:90:A6")
            {
                return true;
            }
            //3-PC Louis
            else if (
                vppAdresseMAC == "B8:70:F4:57:9C:3E" || vppAdresseMAC == "B4:74:9F:C6:8C:72"
                || vppAdresseMAC == "08:00:27:00:68:07"
                )
            {
                return true;
            }
            //4-PC CIPROVET
            else if (vppAdresseMAC == "C4:17:FE:61:29:BA" || vppAdresseMAC == "C8:0A:A9:13:35:BC"
                || vppAdresseMAC == "00:23:7D:2D:EE:5F" || vppAdresseMAC == "44:37:E6:73:1B:3B"
                || vppAdresseMAC == "DC:53:60:22:F7:95"
                )
            {
                return true;
            }

            //4-PC HOTEL HANIEL
            else if (
                vppAdresseMAC == "00:22:64:BF:B6:CE" || vppAdresseMAC == "00:14:2A:E8:6A:A6"
                || vppAdresseMAC == "00:24:1D:0B:2B:EA" || vppAdresseMAC == "00:1A:92:AD:33:21"

                || vppAdresseMAC == "00:23:7D:2C:FC:EC" || vppAdresseMAC == "40:61:86:66:73:FC"
                || vppAdresseMAC == "40:61:86:08:A3:12" || vppAdresseMAC == "00:24:81:CC:0A:53"
                || vppAdresseMAC == "34:64:A9:24:77:90"

                //DG HANNIEL
                || vppAdresseMAC == "34:E6:AD:B0:11:DE" || vppAdresseMAC == "68:F7:28:D0:AC:3A"

                //carte ethernet gerante
                || vppAdresseMAC == "00:21:9B:10:B6:62"

                //carte ethernet Comptable
                || vppAdresseMAC == "C4:E9:84:00:1E:C5"


                //05-05-2018
                //GERANTE
                || vppAdresseMAC == "50:65:F3:2A:DD:C6"
                //COMPTABLE (MANDE)
                || vppAdresseMAC == "50:65:F3:2A:DB:9A"
                //CAISSE
                || vppAdresseMAC == "50:65:F3:2A:DE:6B"
                //DJEWNY
                || vppAdresseMAC == "EC:B1:D7:51:78:19"

                //RECEPTION
                || vppAdresseMAC == "EC:B1:D7:58:A3:96"

                )
            {
                return true;
            }
            //4-PC DJERA SERVICE
            else if (
                vppAdresseMAC == "50:65:F3:2B:41:6E" || vppAdresseMAC == "FC:15:B4:93:B1:2B"
                || vppAdresseMAC == "FC:15:B4:93:B1:2A" || vppAdresseMAC == "FC:15:B4:93:B1:29"
                || vppAdresseMAC == "FC:15:B4:93:B1:28"


                || vppAdresseMAC == "A0:1D:48:D5:D1:EC"  //Mr Kouassi,FILAIRE
                || vppAdresseMAC == "50:65:F3:2B:41:6E" //PC Comptable,FILAIRE
                || vppAdresseMAC == "FC:15:B4:93:B1:28" //serveur
                )
            {
                return true;
            }
            //1-MON PROPRE PC
            if (vppAdresseMAC == "08:00:27:00:74:9F" || vppAdresseMAC == "F0:BF:97:02:79:5D"
                || vppAdresseMAC == "00:0F:B0:9C:0C:1F" || vppAdresseMAC == "64:27:37:A6:7A:C9")
            {
                return true;
            }

            //1-PC GILLES+KOUASSI+AUTRE POUR LA FORMATION A DJERA SERVICE
            if (vppAdresseMAC == "4C:BB:58:07:09:28" || vppAdresseMAC == "9C:D2:1E:00:20:BD"
                || vppAdresseMAC == "48:5A:B6:9A:42:27")
            {
                return true;
            }

            //1-LE SERVEUR HOME TECHNOLOGY
            if (vppAdresseMAC == "A4:1F:72:50:10:C0" || vppAdresseMAC == "08:00:27:00:E0:08")
            {
                return true;
            }

            //1-SECRETAIRE
            if (vppAdresseMAC == "74:86:7A:1B:0D:5C" || vppAdresseMAC == "BC:85:56:1E:63:F3" || vppAdresseMAC == "74:88:7A:1B:0D:5C" || vppAdresseMAC == "08:00:27:00:DB:8C" || vppAdresseMAC == "08:00:27:00:54:63")
            {
                return true;
            }


            //1-ORDINATEUR POUR LES DEMO
            if (vppAdresseMAC == "C8:0A:A9:CD:82:C3" //carte ethernet : 
            || vppAdresseMAC == "0A:00:27:00:00:07" //carte virtualbox 
            || vppAdresseMAC == "F0:7B:CB:A4:6A:E8	")//carte wifi     
            {
                return true;
            }

            //1-ORDINATEUR GARAGE AUTO EXCELLE
            if (vppAdresseMAC == "34:64:A9:37:DA:15" //carte ethernet 
            || vppAdresseMAC == "08:00:27:00:6C:E3") //carte virtualbox     
            {
                return true;
            }

            //1-ORDINATEUR GBOBIA
            if (vppAdresseMAC == "00:19:99:61:50:A9" //carte ethernet 
            || vppAdresseMAC == "08:00:27:00:30:83") //carte virtualbox     
            {
                return true;
            }

            //1-ORDINATEUR CAMENE
            if (vppAdresseMAC == "00:1F:29:D8:DF:19" //Serveur
            || vppAdresseMAC == "38:60:77:67:F2:74" //Comptabilité
            || vppAdresseMAC == "38:60:77:40:34:10" //DG
            )
            {
                return true;
            }

            //1-ORDINATEUR HOME TECNOLOGY LENOVO 1
            if (vppAdresseMAC == "54:EE:75:CB:4E:16" //Ethernet: 
            || vppAdresseMAC == "3C:F8:62:84:70:D8" //WIFI
            || vppAdresseMAC == "08:00:27:00:CC:57" //Virtual box :
            )
            {
                return true;
            }

            //1-ORDINATEUR DELL I5,service technique
            if (vppAdresseMAC == "F0:1F:AF:64:CA:6E" //Ethernet: 
            || vppAdresseMAC == "0C:8B:FD:F1:29:DF" //WIFI
            || vppAdresseMAC == "08:00:27:00:40:A0" //Virtual box :
            )
            {
                return true;
            }

            //1-GERARD SERVICE
            if (vppAdresseMAC == "30:E1:71:C8:5F:50" //Ethernet: 
            || vppAdresseMAC == "70:1C:E7:70:E5:40" //WIFI
            || vppAdresseMAC == "08:00:27:00:C0:50" //Virtual box :
                                                    //28-02-2018
            || vppAdresseMAC == "00:21:70:2F:EF:5C" //ETHERNET
            || vppAdresseMAC == "08:00:27:00:68:0A" //VIRTUAL BOX
            )
            {
                return true;
            }


            //ORDINATEUR PORTABLE GBOBIA
            if (vppAdresseMAC == "0A:00:27:00:00:09" //virtualbox 
            || vppAdresseMAC == "30:E1:71:17:C4:6A" //ethernet   
            || vppAdresseMAC == "98:54:1B:11:13:59" //WIFI  
            )
            {
                return true;
            }


            //ORDINATEUR EL SHADAI
            if (vppAdresseMAC == "08:00:27:00:B0:70" //virtualbox 
            || vppAdresseMAC == "00:1A:6B:61:DE:A5" //ethernet   
            )
            {
                return true;
            }
            //ORDINATEUR COMPTABILITE
            if (vppAdresseMAC == "6C:62:6D:A5:D0:53" // ethernet
            || vppAdresseMAC == "0A:00:27:00:00:07" //virtualbox    
            )
            {
                return true;
            }


        //ORDINATEUR DIARRASSOUBA
        if (vppAdresseMAC == "08:00:27:00:70:DE" // virtualbox
 
        )
        {
            return true;
        }




            return false;
        }

    }
}
