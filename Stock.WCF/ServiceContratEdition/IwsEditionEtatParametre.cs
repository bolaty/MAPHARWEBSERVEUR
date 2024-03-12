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

	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IwsEditionEtatParametre" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IwsEditionEtatParametre
	{


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatAutre
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatAutre", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatAutre(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatPlancomptable
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatPlancomptable", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatPlancomptable(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatEntrepot
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatEntrepot", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatEntrepot(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatEntrepotTEST
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatEntrepotTEST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatEntrepotTEST(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);




        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatJournal
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatJournal", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatJournal(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatRayon
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatRayon", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatRayon(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatUnite
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatUnite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatUnite(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatParametre.svc/pvgInsertIntoDatasetEtatParamtre
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeEditionEtatParametre": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEEditionEtatParametre}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatParamtre", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatParametre> pvgInsertIntoDatasetEtatParamtre(List<HT_Stock.BOJ.clsEditionEtatParametre> Objet);



    }
}
