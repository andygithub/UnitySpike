Namespace Interfaces

    Public Interface IUserRepository

        Function ExecuteSearch(ByVal parameters As SearchParameters) As IEnumerable(Of SearchResults)
        Function GetFieldList() As IEnumerable(Of String)

    End Interface

End Namespace