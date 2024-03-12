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

	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IwsEdition" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IwsEdition
	{


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEdition.svc/pvgInsertIntoDatasetExercice
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEdition": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEdition}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetExercice", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEdition> pvgInsertIntoDatasetExercice(List<HT_Stock.BOJ.clsEdition> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEdition.svc/pvgInsertIntoDatasetPeriodicite
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEdition": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEdition}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetPeriodicite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEdition> pvgInsertIntoDatasetPeriodicite(List<HT_Stock.BOJ.clsEdition> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEdition.svc/pvgInsertIntoDatasetZone
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEdition": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEdition}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetZone", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEdition> pvgInsertIntoDatasetZone(List<HT_Stock.BOJ.clsEdition> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEdition.svc/pvgChargerDansDataSetPourComboAgenceEdition
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEdition": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
    //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEdition}/{TYPEOPERATION}")]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboAgenceEdition", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    List<HT_Stock.BOJ.clsEdition> pvgChargerDansDataSetPourComboAgenceEdition(List<HT_Stock.BOJ.clsEdition> Objet);


    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    ///  PARAMETRES DE TEST POSTMAN
    //// http://localhost:2723/Service/wsEdition.svc/pvgPeriodicite
    ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEdition": "","Libelle": "", "TYPEOPERATION": ""}]}
    [OperationContract]
    //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEdition}/{TYPEOPERATION}")]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgPeriodicite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    List<HT_Stock.BOJ.clsEdition> pvgPeriodicite(List<HT_Stock.BOJ.clsEdition> Objet);

    ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
    ///<param name="Objet">Collection de clsInput </param>
    ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
    ///<author>Home Technology</author>
    ///  PARAMETRES DE TEST POSTMAN
    //// http://localhost:2723/Service/wsEdition.svc/pvgPeriodiciteDateDebutFin
    ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEdition": "","Libelle": "", "TYPEOPERATION": ""}]}
    [OperationContract]
    //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEdition}/{TYPEOPERATION}")]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgPeriodiciteDateDebutFin", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
    List<HT_Stock.BOJ.clsEdition> pvgPeriodiciteDateDebutFin(List<HT_Stock.BOJ.clsEdition> Objet);



    }
}
