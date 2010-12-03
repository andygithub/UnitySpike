Public Class SearchParameters
    Public Property Environment As String
    Public Property ExactMatch As String
    Public Property RoleList As List(Of String)
    Public Property SingleRole As String
    Public Property matchedRoles As String
    Public Property UserIdType As String
    Public Property UserId As String

    Public Function IsValid() As Boolean

        If RoleList.Count = 0 AndAlso String.IsNullOrEmpty(SingleRole) AndAlso String.IsNullOrEmpty(UserId) Then Return False
        Return True
    End Function
End Class
