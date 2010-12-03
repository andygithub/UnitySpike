Imports Microsoft.Practices.EnterpriseLibrary.Logging

Public Class LoggingFacade

    Public Shared Sub Write(ByVal message As String)

#If DEBUG Then
        Console.WriteLine(message & My.Resources.LogMessages.Hyphen & DateTime.Now)
        Debug.WriteLine(message & My.Resources.LogMessages.Hyphen & DateTime.Now)
#Else
        Logger.Write(message)
#End If
    End Sub

End Class
