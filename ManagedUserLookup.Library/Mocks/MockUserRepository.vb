Namespace Mocks

    Public Class MockUserRepository
        Implements Interfaces.IUserRepository, Interfaces.IExport

        Public Function ExecuteSearch(ByVal parameters As SearchParameters) As IEnumerable(Of SearchResults) Implements Interfaces.IUserRepository.ExecuteSearch
            Dim _list As New List(Of SearchResults)
            For i As Integer = 0 To 30
                _list.Add(New SearchResults With {.Id = i, .USEC = i & "-USEC",
                                                  .Scope = i & "-Scope Name - ",
                                                  .DatabaseUserName = i & "dbUserName",
                                                  .FirstName = "First Name ",
                                                  .LastName = i & "-Last Name",
                                                  .Role = " Role Name"})
            Next
            Return _list
        End Function

        Public Function GetFieldList() As System.Collections.Generic.IEnumerable(Of String) Implements Interfaces.IUserRepository.GetFieldList, Interfaces.IExport.GetFieldList
            Return New List(Of String)(New String() {My.Resources.Properties.USEC, My.Resources.Properties.DatabaseUserName,
                                                     My.Resources.Properties.FirstName, My.Resources.Properties.LastName,
                                                     My.Resources.Properties.Scope, My.Resources.Properties.Role})
        End Function

        Public Function GetExportData(ByVal criteria As System.Collections.Specialized.NameValueCollection) As jqgrid Implements Interfaces.IExport.GetExportData
            Dim selectedSearchParameters As SearchParameters = BuildParameters(criteria)

            Return ExecuteSearch(selectedSearchParameters).ToJsonForjqGridList(My.Resources.Properties.Id, GetFieldList)

        End Function

        Private Function BuildParameters(ByVal criteria As Specialized.NameValueCollection) As SearchParameters
            Dim selectedSearchParameters As New SearchParameters() With {.Environment = criteria(My.Resources.Properties.Environment),
                                                                 .ExactMatch = criteria(My.Resources.Properties.ExactMatch),
                                                                 .matchedRoles = criteria(My.Resources.Properties.matchedRoles),
                                                                 .SingleRole = criteria(My.Resources.Properties.Role),
                                                                 .UserId = criteria(My.Resources.Properties.UserId),
                                                                 .UserIdType = criteria(My.Resources.Properties.UserIdType)}
            selectedSearchParameters.RoleList = New List(Of String)
            If criteria("RoleList%5B%5D") IsNot Nothing Then
                selectedSearchParameters.RoleList.AddRange(criteria("RoleList%5B%5D").Split(","c))
            End If
            Return selectedSearchParameters
        End Function

        Public Function ValidateExportCriteria(ByVal criteria As System.Collections.Specialized.NameValueCollection) As Boolean Implements Interfaces.IExport.ValidateExportCriteria
            Dim selectedSearchParameters As SearchParameters = BuildParameters(criteria)
            If selectedSearchParameters.IsValid Then
                Return True
            Else
                Return False
            End If

        End Function
    End Class

End Namespace