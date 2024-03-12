using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TontineMobile.BOJ;

namespace TontineMobile.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "ITontinewebClasse" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ITontinewebClasse
    {
            [OperationContract]//--OK

            [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgVersementTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
            //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgVersementTontine/{AG_CODEAGENCE}/{TE_CODESMSTYPEOPERATION}/{EJ_CODEEPARGNANTJOURNALIER}/{CT_CODECARTE}/{MI_CODEMISE}/{STICKER}/{ST_STICKERCODE1}/{ST_STICKERCODE2}/{MC_NOMTIERS}/{MONTANT}/{SM_TELEPHONE}/{DATEJOURNEE}/{OP_CODEOPERATEUR}/{SL_LOGIN}/{SL_MOTDEPASSE}/{SL_CLESESSION}/{SL_VERSIONAPK}/{TYPEOPERATION}")]
            clsResultatOperation1 pvgVersementTontine(string DATEJOURNEE, string AG_CODEAGENCE, string TE_CODESMSTYPEOPERATION, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE,  string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string MC_NOMTIERS, string PI_CODEPIECE, string MC_NUMPIECETIERS, string MONTANT, string SM_TELEPHONE, string OP_CODEOPERATEUR,  string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string SIGNATURE, string TYPEOPERATION,string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE);


        [OperationContract]//--OK
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgVersementTontineDiffere", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgVersementTontine/{AG_CODEAGENCE}/{TE_CODESMSTYPEOPERATION}/{EJ_CODEEPARGNANTJOURNALIER}/{CT_CODECARTE}/{MI_CODEMISE}/{STICKER}/{ST_STICKERCODE1}/{ST_STICKERCODE2}/{MC_NOMTIERS}/{MONTANT}/{SM_TELEPHONE}/{DATEJOURNEE}/{OP_CODEOPERATEUR}/{SL_LOGIN}/{SL_MOTDEPASSE}/{SL_CLESESSION}/{SL_VERSIONAPK}/{TYPEOPERATION}")]
        clsResultatOperation1 pvgVersementTontineDiffere(List<clsParametreVersementdiffere> Objet);


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgVersementTontineMobile", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgVersementTontine/{AG_CODEAGENCE}/{TE_CODESMSTYPEOPERATION}/{EJ_CODEEPARGNANTJOURNALIER}/{CT_CODECARTE}/{MI_CODEMISE}/{STICKER}/{ST_STICKERCODE1}/{ST_STICKERCODE2}/{MC_NOMTIERS}/{MONTANT}/{SM_TELEPHONE}/{DATEJOURNEE}/{OP_CODEOPERATEUR}/{SL_LOGIN}/{SL_MOTDEPASSE}/{SL_CLESESSION}/{SL_VERSIONAPK}/{TYPEOPERATION}")]
        clsResultatOperation1 pvgVersementTontineMobile(string DATEJOURNEE, string AG_CODEAGENCE, string TE_CODESMSTYPEOPERATION, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE, string MI_CODEMISE, string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string MC_NOMTIERS, string PI_CODEPIECE, string MC_NUMPIECETIERS, string MONTANT, string SM_TELEPHONE, string OP_CODEOPERATEUR,  string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string SIGNATURE, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE);



        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgBrouillard", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgBrouillard/{CODEAGENCE}/{DATEJOURNEE}/{CODEOPERATEUR}")]
        List<clsTontinewebUserTransaction> pvgBrouillard(string DATEJOURNEE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserTransaction", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontinewebUserTransaction> pvgUserTransaction(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string OP_CODEOPERATEUR, string CL_IDCLIENT, string MB_IDTIERS, string MC_DATEPIECE1, string MC_DATEPIECE2, string MC_NBRELIGNE, string CT_IDCARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserTransactionClient", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontinewebUserTransaction> pvgUserTransactionClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string OP_CODEOPERATEUR, string CL_IDCLIENT, string MB_IDTIERS, string MC_DATEPIECE1, string MC_DATEPIECE2, string MC_NBRELIGNE, string CT_IDCARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgListeDesTransactionTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTransactiontontine> pvgListeDesTransactionTontine(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CL_TELEPHONE, string CT_CODECARTE,  string DATEJOURNEE1, string DATEJOURNEE2, string ET_TYPEETAT, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgListeDesVirementTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTransactiontontine> pvgListeDesVirementTontine(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CT_CODECARTE, string DATEJOURNEE1, string DATEJOURNEE2, string ET_TYPEETAT, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgVerificationClient", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsClient pvgVerificationClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string OP_CODEOPERATEUR, string LG_CODELANGUE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string OS_MACADRESSE);



        [OperationContract]//--OK
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLogin/{SL_LOGIN}/{SL_MOTPASSE}/{SL_VERSIONAPK}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserLogin", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserLogin pvgUserLogin(string SL_LOGIN, string SL_MOTPASSE, string SL_VERSIONAPK, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--OK
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserLoginDeconnection", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserLogin pvgUserLoginDeconnection(string DATEJOURNEE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--OK
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserForgotPassword/{CL_CONTACT}/{SL_VERSIONAPK}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserForgotPassword", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebmotpasseoublie pvgUserForgotPassword(string DATEJOURNEE, string CL_CONTACT, string CL_CODECLIENT, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string TYPEOPERATION);


        [OperationContract]//--OK
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserUpdatePassword/{SL_MOTPASSEOLD}/{SL_LOGINOLD}/{SL_MOTPASSENEW}/{SL_LOGINNEW}/{SL_LOGIN}/{SL_MOTDEPASSE}/{SL_CLESESSION}/{SL_VERSIONAPK}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserUpdatePassword", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserNewPassword pvgUserUpdatePassword(string DATEJOURNEE, string SL_MOTPASSEOLD, string SL_LOGINOLD, string SL_MOTPASSENEW, string SL_LOGINNEW, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string TYPEOPERATEUR, string OS_MACADRESSE);


        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUserNewPassword", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserNewPassword pvgUserNewPassword(string DATEJOURNEE, string SL_MOTPASSE, string RP_CODEVALIDATION, string RP_DATE, string RP_HEURE, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string TYPEOPERATION);


        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCarnetsClient", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontineCarnet> pvgCarnetsClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR);

        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSelectCarteCarnet", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontineCarte> pvgSelectCarteCarnet(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT,string CT_CODECARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR, string CM_IDCOMMERCIAL, string TYPEOPERATION);

        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSelectCarteCarnetClient", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontineCarte> pvgSelectCarteCarnetClient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT,  string CT_CODECARTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR, string CM_IDCOMMERCIAL, string TYPEOPERATION);



        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSituationportefeuilleclient", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontineCarte> pvgSituationportefeuilleclient(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CT_CODECARTE, string CM_IDCOMMERCIAL, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE, string OP_CODEOPERATEUR);






        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReseau", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsReseau> pvgReseau(string DATEJOURNEE, string NOMBRELIGNE, string CL_ADRESSEGEOGRAPHIQUE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);



        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboPieceidentite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsPieceidentite> pvgChargerDansDataSetPourComboPieceidentite(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboMise", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontinemise> pvgChargerDansDataSetPourComboMise(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);



        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgTelephoneoperateur", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsTelephoneoperateur pvgTelephoneoperateur(string DATEJOURNEE, string AG_CODEAGENCE, string OS_MACADRESSE, string OS_CODEVALIDATION, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgTelephoneoperateurCreationcpte", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsTelephoneoperateur pvgTelephoneoperateurCreationcpte(string DATEJOURNEE, string AG_CODEAGENCE, string OS_MACADRESSE, string OS_CODEVALIDATION, string OS_TELEPHONE, string OP_CODEOPERATEUR, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE);




        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgReedition", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsReedition> pvgReedition(string DATEJOURNEE, string AG_CODEAGENCE, string MC_DATEPIECE, string MC_NUMPIECE, string CL_TELEPHONE, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);



        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboActivite", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsActivite> pvgChargerDansDataSetPourComboActivite(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--OK
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboCommune", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsCommune> pvgChargerDansDataSetPourComboCommune(string DATEJOURNEE, string VL_CODEVILLE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);


        [OperationContract]//--OK
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboCommercial", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsMiccommercial> pvgChargerDansDataSetPourComboCommercial(string DATEJOURNEE, string TYPEOPERATION, string CM_IDCOMMERCIAL, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);



        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboSituationMatrimoniale", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsSituationmatrimoniale> pvgChargerDansDataSetPourComboSituationMatrimoniale(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--OK
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboPays", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsPays> pvgChargerDansDataSetPourComboPays(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--OK
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboSexe", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsSexe> pvgChargerDansDataSetPourComboSexe(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboVille", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsVille> pvgChargerDansDataSetPourComboVille(string DATEJOURNEE, string PY_CODEPAYS, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboProfession", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsProfession> pvgChargerDansDataSetPourComboProfession(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);
        [OperationContract]//--ok
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboFormjuridique", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsFormejuridique> pvgChargerDansDataSetPourComboFormjuridique(string DATEJOURNEE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);




        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUploadPhotoSignature", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserLogin pvgUploadPhotoSignature(string DATEJOURNEE, string PHOTO, string SIGNATURE, string NOMPHOTO, string NOMSIGNATURE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgUploadSignature", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserLogin pvgUploadSignature(string DATEJOURNEE,  string SIGNATURE,  string NOMSIGNATURE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string LG_CODELANGUE, string OS_MACADRESSE);



        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgDownloadPhotoSignature", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebUserLogin pvgDownloadPhotoSignature(string DATEJOURNEE, string NOMIMAGE, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationClientTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebmotpasseoublie pvgCreationClientTontine(string DATEJOURNEE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string CO_CODECOMMUNE, string EJ_ADRESSEGEOGRAPHIQUE, string PY_CODEPAYSNATIONALITE, string SM_CODESITUATIONMATRIMONIALE, string PF_CODEPROFESSION, string PI_CODEPIECE, string EJ_BOITEPOSTALE, string EJ_NOMEPARGNANTJOURNALIER, string EJ_PRENOMEPARGNANTJOURNALIER, string EJ_DATENAISSANCE, string EJ_LIEUNAISSANCE, string EJ_TELEPHONE, string EJ_FAX, string EJ_EMAIL, string EJ_SITEWEB, string EJ_NUMPIECE, string EJ_DATEEXPIRATIONPIECE, string EJ_REGIMEMATRIMONIALE, string EJ_NBENFANT, string CM_IDCOMMERCIAL, string MI_VALEUR, string EJ_LONGITUDELATIITUDE, string TYPEOPERATION,  string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationClientTontineDiffere", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebmotpasseoublie pvgCreationClientTontineDiffere(List<clsParametreClientdiffere> Objet);




        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgListeDesClients/{AG_CODEAGENCE}/{CL_CODECLIENT}/{CL_TELEPHONE}/{CL_NOMCLIENT}/{CL_PRENOMCLIENT}/{DATEJOURNEE1}/{DATEJOURNEE2}/{NOMBRELIGNE}/{CL_IDCLIENTAGENTAGREE}/{SL_LOGIN}/{SL_MOTDEPASSE}/{SL_CLESESSION}/{SL_VERSIONAPK}/{ET_TYPEETAT}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgListeDesClients", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsListedesclients> pvgListeDesClients(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CL_TELEPHONE, string CL_NOMCLIENT, string CL_PRENOMCLIENT, string DATEJOURNEE1, string DATEJOURNEE2, string NOMBRELIGNE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string ET_TYPEETAT, string LG_CODELANGUE, string OS_MACADRESSE);


        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgComptabilisationImpression", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgComptabilisationImpression(string DATEJOURNEE, string AG_CODEAGENCE, string CL_CODECLIENT, string CT_CODECARTE, string DI_DATEIMPRESSION, string OP_CODEOPERATEUR, string LG_CODELANGUE, string SL_LOGIN, string SL_MOTPASSE, string TYPEOPERATEUR, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationCarteTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgCreationCarteTontine(string LG_CODELANGUE, string AG_CODEAGENCE, string OP_CODEOPERATEUR, string EJ_IDEPARGNANTJOURNALIER, string DATEJOURNEE, string CM_IDCOMMERCIAL, string MI_VALEUR, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationCarteTontineDiffere", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgCreationCarteTontineDiffere(List<clsParametreCartediffere> Objet);






        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgTransfertPortefeuilleClientTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgTransfertPortefeuilleClientTontine(string LG_CODELANGUE, string AG_CODEAGENCE, string CM_IDCOMMERCIALINITIAL, string CM_IDCOMMERCIALFINAL, string OP_CODEOPERATEUR, string DATEJOURNEE, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgActivationDesactivationClientTontine", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgActivationDesactivationClientTontine(string LG_CODELANGUE, string AG_CODEAGENCE, string EJ_IDEPARGNANTJOURNALIER, string OP_CODEOPERATEUR, string DATEJOURNEE, string SL_LOGIN, string SL_MOTPASSE, string OS_MACADRESSE, string TYPEOPERATION);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgDemandeToken", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsHttoken pvgDemandeToken(string LG_CODELANGUE, string AG_CODEAGENCE, string TK_TOKEN, string TK_CODETYPEOPERATION, string EJ_IDEPARGNANTJOURNALIER, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCreationDetailFacture", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgCreationDetailFacture(string DATEJOURNEE, string AG_CODEAGENCE, string NO_CODENATUREVIREMENT, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE, string MI_CODEMISE, string STICKER, string ST_STICKERCODE1, string ST_STICKERCODE2, string MC_NOMTIERS, string PI_CODEPIECE, string MC_NUMPIECETIERS, string MONTANT, string SM_TELEPHONE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string TYPEOPERATION, string SIGNATURE, string TO_VALIDEROPERATIONENCOURS, string DT_NUMEROTRANSACTION, string TK_TOKEN, string SO_CODESOUSCRIPTION, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerListOperateur", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsOperateur> pvgChargerListOperateur(string DATEJOURNEE, string AG_CODEAGENCE, string PV_CODEPOINTVENTE, string OP_NOMPRENOM, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboPointVente", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsMicpointvente> pvgChargerDansDataSetPourComboPointVente(string DATEJOURNEE, string AG_CODEAGENCE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);


        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgVirementDAV", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsMiccomptewebResultat pvgVirementDAV(string DATEJOURNEE, string AG_CODEAGENCE, string VR_NUMEROTRANSACTION, string VR_IDCOMPTESIG, string VR_NUMCOMPTESIG, string ID_CLIENTSIG, string VR_MONTANTTRANSACTION, string EJ_CODEEPARGNANTJOURNALIER, string CT_CODECARTE, string VR_NUMEROBORDEREAUSIG, string VR_NUMEROBORDEREAUTONTINE,  string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string TYPEOPERATION, string LG_CODELANGUE, string OS_MACADRESSE);




        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSouscriptionMobileBanking", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsResultat pvgSouscriptionMobileBanking(string LG_CODELANGUE, string AG_CODEAGENCE,  string SO_CODESOUSCRIPTION, string PY_CODEPAYS, string SO_TELEPHONE, string DATEJOURNEE, string SO_EMAIL, string SO_LIEURESIDENCE, string TYPEOPERATION, string TK_TOKEN, string EJ_IDEPARGNANTJOURNALIER,string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE);


        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgSouscriptionVirementDAV", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsResultat pvgSouscriptionVirementDAV(string LG_CODELANGUE, string AG_CODEAGENCE, string EJ_IDEPARGNANTJOURNALIER, string ID_CLIENTSIG, string SO_CODESOUSCRIPTION, string DATEJOURNEE, string TYPEOPERATION, string TK_TOKEN, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE);




        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboCartes", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTontineCarte> pvgChargerDansDataSetPourComboCartes(string EJ_IDEPARGNANTJOURNALIER, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgCompteMobileMappe", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsNumeroMobileMappe> pvgCompteMobileMappe(string LG_CODELANGUE, string AG_CODEAGENCE, string CO_CODECOMPTE, string CL_IDCLIENT,string CT_CODECARTE,string SO_TELEPHONE, string TYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string OS_MACADRESSE);


        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgVersments/{AG_CODEAGENCE}/{TE_CODESMSTYPEOPERATION}/{CL_CODECLIENT}/{PS_ABREVIATION}/{SEQUENCECOMPTE}/{DATEJOURNEE}/{MONTANTOPERATION}/{SM_TELEPHONE}/{MC_NOMTIERS}/{OP_CODEOPERATEUR}/{TS_CODETYPESCHEMACOMPTABLE}/{SL_LOGIN}/{SL_MOTDEPASSE}/{SL_CLESESSION}/{SL_VERSIONAPK}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgInfoSousCriptionMobile", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsInfoSouscriptionMobile pvgInfoSousCriptionMobile(string AG_CODEAGENCE, string SO_TELEPHONE, string LG_CODELANGUE, string TYPEOPERATION);


        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSet1Billetage", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTypeoperation> pvgChargerDansDataSet1Billetage(string DATEJOURNEE, string AG_CODEAGENCE, string OB_NOMOBJET, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSet3Operations", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsTypeschemacomptable> pvgChargerDansDataSet3Operations(string DATEJOURNEE, string AG_CODEAGENCE, string OB_NOMOBJET, string TO_CODETYPEOPERATION, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsOperateur> pvgChargerDansDataSetPourComboOP_CAISSIERPassationFond(string DATEJOURNEE, string AG_CODEAGENCE,  string OP_JOURNEEOUVERTE, string OP_CODEOPERATEUR, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetSC_SCHEMACOMPTABLECODE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsSchemacomptable> pvgChargerDansDataSetSC_SCHEMACOMPTABLECODE(string DATEJOURNEE, string AG_CODEAGENCE, string OB_NOMOBJET, string SC_SCHEMACOMPTABLECODE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgChargerDansDataSetPlancomptable", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<clsPlancomptable> pvgChargerDansDataSetPlancomptable(string DATEJOURNEE, string AG_CODEAGENCE, string PL_NUMCOMPTE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgAjouterComptabilisation", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsResultat pvgAjouterComptabilisation(clsObjetversement clsObjetversement, string DATEJOURNEE, string AG_CODEAGENCE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);

        [OperationContract]//--ok
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "pvgUserLoginDeconnection/{SL_LOGIN}/{SL_MOTPASSE}/{TYPEOPERATEUR}")]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "pvgTableLabelSchemacomptable", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        clsSchemacomptable pvgTableLabelSchemacomptable(string DATEJOURNEE, string AG_CODEAGENCE, string TS_CODETYPESCHEMACOMPTABLE, string SL_LOGIN, string SL_MOTDEPASSE, string SL_CLESESSION, string SL_VERSIONAPK, string LG_CODELANGUE, string OS_MACADRESSE);


    }
}
