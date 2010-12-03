Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports ManagedUserLookup.Library
Imports ManagedUserLookup.Library.Interfaces
Imports Microsoft.Practices.Unity

<ServiceContract(Namespace:="")>
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
Public Class FileTransferService
    Implements IFileTransferService

    Public Function DownloadFile(ByVal gridParameters As JQGridParameters, ByVal exportInterface As String, ByVal selectedSearchParameters As SearchParameters) As FileDownloadReturnMessage Implements IFileTransferService.DownloadFile
        If Not selectedSearchParameters.IsValid Then Throw New ArgumentException(Resources.Messages.ParametersNotValid)
        Dim _repos As IUserRepository = UnitySingleton.Container.Resolve(Of IUserRepository)()

        Return New FileDownloadReturnMessage(New FileMetaData("excel.xls", "excel.xls"), _repos.ExecuteSearch(selectedSearchParameters).ToExcelExportStream( _repos.GetFieldList))
    End Function

    Public Sub UploadFile(ByVal request As FileUploadMessage) Implements IFileTransferService.UploadFile
        Throw New NotImplementedException
    End Sub
End Class
