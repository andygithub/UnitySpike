Imports System.IO
Imports System.ServiceModel

<MessageContract()> _
Public Class FileDownloadReturnMessage

    Sub New(ByVal metaData As FileMetaData, ByVal Stream As Stream)
        Me.DownloadedFileMetadata = metaData
        Me.FileByteStream = Stream
    End Sub

    <MessageHeader(MustUnderstand:=True)> _
    Public Property DownloadedFileMetadata As FileMetaData
    <MessageBodyMember(Order:=1)> _
    Public Property FileByteStream As Stream

End Class