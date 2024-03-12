using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using HT_Stock.BOJ;


namespace Stock.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IwsApisms" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IwsEditionEtatClientFournisseur
    {



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatClientFournisseur.svc/pvgInsertIntoDatasetEtatBudget
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeActivite": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEActivite}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatBudget", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatBudget(List<Stock.BOJ.clsEditionEtatClientFournisseur> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatClientFournisseur.svc/pvgInsertIntoDatasetEtatNatureTiers
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeActivite": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEActivite}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatNatureTiers", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatNatureTiers(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet);


        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsEditionEtatClientFournisseur.svc/pvgInsertIntoDatasetEtatListeTiers
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodeActivite": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEActivite}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetEtatListeTiers", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> pvgInsertIntoDatasetEtatListeTiers(List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> Objet);


       
    }
}
