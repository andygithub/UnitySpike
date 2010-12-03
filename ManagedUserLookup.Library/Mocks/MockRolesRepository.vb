Namespace Mocks

    Public Class MockRolesRepository
        Implements Interfaces.IRolesRepository


        Public Function GetRoles() As System.Collections.Generic.IEnumerable(Of Role) Implements Interfaces.IRolesRepository.GetRoles
            Dim _list As New List(Of Role)
            With _list
                For i As Integer = 0 To 45
                    .Add(New Role With {.Id = i, .Name = i & " Consumer Demo " & i})
                Next
            End With

            Return _list
        End Function

    End Class

End Namespace