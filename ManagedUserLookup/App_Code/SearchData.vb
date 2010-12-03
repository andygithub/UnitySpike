Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Web.Script.Services
Imports ManagedUserLookup.Library
Imports ManagedUserLookup.Library.Interfaces
Imports Microsoft.Practices.Unity
Imports System.ServiceModel.Description


<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class SearchData
    Implements ISearchData


    Public Function GetRoles(ByVal sidx As String, ByVal sord As String, ByVal page As Integer, ByVal rows As Integer, ByVal _search As Boolean, ByVal filters As Filter) As ManagedUserLookup.Library.JQGrid Implements ISearchData.GetRoles
        'parameters are ignored because this function is just returning a list of roles.
        'grid expects this signature.

        LoggingFacade.Write("Starting the GetRoles method.")

        Dim _repos As IRolesRepository = UnitySingleton.Container.Resolve(Of IRolesRepository)()
        Return _repos.GetRoles.ToJsonForjqGridList(Resources.Properties.Id, New List(Of String)(New String() {Resources.Properties.Name}))

    End Function

    Public Function SearchResults(ByVal gridParameters As JQGridParameters, ByVal exportInterface As String, ByVal selectedSearchParameters As SearchParameters) As JQGridValidationError Implements ISearchData.SearchResults
        LoggingFacade.Write("Starting the SearchResults method.")

        If selectedSearchParameters IsNot Nothing AndAlso Not selectedSearchParameters.IsValid Then
            Return New JQGridValidationError With {.ErrorMessage = Resources.Messages.ParametersNotValid}
        End If
        Dim _repos As IUserRepository = UnitySingleton.Container.Resolve(Of IUserRepository)()
        Return _repos.ExecuteSearch(selectedSearchParameters).ToJsonForjqGrid(Resources.Properties.Id, _repos.GetFieldList)
    End Function

End Class
