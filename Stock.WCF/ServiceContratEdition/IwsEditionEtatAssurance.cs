using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using  Stock.BOJ;
using  Stock.Common;

namespace Stock.WCF
{

	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IwsEditionEtatAssurance" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IwsEditionEtatAssurance
	{

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssurance
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAssurance", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssurance(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssuranceAppercu
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAssuranceAppercu", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceAppercu(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssurance
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAssuranceEncaissementCheque", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceEncaissementCheque(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssuranceAvisReglementPrime
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAssuranceAvisReglementPrime", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceAvisReglementPrime(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssuranceTESTETAT
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAssuranceTESTETAT", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatAssuranceTESTETAT(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssurance
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAssuranceTest", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        object pvgInsertIntoDatasetEtatAssuranceTest(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);
        
        
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatAssurance.svc/pvgInsertIntoDatasetEtatAssurance
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatAssurance": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatAssurance}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatSynoptique", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatAssurance> pvgInsertIntoDatasetEtatSynoptique(List<HT_Stock.BOJ.clsEditionEtatAssurance> Objet);


    }
}
