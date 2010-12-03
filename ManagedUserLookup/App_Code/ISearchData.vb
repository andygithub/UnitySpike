Imports ManagedUserLookup.Library
Imports System.ServiceModel
Imports System.Web.Script.Services
Imports System.ServiceModel.Web
Imports System.ServiceModel.Activation

<ServiceContract(Namespace:="")> _
<ScriptService()> _
Public Interface ISearchData

    <OperationContract()> _
    <Services.WebMethod(EnableSession:=False)> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    <WebGet()> _
    Function GetRoles(ByVal sidx As String, ByVal sord As String, ByVal page As Integer, ByVal rows As Integer, ByVal _search As Boolean, ByVal filters As Filter) As ManagedUserLookup.Library.JQGrid

    <OperationContract()> _
    <Services.WebMethod(EnableSession:=False)> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Function SearchResults(ByVal gridParameters As JQGridParameters, ByVal exportInterface As String, ByVal selectedSearchParameters As SearchParameters) As JQGridValidationError
End Interface