Imports System.ServiceModel
Imports System.Web.Script.Services
Imports System.ServiceModel.Web
Imports System.ServiceModel.Activation
Imports ManagedUserLookup.Library

Public Interface IFileTransferService

    <OperationContract(IsOneWay:=True)> _
    Sub UploadFile(ByVal request As FileUploadMessage)

    <OperationContract(IsOneWay:=False)> _
    Function DownloadFile(ByVal gridParameters As JQGridParameters, ByVal exportInterface As String, ByVal selectedSearchParameters As SearchParameters) As FileDownloadReturnMessage
End Interface
