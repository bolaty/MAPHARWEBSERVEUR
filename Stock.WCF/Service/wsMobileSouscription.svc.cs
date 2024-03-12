using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using HT_Stock.BOJ;
using Stock.WSTOOLS;
using log4net;
using System.Reflection;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Stock.WSBLL;
using System.Data;
using Stock.BOJ;
using System.Windows.Forms;
using System.Web;

namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "wsMobileSouscription" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez wsMobileSouscription.svc ou wsMobileSouscription.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public partial class wsMobileSouscription : IwsMobileSouscription
    {
        private clsDonnee _clsDonnee = new clsDonnee();
        private clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
        private clsMobileSouscriptionWSBLL clsMobileSouscriptionWSBLL = new clsMobileSouscriptionWSBLL();

        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }

        //Déclaration du log
        log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMobileSouscription> pvgSouscriptionMobileBanking(List<HT_Stock.BOJ.clsMobileSouscription> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            List<clsResultat> clsResultats = new List<clsResultat>();
            clsResultat clsResultat = new clsResultat();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMobileSouscriptions = TestChampObligatoireInsert(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMobileSouscriptions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMobileSouscriptions;
                //--TEST CONTRAINTE
                clsMobileSouscriptions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMobileSouscriptions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMobileSouscriptions;
            }


            // clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NT_CODENATURETYPETIERS };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                DataSet = clsMobileSouscriptionWSBLL.pvgSouscriptionMobileBanking(clsDonnee, Objet[0].LG_CODELANGUE, Objet[0].AG_CODEAGENCE, Objet[0].TI_IDTIERS, Objet[0].SO_CODESOUSCRIPTION, Objet[0].PY_CODEPAYS, Objet[0].TI_TELEPHONE, Objet[0].DATEJOURNEE, Objet[0].TI_EMAIL, Objet[0].SO_LIEURESIDENCE, Objet[0].TYPEOPERATION);
                clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                        //clsMobileSouscription.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsMobileSouscription.TI_DENOMINATION = row["SL_PRENOMS"].ToString();
                        clsMobileSouscription.TI_NUMTIERS = row["SL_NOM"].ToString();
                        clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                        clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = row["SL_CODEMESSAGE"].ToString();// "00";
                        clsMobileSouscription.clsObjetRetour.SL_RESULTAT =row["SL_RESULTAT"].ToString();// "TRUE";
                        clsMobileSouscription.clsObjetRetour.SL_MESSAGE =row["SL_MESSAGE"].ToString();// "Opération réalisée avec succès !!!";
                        clsMobileSouscriptions.Add(clsMobileSouscription);

                        if (clsMobileSouscription.clsObjetRetour.SL_RESULTAT == "TRUE" && Objet[0].TYPEOPERATION != "02")
                        {
                            //--
                            List<clsCinetpay> clsCinetpays = new List<clsCinetpay>();
                            clsCinetpaytoken clsCinetpaytoken = new clsCinetpaytoken();
                            //clsCinetpaytoken.Apikey = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";
                            //clsCinetpaytoken.Password = clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_P"));//"@merveille241";

                            BOJ.clsParametre clsParametre = new BOJ.clsParametre();
                            clsParametreWSBLL clsParametreWSBLL = new clsParametreWSBLL();
                            BOJ.clsObjetEnvoi clsObjetEnvoi1 = new BOJ.clsObjetEnvoi();
                            string[] stringArray = { "CIT_K" };
                            clsObjetEnvoi1.OE_PARAM = stringArray;
                            clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                            clsCinetpaytoken.Apikey = clsParametre.PP_VALEUR;// clsChaineCaractere.ClasseChaineCaractere.pvgDeCrypter(clsWebConfig.ReadSetting("CINET_API_K"));// "21125435325b3ba36d7d7063.18973709";

                            clsParametre = new BOJ.clsParametre();
                            clsParametreWSBLL = new clsParametreWSBLL();
                            clsObjetEnvoi1 = new BOJ.clsObjetEnvoi();
                            string[] stringArray1 = { "CIT_P" };
                            clsObjetEnvoi1.OE_PARAM = stringArray1;
                            clsParametre = clsParametreWSBLL.pvgTableLabelCrypter(clsDonnee, clsObjetEnvoi1);
                            clsCinetpaytoken.Password = clsParametre.PP_VALEUR;//"@merveille241";


                            if (IsNetworkConnected())
                                clsCinetpays = pvgDemendetoken(clsCinetpaytoken);

                            if (clsCinetpays.Count == 0)
                            {

                                clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "La demande de token a échoué !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                                clsMobileSouscriptions.Add(clsMobileSouscription);
                                try
                                {
                                    throw new Exception("Test Exception");
                                }
                                catch
                                {
                                    return clsMobileSouscriptions;
                                }
                                //return clsResultatMobileTransactionMobileBankings[0];

                            }


                            //--

                            clsPaysWSBLL clsPaysWSBLL = new clsPaysWSBLL();

                            string PY_CODEPOSTALE = "";
                            DataSet = new DataSet();
                            clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].PY_CODEPAYS };
                            DataSet = clsPaysWSBLL.pvgChargerDansDataSetPays(clsDonnee, clsObjetEnvoi);
                            foreach (DataRow row1 in DataSet.Tables[0].Rows)
                            {
                                PY_CODEPOSTALE = row1["PY_CODEPOSTALE"].ToString();
                            }

                            List<clsDataContact> clsDataContacts = new List<clsDataContact>();
                            List<clsCinetpayContact> listclsCinetpayContact = new List<clsCinetpayContact>();
                            clsCinetpayContact clsCinetpayContact = new clsCinetpayContact();
                            clsDataToken clsDataTokens = new clsDataToken();
                            clsDataTokens = clsCinetpays[0].data;
                            clsCinetpayContact.email = Objet[0].TI_EMAIL;
                            clsCinetpayContact.prefix = PY_CODEPOSTALE;
                            clsCinetpayContact.phone = Objet[0].TI_TELEPHONE;
                            clsCinetpayContact.name = clsMobileSouscription.TI_DENOMINATION;
                            clsCinetpayContact.surname = clsMobileSouscription.TI_NUMTIERS;
                            listclsCinetpayContact.Add(clsCinetpayContact);
                            if (IsNetworkConnected())
                                clsDataContacts = pvgAddContact(listclsCinetpayContact, clsDataTokens);
                            //--

                            if (clsDataContacts.Count == 0)
                            {

                                 clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "00";// clsMiccomptewebResultat[0].SL_CODEMESSAGE;
                                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Le service n'est pas disponible (00) !!!";// clsMiccomptewebResultat[0].SL_MESSAGE;
                                clsMobileSouscriptions.Add(clsMobileSouscription);
                                try
                                {
                                    throw new Exception("Le service n'est pas disponible (00) !!!");
                                }
                                catch { return clsMobileSouscriptions; }
                            }



                        }



                    }
                }
                else
                {
                    HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                    clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                    clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsMobileSouscriptions.Add(clsMobileSouscription);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
                clsMobileSouscriptions.Add(clsMobileSouscription);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
                clsMobileSouscriptions.Add(clsMobileSouscription);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMobileSouscriptions;
        }


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        public List<HT_Stock.BOJ.clsMobileSouscription> pvgCompteMobileMappe(List<HT_Stock.BOJ.clsMobileSouscription> Objet)
        {

            List<Stock.BOJ.clsObjetRetour> clsObjetRetourDTOs = new List<Stock.BOJ.clsObjetRetour>();
            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();

            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            clsObjetEnvoi.OE_D = ConfigurationManager.AppSettings["OE_D"];
            clsObjetEnvoi.OE_X = ConfigurationManager.AppSettings["OE_X"];
            clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
            clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;


            for (int Idx = 0; Idx < Objet.Count; Idx++)
            {
                //--TEST DES CHAMPS OBLIGATOIRES
                clsMobileSouscriptions = TestChampObligatoireListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMobileSouscriptions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMobileSouscriptions;
                //--TEST CONTRAINTE
                clsMobileSouscriptions = TestTestContrainteListe(Objet[Idx]);
                //--VERIFICATION DU RESULTAT DU TEST
                if (clsMobileSouscriptions[0].clsObjetRetour.SL_RESULTAT == "FALSE") return clsMobileSouscriptions;
            }


            // clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].NT_CODENATURETYPETIERS };
            DataSet DataSet = new DataSet();

            try
            {
                clsDonnee.pvgConnectionBase();
                //string LG_CODELANGUE, string AG_CODEAGENCE, string TI_IDTIERS, string TYPEOPERATION
                DataSet = clsMobileSouscriptionWSBLL.pvgCompteMobileMappe(clsDonnee, Objet[0].LG_CODELANGUE, Objet[0].AG_CODEAGENCE, Objet[0].TI_IDTIERS, Objet[0].TYPEOPERATION);
                clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
                if (DataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in DataSet.Tables[0].Rows)
                    {
                        HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                        clsMobileSouscription.SO_CODESOUSCRIPTION = row["SO_CODESOUSCRIPTION"].ToString();
                        clsMobileSouscription.TI_TELEPHONE = row["SO_TELEPHONE"].ToString();
                        clsMobileSouscription.TI_IDTIERS = row["TI_IDTIERS"].ToString();
                        clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                        clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "00";
                        clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
                        clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Opération réalisée avec succès !!!";
                        clsMobileSouscriptions.Add(clsMobileSouscription);
                    }
                }
                else
                {
                    HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                    clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                    clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "99";
                    clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                    clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Aucun enregistrement trouvé !!!";
                    clsMobileSouscriptions.Add(clsMobileSouscription);
                }



            }
            catch (SqlException SQLEx)
            {
                HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
                clsMobileSouscriptions.Add(clsMobileSouscription);
            }
            catch (Exception SQLEx)
            {
                HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "99";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = SQLEx.Message;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                //Execution du log
                Log.Error(SQLEx.Message, null);
                clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
                clsMobileSouscriptions.Add(clsMobileSouscription);
            }


            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsMobileSouscriptions;
        }

        public static bool IsNetworkConnected()
        {
            bool connected = SystemInformation.Network;
            if (connected)
            {
                connected = false;
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT NetConnectionStatus FROM Win32_NetworkAdapter");
                foreach (System.Management.ManagementObject networkAdapter in searcher.Get())
                {
                    if (networkAdapter["NetConnectionStatus"] != null)
                    {
                        if (Convert.ToInt32(networkAdapter["NetConnectionStatus"]).Equals(2))
                        {
                            connected = true;
                            break;
                        }
                    }
                }
                searcher.Dispose();
            }
            return connected;
        }


         //++++++++++++++++++++++++++++++++++CINET
        public List<clsCinetpay> pvgDemendetoken(clsCinetpaytoken clsCinetpaytoken)
        {
            clsCinetpay obj = new clsCinetpay();
            List<clsCinetpay> objList = new List<clsCinetpay>();
            try
            {


                var request = (HttpWebRequest)WebRequest.Create("https://client.cinetpay.com/v1/auth/login?lang=fr");
                StringBuilder postData = new StringBuilder();
                postData.Append("apikey=" + HttpUtility.UrlEncode(clsCinetpaytoken.Apikey) + "&");
                postData.Append("password=" + HttpUtility.UrlEncode(clsCinetpaytoken.Password) + "&");

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;


                //=====================nouveau code
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                //===================


                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(postData);
                }
                //if (IsNetworkConnected())
                //{
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //  string NewISOmsg = responseString.Replace("\"", "");
                obj = JsonConvert.DeserializeObject<clsCinetpay>(responseString);
                objList.Add(obj);
                //}
                //else objList = null;

            }
            catch (Exception e)
            {
                var dat = e.Message;

            }


            //watch.Stop();
            // TempData["time"] = watch.ElapsedMilliseconds;
            return objList;
        }


        public List<clsDataContact> pvgAddContact(List<clsCinetpayContact> listclsCinetpayContact, clsDataToken clsDataTokens)
        {
            clsDataContact obj = new clsDataContact();
            List<clsDataContact> objList = new List<clsDataContact>();
            try
            {
                var token = clsDataTokens.token;

                var request = (HttpWebRequest)WebRequest.Create("https://client.cinetpay.com/v1/transfer/contact?token=" + token + "&lang=fr");
                StringBuilder postData = new StringBuilder();
                //postData.Append("token=" + HttpUtility.UrlEncode(token) + "&");
                //postData.Append("lang=" + HttpUtility.UrlEncode("fr") + "&");
                var json = JsonConvert.SerializeObject(listclsCinetpayContact);
                postData.Append("data=" + HttpUtility.UrlEncode(json));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                //for (int Idx = 0; Idx < listclsCinetpayContact.Count; Idx++)
                //{
                //    clsCinetpayContact uncontact = new clsCinetpayContact();
                //     uncontact.Prefix= listclsCinetpayContact[Idx].Prefix;
                //    uncontact.Phone = listclsCinetpayContact[Idx].Phone;
                //    uncontact.Name = listclsCinetpayContact[Idx].Name;
                //    uncontact.Surname = listclsCinetpayContact[Idx].Surname;
                //    uncontact.Email = listclsCinetpayContact[Idx].Email;

                //}

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(postData);
                }
                //if (IsNetworkConnected())
                //{
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var NewISOmsg = responseString;
                NewISOmsg = responseString.Replace("[[", "[");
                NewISOmsg = NewISOmsg.Replace("]]", "]");
                obj = JsonConvert.DeserializeObject<clsDataContact>(NewISOmsg);
                objList.Add(obj);
                //}
                //else objList = null;

            }
            catch (Exception e)
            {
                var dat = e.Message;

            }

            //watch.Stop();
            // TempData["time"] = watch.ElapsedMilliseconds;
            return objList;
        }


        public List<clsDataTransferts> pvgAddTransfert(List<clsCinetpayMoneyContac> ListclsCinetpayMoneyContac, clsDataToken clsDataTokens)
        {
            clsDataTransferts obj = new clsDataTransferts();
            List<clsDataTransferts> objList = new List<clsDataTransferts>();
            try
            {
                var token = clsDataTokens.token;

                var request = (HttpWebRequest)WebRequest.Create("https://client.cinetpay.com/v1/transfer/money/send/contact?token=" + token + "&lang=fr");


                StringBuilder postData = new StringBuilder();
                //postData.Append("token=" + HttpUtility.UrlEncode(token) );
                //postData.Append("&lang=" + HttpUtility.UrlEncode("fr") );
                var json = JsonConvert.SerializeObject(ListclsCinetpayMoneyContac);
                postData.Append("data=" + HttpUtility.UrlEncode(json));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                //request.AllowAutoRedirect = true;
                //request.Credentials = CredentialCache.DefaultCredentials;

                //for (int Idx = 0; Idx < listclsCinetpayContact.Count; Idx++)
                //{
                //    clsCinetpayContact uncontact = new clsCinetpayContact();
                //     uncontact.Prefix= listclsCinetpayContact[Idx].Prefix;
                //    uncontact.Phone = listclsCinetpayContact[Idx].Phone;
                //    uncontact.Name = listclsCinetpayContact[Idx].Name;
                //    uncontact.Surname = listclsCinetpayContact[Idx].Surname;
                //    uncontact.Email = listclsCinetpayContact[Idx].Email;

                //}

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((s, ce, ch, ssl) => true);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                //System.Net.ServicePointManager.Expect100Continue = false;
                System.Net.ServicePointManager.Expect100Continue = false;



                using (var StreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    StreamWriter.Write(postData);
                }
                //if (IsNetworkConnected())
                //{
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var NewISOmsg = responseString;
                NewISOmsg = responseString.Replace("[[", "[");
                NewISOmsg = NewISOmsg.Replace("]]", "]");
                //obj = JsonConvert.DeserializeObject<clsDataTransferts>(NewISOmsg);
                //objList.Add(obj);
                //}
                //else objList = null;

                obj = JsonConvert.DeserializeObject<clsDataTransferts>(NewISOmsg);
                objList.Add(obj);

            }
            catch (Exception e)
            {
                var dat = e.Message;

            }

            //watch.Stop();
            // TempData["time"] = watch.ElapsedMilliseconds;
            return objList;
        }
        //++++++++++++++++++++++++++++++++++

    }
}
