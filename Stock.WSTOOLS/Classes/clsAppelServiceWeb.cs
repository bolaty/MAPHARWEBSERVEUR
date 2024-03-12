
using log4net;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Stock.WSTOOLS
{
   
    /// <summary>
    /// Objet d'appel et de retour d'un service web
    /// </summary>
    public class clsAppelServiceWeb
    {
       //static Log Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Methode d'excution d'un service web
        /// </summary>
        /// <typeparam name="K">L'objet retour du service Web</typeparam>
        /// <typeparam name="T">L'objet d'envoi du service web</typeparam>
        /// <param name="data">L'objet retour passé en paramete</param>
        /// <param name="clsObjetEnvoiEditionDTO">L'objet d'envoi passé en parametre</param>
        /// <param name="method">Le type d'envoi de la requete</param>
        /// <param name="url">L'Url du service web</param>
        /// <param name="procname">Le nom de la methode du service web</param>
        /// <returns></returns>
        public static IList<K> excecute<K, T>(K data, T ObjetEnvoi, string method, string url, string procname)
        {

            List<K> objList = new List<K>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;
            //httpWebRequest.Headers.Add("Authorization", " Basic " + vlpToken);

            //-----------------------------------------time out--------------------------//
            httpWebRequest.Timeout = Stock.WSTOOLS.clsDeclaration.TIMEOUT;
            httpWebRequest.KeepAlive = true;
            try
            {
                using (var streamWriterConsultation = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string jsonConsultation = new JavaScriptSerializer().Serialize(new
                    {
                        ObjetEnvoi
                    });
                    streamWriterConsultation.Write(jsonConsultation);
                }
                if (IsNetworkConnected())
                {
                    var httpResponseConsultation = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReaderConsultation = new StreamReader(httpResponseConsultation.GetResponseStream()))
                    {

                        string resultConsultation = streamReaderConsultation.ReadToEnd();


                        objList = JsonConvert.DeserializeObject<List<K>>(resultConsultation);




                    }
                }
                else
                    objList = null;
            }
            catch (System.Net.WebException e)
            {



                //Log.Error("Testing log4net error logging" + "-Impossible d'atteindre le service Web");


            }
            catch (Exception ex)
            {
                //Log.Error("Testing log4net error logging" + ex.InnerException);

            }
            return objList;


        }



        /// <summary>
        /// Methode d'excution d'un service web
        /// </summary>
        /// <typeparam name="K">L'objet retour du service Web</typeparam>
        /// <typeparam name="T">L'objet d'envoi du service web</typeparam>
        /// <param name="data">L'objet retour passé en paramete</param>
        /// <param name="clsObjetEnvoiEditionDTO">L'objet d'envoi passé en parametre</param>
        /// <param name="method">Le type d'envoi de la requete</param>
        /// <param name="url">L'Url du service web</param>
        /// <param name="procname">Le nom de la methode du service web</param>
        /// <returns></returns>
        public static IList<K> excecuteEdition<K, T>(K data, T Objet, string method, string url, string procname)
        {

            List<K> objList = new List<K>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;
            //httpWebRequest.Headers.Add("Authorization", " Basic " + vlpToken);

            //-----------------------------------------time out--------------------------//
            httpWebRequest.Timeout = Stock.WSTOOLS.clsDeclaration.TIMEOUT;
            httpWebRequest.KeepAlive = true;
            try
            {
                using (var streamWriterConsultation = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string jsonConsultation = new JavaScriptSerializer().Serialize(new
                    {
                        Objet
                    });
                    streamWriterConsultation.Write(jsonConsultation);
                }
                if (IsNetworkConnected())
                {
                    var httpResponseConsultation = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReaderConsultation = new StreamReader(httpResponseConsultation.GetResponseStream()))
                    {

                        string resultConsultation = streamReaderConsultation.ReadToEnd();


                        objList = JsonConvert.DeserializeObject<List<K>>(resultConsultation);




                    }
                }
                else
                    objList = null;
            }
            catch (System.Net.WebException e)
            {



                //Log.Error("Testing log4net error logging" + "-Impossible d'atteindre le service Web");


            }
            catch (Exception ex)
            {
                //Log.Error("Testing log4net error logging" + ex.InnerException);

            }
            return objList;


        }

        public static IList<K> excecuteServiceWeb<K, T>(K data, T Objet, string method, string url)
        {

            List<K> objList = new List<K>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;
            //httpWebRequest.Headers.Add("Authorization", " Basic " + vlpToken);



            if (string.IsNullOrEmpty(url))
            {

                try
                {
                    throw new Exception("L'url d'accès à l'api doit être configuré !!!");
                }
                catch { }
            }



            //-----------------------------------------time out--------------------------//
            httpWebRequest.Timeout = Stock.WSTOOLS.clsDeclaration.TIMEOUT;
            httpWebRequest.KeepAlive = true;
            try
            {
                using (var streamWriterConsultation = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string jsonConsultation = new JavaScriptSerializer().Serialize(new
                    {
                        Objet
                    });
                    streamWriterConsultation.Write(jsonConsultation);
                }
                if (IsNetworkConnected())
                {
                    var httpResponseConsultation = (HttpWebResponse)httpWebRequest.GetResponse();
                  
                    using (var streamReaderConsultation = new StreamReader(httpResponseConsultation.GetResponseStream()))
                    {
                        string resultConsultation = streamReaderConsultation.ReadToEnd();
                        objList = JsonConvert.DeserializeObject<List<K>>(resultConsultation);



                    }
                }
                else
                    objList = null;
            }

            catch (System.Net.WebException e)
            {


                
                    //Log.Error("Testing log4net error logging" + "-Impossible d'atteindre le service Web");
                   
                 
            }
            catch (Exception ex)
            {
                //Log.Error("Testing log4net error logging" + ex.InnerException);
               
            }

            
            return objList;


        }

        //Check your connection internet

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

    }



}