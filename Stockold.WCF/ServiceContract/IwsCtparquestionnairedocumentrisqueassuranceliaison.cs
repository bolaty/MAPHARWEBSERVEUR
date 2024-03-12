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

	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IwsCtparquestionnairedocumentrisqueassuranceliaison" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IwsCtparquestionnairedocumentrisqueassuranceliaison
	{
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsCtparquestionnairedocumentrisqueassuranceliaison.svc/pvgAjouter
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeCtparquestionnairedocumentrisqueassuranceliaison": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODECtparquestionnairedocumentrisqueassuranceliaison}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgAjouter", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgAjouter(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsCtparquestionnairedocumentrisqueassuranceliaison.svc/pvgModifier
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeCtparquestionnairedocumentrisqueassuranceliaison": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODECtparquestionnairedocumentrisqueassuranceliaison}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgModifier", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgModifier(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsCtparquestionnairedocumentrisqueassuranceliaison.svc/pvgSupprimer
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeCtparquestionnairedocumentrisqueassuranceliaison": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODECtparquestionnairedocumentrisqueassuranceliaison}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSupprimer", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgSupprimer(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsCtparquestionnairedocumentrisqueassuranceliaison.svc/pvgChargerDansDataSet
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeCtparquestionnairedocumentrisqueassuranceliaison": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODECtparquestionnairedocumentrisqueassuranceliaison}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSet", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsCtparquestionnairedocumentrisqueassuranceliaison.svc/pvgChargerDansDataSetPourCombo
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeCtparquestionnairedocumentrisqueassuranceliaison": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODECtparquestionnairedocumentrisqueassuranceliaison}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourCombo", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> Objet);

    }
}
