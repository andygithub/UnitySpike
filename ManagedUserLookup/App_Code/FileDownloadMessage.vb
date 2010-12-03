Imports System.ServiceModel

<MessageContract()> _
Public Class FileDownloadMessage

    <MessageHeader(MustUnderstand:=True)> _
    Public Property MetaData As FileMetaData
End Class