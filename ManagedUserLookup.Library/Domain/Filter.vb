Imports System.Runtime.Serialization.Json
Imports System.Text

Public Class Filter

    Public Property groupOp As String

    Public Property rules As Rule()

    Public Shared Function Create(ByVal jsonData As String) As Filter
        Try
            Dim serializer = New DataContractJsonSerializer(GetType(Filter))
            Dim reader As New System.IO.StringReader(jsonData)
            Dim ms As New System.IO.MemoryStream(Encoding.Default.GetBytes(jsonData))
            Return CType(serializer.ReadObject(ms), Filter)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
