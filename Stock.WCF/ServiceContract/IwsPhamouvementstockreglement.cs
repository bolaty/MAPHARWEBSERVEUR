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

	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IwsPhamouvementstockreglement" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IwsPhamouvementstockreglement
	{
        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsPhamouvementstockreglement.svc/pvgAjouter
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodePhamouvementstockreglement": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgAjouter", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouter(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsPhamouvementstockreglement.svc/pvgExtourne
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodePhamouvementstockreglement": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgExtourne", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgExtourne(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);



        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsPhamouvementstockreglement.svc/pvgModifier
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodePhamouvementstockreglement": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgModifier", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgModifier(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsPhamouvementstockreglement.svc/pvgSupprimer
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodePhamouvementstockreglement": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSupprimer", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgSupprimer(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsPhamouvementstockreglement.svc/pvgChargerDansDataSet
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodePhamouvementstockreglement": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSet", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSet(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        ///<summary>Cette fonction permet de d'executer une requete SELECT dans la base de donnees </summary>
        ///<param name="Objet">Collection de clsInput </param>
        ///<returns>Une collection de clsInput valeur du résultat de la requete</returns>
        ///<author>Home Technology</author>
        ///  PARAMETRES DE TEST POSTMAN
        //// http://localhost:2723/Service/wsPhamouvementstockreglement.svc/pvgChargerDansDataSetPourCombo
        ///  {"Objet" :[{"CodeAgence": "","CodeOperateur": "","CodePhamouvementstockreglement": "","Libelle": "", "TYPEOPERATION": ""}]}
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourCombo", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSetPourCombo(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgMouvementResumeReglement", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgMouvementResumeReglement(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReglementAssureur", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementAssureur(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReglementClient", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementClient(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationDetailFacture", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsMiccomptewebResultat> pvgCreationDetailFacture(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationDetailFacture1", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        HT_Stock.BOJ.clsMiccomptewebResultat pvgCreationDetailFacture1(string AG_CODEAGENCE, string SL_NUMEROTRANSACTION, string SL_LIBELLEECRAN, string SL_LIBELLEMOUCHARD, string TO_VALIDEROPERATIONENCOURS, string TYPEOPERATION);



        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReglementClientMobile", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementClientMobile(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReglementCommissionAssurance", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementCommissionAssurance(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReglementCommercial", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgReglementCommercial(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);


        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInsertIntoDatasetReglementCommission", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgInsertIntoDatasetReglementCommission(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetSoldeCompteEcranOD", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSetSoldeCompteEcranOD(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgAjouterListeChargeAvecRepartition", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouterListeChargeAvecRepartition(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgAjouterListeChargeAvecRepartitionReglementTresorerieTiers", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouterListeChargeAvecRepartitionReglementTresorerieTiers(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgAjouterListeChargeAvecRepartitionReglementTresorerieCaisse", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgAjouterListeChargeAvecRepartitionReglementTresorerieCaisse(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgSelectListe/{PO_CODEPhamouvementstockreglement}/{TYPEOPERATION}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetRecudeCaisse", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<HT_Stock.BOJ.clsPhamouvementstockreglement> pvgChargerDansDataSetRecudeCaisse(List<HT_Stock.BOJ.clsPhamouvementstockreglement> Objet);





    }
}
